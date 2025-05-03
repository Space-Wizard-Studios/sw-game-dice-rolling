using Godot;
using System.Collections.Generic;
using DiceRolling.Events;
using DiceRolling.Characters;
using DiceRolling.Entities; // Required for CharacterEntity
using DiceRolling.Components; // Required for SelectableComponent
using DiceRolling.Helpers; // Required for SignalHelper

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
            // Only update if the new character is not null
            if (_character is not null) {
                UpdateCharacterDetails();
            }
            // If value is null, the inspector might be hidden by OnComponentUnselected
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
        Visible = false; // Start hidden
        // Connect to EventBus signals
        SignalHelper.ConnectSignal(EventBus.Instance, nameof(EventBus.ComponentSelected), this, nameof(OnComponentSelected));
        SignalHelper.ConnectSignal(EventBus.Instance, nameof(EventBus.ComponentUnselected), this, nameof(OnComponentUnselected));
    }

    public override void _ExitTree() {
        // Disconnect signals when the node exits the tree
        SignalHelper.DisconnectSignal(EventBus.Instance, nameof(EventBus.ComponentSelected), this, nameof(OnComponentSelected));
        SignalHelper.DisconnectSignal(EventBus.Instance, nameof(EventBus.ComponentUnselected), this, nameof(OnComponentUnselected));
    }

    private void OnComponentSelected(Node component) {
        // Check if the selected component is a SelectableComponent
        if (component is SelectableComponent selectableComponent) {
            // Try to get the parent Entity3D
            var parentEntity = selectableComponent.GetParentOrNull<Entity3D>();
            // Check if the parent is a CharacterEntity and has CharacterType data
            if (parentEntity is CharacterEntity characterEntity && characterEntity.CharacterData is CharacterType characterData) {
                // Update the inspector with the character data
                this.Character = characterData; // Use the existing setter which calls UpdateCharacterDetails
                Visible = true; // Make the inspector visible
                return; // Exit early as we found our character
            }
        }

        // If the selected component is not a character or something went wrong,
        // ensure the inspector is hidden if it wasn't already showing a character.
        // This prevents hiding if the user clicks something else while a character is selected.
        // The deselection logic is handled in OnComponentUnselected.
    }

    // Renamed for clarity to match the signal name
    private void OnComponentUnselected(Node component) {
        // Check if the component being unselected is the one currently displayed
        if (component is SelectableComponent selectableComponent) {
            var parentEntity = selectableComponent.GetParentOrNull<Entity3D>();
            // Check if the parent is a CharacterEntity and its data matches the currently displayed character
            if (parentEntity is CharacterEntity characterEntity && characterEntity.CharacterData == this.Character) {
                // Clear the character and hide the inspector
                this.Character = null; // Set internal character to null
                Visible = false;      // Hide the inspector panel
            }
        }
    }


    private void UpdateCharacterDetails() {

        if (_character is null) {
            // Don't print error if null, just ensure it's hidden (handled by selection logic)
            Visible = false;
            return;
        }

        // Null checks for required nodes
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
        // ... (keep other essential node checks)

        // Update basic info
        PortraitNode.Texture = _character.Portrait;
        CharacterNameNode.Text = _character.Name ?? "Unknown";
        CharacterRoleNode.Text = _character.Role?.Name ?? "Unknown Role";

        // Update Attributes
        if (AttributesListNode is not null && AttributeTemplateNode is not null) {
            AttributeTemplateNode.Visible = false; // Hide template

            // Clear existing attribute entries (except template)
            foreach (Node child in AttributesListNode.GetChildren()) {
                if (child != AttributeTemplateNode) {
                    child.QueueFree();
                }
            }

            if (_character.Attributes.Count == 0) {
                GD.Print("Character has no attributes:", _character.Name);
                // Optionally display a message like "No Attributes"
            }
            else {
                foreach (var attribute in _character.Attributes) {
                    var attributeInstance = (VBoxContainer)AttributeTemplateNode.Duplicate();
                    attributeInstance.Visible = true;

                    var titleNode = attributeInstance.GetNodeOrNull<Label>(AttributeTitleNodeName);
                    var valueContainer = attributeInstance.GetNodeOrNull<HBoxContainer>(ValueContainerNodeName);
                    var currentValueNode = valueContainer?.GetNodeOrNull<Label>(AttributeCurrentValueNodeName);
                    var maxValueNode = valueContainer?.GetNodeOrNull<Label>(AttributeMaxValueNodeName);

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
        }
        else {
            GD.PrintErr("AttributesListNode or AttributeTemplateNode is null.");
        }

        // Update Actions
        if (ActionGridNode is not null && ActionButtonTemplate is not null) {
            ActionButtonTemplate.Visible = false; // Hide template

            // Clear existing action buttons and disconnect signals
            foreach (var button in _actionButtons.Keys) {
                if (IsInstanceValid(button)) { // Check if button is still valid before disconnecting/freeing
                    if (button.IsConnected(Button.SignalName.Pressed, Callable.From(() => OnActionButtonPressed(button)))) {
                        button.Pressed -= () => OnActionButtonPressed(button);
                    }
                    button.QueueFree();
                }
            }
            _actionButtons.Clear(); // Clear the dictionary


            if (_character.Actions.Count == 0) {
                GD.Print("Character has no actions:", _character.Name);
                // Optionally display a message like "No Actions"
            }
            else {
                foreach (var action in _character.Actions) {
                    if (action?.Type == null) continue; // Skip if action or type is null

                    var actionButton = (Button)ActionButtonTemplate.Duplicate();
                    actionButton.Visible = true;
                    actionButton.Text = action.Type.Name ?? "Unknown Action";
                    _actionButtons[actionButton] = action; // Add to dictionary

                    // Connect the Pressed signal
                    actionButton.Pressed += () => OnActionButtonPressed(actionButton);

                    ActionGridNode.AddChild(actionButton); // Use AddChild directly if CallDeferred is not needed
                }
            }
        }
        else {
            GD.PrintErr("ActionGridNode or ActionButtonTemplate is null.");
        }

        // Ensure inspector is visible after updating details for a valid character
        Visible = true;
    }

    private void OnActionButtonPressed(Button button) {
        if (IsInstanceValid(button) && _actionButtons.TryGetValue(button, out var action)) {
            GD.Print($"Action button pressed: {button.Text}, Action: {action.Type?.Name}");
            if (action.Type?.TargetBoard is not null) {
                GD.Print("Emitting ActionSelected signal with target configuration: ", action.Type.TargetBoard);
                EventBus.Instance.EmitActionSelected(action.Type.TargetBoard);
            }
            else {
                GD.Print("Action has no target board configured.");
            }
        }
        else {
            GD.PrintErr("Pressed button not found in action dictionary or is invalid.");
        }
    }
}