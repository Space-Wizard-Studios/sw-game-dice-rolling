using Godot;
using System.Collections.Generic;

using DiceRolling.Events;
using DiceRolling.Characters;

namespace DiceRolling.Components.Characters;

[Tool]
public partial class CharacterInspector : HBoxContainer {
    private CharacterType? _character;
    [ExportGroup("🪵 Resources")]
    [Export]
    public CharacterType? Character {
        get => _character;
        set {
            _character = value;
            if (_character is not null) {
                UpdateCharacterDetails();
            }
        }
    }

    [ExportGroup("🔘 Nodes")]
    [Export] private TextureRect? PortraitNode;
    [Export] private Label? CharacterNameNode;
    [Export] private Label? CharacterRoleNode;

    [ExportSubgroup("Attributes")]
    [Export] private VBoxContainer? AttributesListNode;
    [Export] private VBoxContainer? AttributeTemplateNode;
    [Export] private Label? AttributeTemplateTitleNode;
    private string AttributeTitleNodeName => AttributeTemplateTitleNode?.Name ?? "Title";
    [Export] private HBoxContainer? ValueContainerNode;
    private string ValueContainerNodeName => ValueContainerNode?.Name ?? "ValueContainer";
    [Export] private Label? AttributeCurrentValueNode;
    private string AttributeCurrentValueNodeName => AttributeCurrentValueNode?.Name ?? "CurrentValue";
    [Export] private Label? AttributeMaxValueNode;
    private string AttributeMaxValueNodeName => AttributeMaxValueNode?.Name ?? "MaxValue";

    [ExportSubgroup("Actions")]
    [Export] private GridContainer? ActionGridNode;
    [Export] private Button? ActionButtonTemplate;
    private string ButtonTemplateNodeName => ActionButtonTemplate?.Name ?? "ActionButtonTemplate";
    private Dictionary<Button, CharacterAction> _actionButtons = new();

    public override void _Ready() {
        Visible = false;
        EventBus.Instance.Connect(nameof(EventBus.CharacterSelected), new Callable(this, nameof(OnCharacterSelected)));
        EventBus.Instance.Connect(nameof(EventBus.CharacterUnselected), new Callable(this, nameof(OnCharacterUnselected)));
    }

    private void OnCharacterSelected(CharacterComponent characterComponent) {
        _character = characterComponent.Character;
        Visible = true;
        UpdateCharacterDetails();
    }

    private void OnCharacterUnselected() {
        _character = null;
        Visible = false;
    }

    private void UpdateCharacterDetails() {

        if (_character is null) {
            GD.PrintErr("Character is null");
            return;
        }

        if (PortraitNode is null) {
            GD.PrintErr("Portrait node is null.");
            return;
        }

        if (CharacterNameNode is null) {
            GD.PrintErr("Character name node is null");
            return;
        }

        if (CharacterRoleNode is null) {
            GD.PrintErr("Character role node is null");
            return;
        }

        if (AttributeCurrentValueNode is null) {
            GD.PrintErr("AttributeCurrentValueNode is null");
            return;
        }

        if (AttributeMaxValueNode is null) {
            GD.PrintErr("AttributeMaxValueNode is null");
            return;
        }

        PortraitNode.Texture = _character.Portrait;
        CharacterNameNode.Text = _character?.Name ?? "Unknown";
        CharacterRoleNode.Text = _character?.Role?.Name ?? "Unknown Role";

        if (AttributesListNode is not null && AttributeTemplateNode is not null) {
            AttributeTemplateNode.Visible = false;

            if (_character is null) return;

            if (_character.Attributes.Count == 0) {
                GD.PrintErr("Character has no attributes:", _character.Name);
                return;
            }

            // Clear existing action buttons
            foreach (Node child in AttributesListNode.GetChildren()) {
                if (child != AttributeTemplateNode) {
                    child.QueueFree();
                }
            }

            foreach (var attribute in _character.Attributes) {
                var attributeInstance = (VBoxContainer)AttributeTemplateNode.Duplicate();
                attributeInstance.Visible = true;

                var titleNode = attributeInstance.GetNodeOrNull<Label>(AttributeTitleNodeName);
                var valueContainer = attributeInstance.GetNodeOrNull<HBoxContainer>(ValueContainerNodeName);
                var currentValueNode = valueContainer.GetNodeOrNull<Label>(AttributeCurrentValueNodeName);
                var maxValueNode = valueContainer.GetNodeOrNull<Label>(AttributeMaxValueNodeName);

                if (titleNode is not null) {
                    titleNode.Text = attribute.Type?.Name ?? "Unknown attribute";
                }

                if (currentValueNode is not null) {
                    currentValueNode.Text = attribute.CurrentValue.ToString();
                }

                if (maxValueNode is not null) {
                    maxValueNode.Text = attribute.MaxValue.ToString();
                }

                AttributesListNode.AddChild(attributeInstance);
            }
        }

        if (ActionGridNode is not null && ActionButtonTemplate is not null) {
            ActionButtonTemplate.Visible = false;

            if (_character is null) return;

            if (_character.Actions.Count == 0) {
                GD.PrintErr("Character has no actions:", _character.Name);
                return;
            }

            foreach (Node child in ActionGridNode.GetChildren()) {
                if (child != ActionButtonTemplate) {
                    child.QueueFree();
                }
            }

            foreach (var action in _character.Actions) {
                var actionButton = (Button)ActionButtonTemplate.Duplicate();
                actionButton.Visible = true;
                actionButton.Text = action.Name ?? "Unknown Action";
                _actionButtons[actionButton] = action;

                actionButton.Pressed += () => OnActionButtonPressed(actionButton);

                ActionGridNode.CallDeferred("add_child", actionButton);
            }

        }
    }

    private void OnActionButtonPressed(Button button) {
        // GD.Print("Action button pressed: ", button.Text);
        if (_actionButtons.TryGetValue(button, out var action)) {
            if (action.Type?.TargetBoard is not null) {
                // GD.Print("Emitting ActionSelected signal with target configuration: ", action.Type.TargetBoard);
                EventBus.Instance.EmitSignal(nameof(EventBus.ActionSelected), action.Type.TargetBoard);
            }
        }
    }
}