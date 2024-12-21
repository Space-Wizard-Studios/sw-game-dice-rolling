using Godot;
using DiceRoll.Events;
using DiceRoll.Models;

namespace DiceRoll.Components;

[Tool]
public partial class CharacterInspector : HBoxContainer {
    private Character? _character;
    [ExportGroup("🪵 Resources")]
    [Export]
    public Character? Character {
        get => _character;
        set {
            _character = value;
            UpdateCharacterDetails();
        }
    }

    [ExportGroup("🔘 Nodes")]
    [Export] private TextureRect? PortraitNode;
    [Export] private Label? CharacterNameNode;
    [Export] private Label? CharacterRoleNode;
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

    public override void _Ready() {
        // Connect the CharacterSelected signal from EventBus to the OnCharacterSelected method
        EventBus.Instance.Connect(nameof(EventBus.CharacterSelected), new Callable(this, nameof(OnCharacterInspected)));
    }

    private void OnCharacterInspected(Character character) {
        _character = character;
        UpdateCharacterDetails();
    }

    private void UpdateCharacterDetails() {
        GD.Print("Updating character details");

        if (_character == null) {
            GD.PrintErr("Character is null");
            return;
        }

        if (PortraitNode == null) {
            GD.PrintErr("Portrait node is null");
            return;
        }

        if (CharacterNameNode == null) {
            GD.PrintErr("Character name node is null");
            return;
        }

        if (CharacterRoleNode == null) {
            GD.PrintErr("Character role node is null");
            return;
        }

        if (AttributeCurrentValueNode == null) {
            GD.PrintErr("AttributeCurrentValueNode is null");
            return;
        }

        if (AttributeMaxValueNode == null) {
            GD.PrintErr("AttributeMaxValueNode is null");
            return;
        }

        PortraitNode.Texture = _character.Portrait;

        CharacterNameNode.Text = _character?.Name ?? "Unknown";

        CharacterRoleNode.Text = _character?.Role?.Name ?? "Unknown Role";

        if (AttributesListNode != null && AttributeTemplateNode != null) {
            GD.Print("Updating attributes");
            AttributeTemplateNode.Visible = false;

            if (_character == null) return;

            if (_character.Attributes.Count == 0) {
                GD.PrintErr("Character has no attributes:", _character.Name);
                return;
            }

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

                if (titleNode != null) {
                    GD.Print("Attribute type: ", attribute.Type?.Name);
                    titleNode.Text = attribute.Type?.Name ?? "Unknown attribute";
                }

                if (currentValueNode != null) {
                    GD.Print("Current value: ", attribute.CurrentValue);
                    currentValueNode.Text = attribute.CurrentValue.ToString();
                }

                if (maxValueNode != null) {
                    GD.Print("Max value: ", attribute.MaxValue);
                    maxValueNode.Text = attribute.MaxValue.ToString();
                }

                AttributesListNode.AddChild(attributeInstance);
            }
        }
    }
}