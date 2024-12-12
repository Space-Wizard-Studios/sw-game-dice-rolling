using Godot;
using DiceRoll.Stores;

namespace DiceRoll.Components;

public enum ForwardDirection {
    Right,
    Left,
}

[Tool]
public partial class CharacterRow : HBoxContainer {
    [Export]
    public CharacterStore? CharacterStore { get; set; }

    [Export]
    public PackedScene? CharacterComponentScene { get; set; }

    [Export]
    public NodePath? Container1Path { get; set; }

    [Export]
    public NodePath? Container2Path { get; set; }

    [Export]
    public NodePath? Container3Path { get; set; }

    [Export]
    public HBoxContainer? RowContainer { get; set; }

    [Export]
    public bool IsEnemy { get; set; } = false;

    private ForwardDirection _direction;

    [Export]
    public ForwardDirection ForwardDirection {
        get => _direction;
        set {
            _direction = value;
            if (_container1 != null && _container2 != null && _container3 != null && RowContainer != null) {
                CallDeferred(nameof(OnDirectionSet));
            }
        }
    }

    private Control? _container1;
    private Control? _container2;
    private Control? _container3;

    public override void _Ready() {
        GD.Print("CharacterRow _Ready called");
        _container1 = GetNode<Control>(Container1Path);
        _container2 = GetNode<Control>(Container2Path);
        _container3 = GetNode<Control>(Container3Path);

        GD.Print($"Container1Path: {Container1Path}");
        GD.Print($"Container2Path: {Container2Path}");
        GD.Print($"Container3Path: {Container3Path}");

        GD.Print($"_container1: {_container1}");
        GD.Print($"_container2: {_container2}");
        GD.Print($"_container3: {_container3}");

        CallDeferred(nameof(OnDirectionSet));
        CallDeferred(nameof(LoadCharacters));
        CallDeferred(nameof(FlipCharacters));
    }

    private void OnDirectionSet() {
        if (RowContainer == null) {
            GD.PrintErr("RowContainer is null");
            return;
        }
        if (ForwardDirection == ForwardDirection.Left) {
            RowContainer.LayoutDirection = LayoutDirectionEnum.Rtl;
        }
        else if (ForwardDirection == ForwardDirection.Right) {
            RowContainer.LayoutDirection = LayoutDirectionEnum.Ltr;
        }

        FlipCharacters();
    }

    private void FlipCharacters() {
        if (_container1 == null || _container2 == null || _container3 == null) {
            GD.PrintErr("One or more containers are null");
            return;
        }
        var characterNodes = new Control[] { _container1, _container2, _container3 };
        foreach (var container in characterNodes) {
            if (container != null && container.GetChildCount() > 0) {
                var characterComponent = container.GetChild<CharacterComponent>(0);
                if (characterComponent != null) {
                    characterComponent.FlipCharacter(ForwardDirection == ForwardDirection.Left);
                }
            }
        }
    }

    private void LoadCharacters() {
        if (CharacterStore == null) {
            GD.PrintErr("CharacterStore is null");
            return;
        }

        if (CharacterComponentScene == null) {
            GD.PrintErr("CharacterComponentScene is null");
            return;
        }

        if (_container1 == null || _container2 == null || _container3 == null) {
            GD.PrintErr("One or more containers are null");
            return;
        }

        var characterNodes = new Control[] { _container1, _container2, _container3 };
        var characters = CharacterStore.Characters;

        for (int i = 0; i < characterNodes.Length; i++) {
            if (characterNodes[i] == null) {
                GD.PrintErr($"Container {i + 1} is null");
                continue;
            }

            if (i < characters.Count) {
                var characterComponent = (CharacterComponent)CharacterComponentScene.Instantiate();
                if (characterComponent == null) {
                    GD.PrintErr("Failed to instantiate CharacterComponent");
                    continue;
                }

                characterComponent.CharacterResource = characters[i];
                characterComponent.IsEnemy = IsEnemy;
                characterNodes[i].AddChild(characterComponent);
            }
        }
    }
}