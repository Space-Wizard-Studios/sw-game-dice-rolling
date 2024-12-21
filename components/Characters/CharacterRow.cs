using Godot;
using DiceRoll.Stores;

namespace DiceRoll.Components;

public enum ForwardDirection {
    Right,
    Left,
}

[Tool]
public partial class CharacterRow : HBoxContainer {

    [ExportGroup("🪵 Resources")]
    [Export] public CharacterStore? CharacterStore { get; set; }
    [Export] public PackedScene? CharacterComponentScene { get; set; }

    [ExportGroup("🏳️ Flags")]
    private bool _isEnemy;
    [Export]
    public bool IsEnemy {
        get => _isEnemy;
        set {
            _isEnemy = value;
            if (GroupLabel != null) {
                CallDeferred(nameof(OnGroupLabelSet));
            }
        }
    }

    private ForwardDirection _direction;
    [Export]
    public ForwardDirection ForwardDirection {
        get => _direction;
        set {
            _direction = value;
            if (Container1Node != null && Container2Node != null && Container3Node != null && RowContainerNode != null) {
                OnDirectionSet();
            }
        }
    }

    [ExportGroup("🔘 Nodes")]
    [Export] public HBoxContainer? RowContainerNode { get; set; }
    [Export] public Control? Container1Node;
    [Export] public Control? Container2Node;
    [Export] public Control? Container3Node;
    [Export] public Control? GroupNameRotationNode;
    [Export] public Label? GroupLabel;

    public override void _Ready() {
        OnDirectionSet();
        LoadCharacters();
        FlipCharacters();
        OnGroupLabelSet();
    }

    private void OnGroupLabelSet() {
        if (GroupLabel != null) {
            GroupLabel.Text = IsEnemy ? "Enemy" : "Player";
        }
    }

    private void OnDirectionSet() {
        if (RowContainerNode == null) {
            GD.PrintErr("RowContainer is null");
            return;
        }
        if (ForwardDirection == ForwardDirection.Left) {
            RowContainerNode.LayoutDirection = LayoutDirectionEnum.Rtl;
            GroupNameRotationNode?.SetRotationDegrees(-90);
        }
        else if (ForwardDirection == ForwardDirection.Right) {
            RowContainerNode.LayoutDirection = LayoutDirectionEnum.Ltr;
            GroupNameRotationNode?.SetRotationDegrees(90);
        }

        FlipCharacters();
    }

    private void FlipCharacters() {
        if (Container1Node == null || Container2Node == null || Container3Node == null) {
            GD.PrintErr("One or more containers are null");
            return;
        }
        var characterNodes = new Control[] { Container1Node, Container2Node, Container3Node };
        foreach (var container in characterNodes) {
            if (container != null && container.GetChildCount() > 0) {
                var characterComponent = container.GetChild<CharacterComponent>(0);
                characterComponent?.FlipSprite(ForwardDirection == ForwardDirection.Left);
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

        if (Container1Node == null || Container2Node == null || Container3Node == null) {
            GD.PrintErr("One or more containers are null");
            return;
        }

        var characterNodes = new Control[] { Container1Node, Container2Node, Container3Node };
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

                characterComponent.Character = characters[i];
                characterComponent.IsEnemy = IsEnemy;
                characterNodes[i].AddChild(characterComponent);
            }
        }
    }
}
