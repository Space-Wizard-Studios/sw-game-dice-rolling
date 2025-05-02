using Godot;
using DiceRolling.Entities;
using DiceRolling.Characters;
using DiceRolling.Helpers;
using System.Linq;

namespace DiceRolling.Components;

/// <summary>
/// Component that displays an animated 3D model for a character entity based on its current state.
/// </summary>
/// <remarks>
/// This component listens for updates to the parent Entity3D's CharacterType and its own CurrentAnimationName property.
/// It instantiates the appropriate PackedScene from the CharacterType's CharacterAnimations dictionary.
/// </remarks>
[Tool]
[GlobalClass]
[Icon("res://assets/editor/component-3d.svg")]
public partial class AnimatedModel3DComponent : Node3D {
    private Entity3D? _parent;
    private Node3D? _currentModelInstance;
    private CharacterAnimationState _currentAnimationState = CharacterAnimationState.Idle;
    private bool _billboardEnabled = false;

    [Export]
    public string CurrentAnimationName {
        get => _currentAnimationState.ToString();
        set {
            if (System.Enum.TryParse<CharacterAnimationState>(value, true, out var newState)) {
                if (_currentAnimationState != newState) {
                    _currentAnimationState = newState;
                    UpdateModel();
                }
            }
            else {
                GD.PrintErr($"Invalid animation state string: {value}");
                if (_currentAnimationState != CharacterAnimationState.Idle) {
                    _currentAnimationState = CharacterAnimationState.Idle;
                    UpdateModel();
                }
            }
        }
    }

    [Export]
    public bool BillboardEnabled {
        get => _billboardEnabled;
        set {
            _billboardEnabled = value;
            SetProcess(_billboardEnabled);
        }
    }

    public override void _Ready() {
        _parent = GetParent<Entity3D>();

        if (_parent != null) {
            SignalHelper.ConnectSignal(_parent, nameof(Entity3D.EntityUpdated), this, nameof(OnEntityUpdated));
            UpdateModel();
        }
    }

    public override void _ExitTree() {
        if (_parent != null) {
            SignalHelper.DisconnectSignal(_parent, nameof(Entity3D.EntityUpdated), this, nameof(OnEntityUpdated));
        }
        DestroyCurrentModel();
    }

    public override void _Process(double delta) {
        if (!Engine.IsEditorHint() && BillboardEnabled && _currentModelInstance != null && IsInstanceValid(_currentModelInstance)) {
            var camera = GetViewport().GetCamera3D();
            if (camera != null) {
                Vector3 direction = camera.GlobalPosition - GlobalPosition;
                direction.Y = 0;
                Vector3 lookTarget = GlobalPosition + direction;
                _currentModelInstance.LookAt(lookTarget, Vector3.Up);
            }
        }
    }

    private void OnEntityUpdated() {
        GD.Print($"[AnimatedModel3DComponent] Entity Updated: {_parent?.Data?.Id}");
        UpdateModel();
    }

    private void UpdateModel() {
        if (_parent == null) return;

        var characterData = _parent.GetData<CharacterType>();
        PackedScene? targetScene = null;
        string requestedStateName = _currentAnimationState.ToString();
        string idleStateName = CharacterAnimationState.Idle.ToString();

        // Try to get the scene for the current animation state
        if (characterData?.CharacterAnimations != null && characterData.CharacterAnimations.TryGetValue(requestedStateName, out var scene)) {
            targetScene = scene;
        }
        // Fallback: If the specific animation isn't found, try getting Idle
        else if (characterData?.CharacterAnimations != null && _currentAnimationState != CharacterAnimationState.Idle && characterData.CharacterAnimations.TryGetValue(idleStateName, out var idleScene)) {
            GD.Print($"[AnimatedModel3DComponent] Animation '{requestedStateName}' not found for {characterData.Name}. Falling back to '{idleStateName}'.");
            targetScene = idleScene;
            // Update the internal state to Idle if falling back
            _currentAnimationState = CharacterAnimationState.Idle;
        }
        // Fallback: If still no scene, try the first one in the dictionary (if any)
        else if (characterData?.CharacterAnimations != null && characterData.CharacterAnimations.Count > 0) {
            GD.Print($"[AnimatedModel3DComponent] Animation '{requestedStateName}' and '{idleStateName}' not found for {characterData.Name}. Falling back to first available animation.");
            targetScene = characterData.CharacterAnimations.Values.FirstOrDefault();
            // Update the internal state to the key of the first animation found
            string? firstKey = characterData.CharacterAnimations.Keys.FirstOrDefault();
            if (firstKey != null && System.Enum.TryParse<CharacterAnimationState>(firstKey, true, out var firstState)) {
                _currentAnimationState = firstState;
            }
            else {
                _currentAnimationState = CharacterAnimationState.Idle;
            }
        }

        // If we found a target scene
        if (targetScene != null) {
            // Check if we need to instantiate a new model
            if (_currentModelInstance == null || _currentModelInstance.SceneFilePath != targetScene.ResourcePath) {
                DestroyCurrentModel();
                InstantiateModel(targetScene);
            }
            // Ensure visibility if model exists
            if (_currentModelInstance != null) {
                _currentModelInstance.Visible = true;
            }
        }
        else {
            DestroyCurrentModel();
            if (characterData != null) {
                GD.PrintErr($"[AnimatedModel3DComponent] No suitable animation scene found for character {characterData.Name} (requested: '{CurrentAnimationName}').");
            }
        }

        // TODO: Apply offsets or scaling from characterData if needed
        // Example: Position = new Vector3(characterData.SpritePositionX, 0, characterData.SpritePositionY);
        Position = new Vector3(0, 0, 0);
    }

    private void InstantiateModel(PackedScene modelScene) {
        if (modelScene == null) return;

        _currentModelInstance = modelScene.Instantiate<Node3D>();
        if (_currentModelInstance != null) {
            AddChild(_currentModelInstance);

            var animPlayer = _currentModelInstance.FindNodeOfType<AnimationPlayer>();

            if (animPlayer != null) {
                var animationList = animPlayer.GetAnimationList();
                if (animationList.Length > 0) {
                    // Tenta reproduzir a animação correspondente ao nome do arquivo da cena
                    string animationToPlay = System.IO.Path.GetFileNameWithoutExtension(modelScene.ResourcePath);
                    Animation? animResource = null;

                    if (animPlayer.HasAnimation(animationToPlay)) {
                        animResource = animPlayer.GetAnimation(animationToPlay);
                    }
                    else {
                        // Fallback: Usa a primeira animação encontrada
                        animationToPlay = animationList[0];
                        animResource = animPlayer.GetAnimation(animationToPlay);
                        GD.Print($"[AnimatedModel3DComponent] Animation '{System.IO.Path.GetFileNameWithoutExtension(modelScene.ResourcePath)}' not found in {modelScene.ResourcePath}. Playing first animation: {animationToPlay}");
                    }

                    // Força o loop na animação encontrada
                    if (animResource != null) {
                        animResource.LoopMode = Animation.LoopModeEnum.Linear; // Força o loop linear
                        animPlayer.Play(animationToPlay);
                    }
                    else {
                        GD.PrintErr($"[AnimatedModel3DComponent] Could not retrieve Animation resource '{animationToPlay}' from AnimationPlayer in {modelScene.ResourcePath}.");
                    }
                }
                else {
                    GD.Print($"[AnimatedModel3DComponent] AnimationPlayer found in {modelScene.ResourcePath}, but it has no animations.");
                }
            }
            else {
                GD.Print($"[AnimatedModel3DComponent] No AnimationPlayer found in {modelScene.ResourcePath}.");
            }
        }
        else {
            GD.PrintErr($"[AnimatedModel3DComponent] Failed to instantiate Character Animation scene: {modelScene.ResourcePath}");
        }
    }

    private void DestroyCurrentModel() {
        if (_currentModelInstance != null && IsInstanceValid(_currentModelInstance)) {
            _currentModelInstance.QueueFree();
            _currentModelInstance = null;
        }
    }

    public void SetAnimationState(CharacterAnimationState newState) {
        if (_currentAnimationState != newState) {
            _currentAnimationState = newState;
            UpdateModel();
            NotifyPropertyListChanged();
        }
    }
}