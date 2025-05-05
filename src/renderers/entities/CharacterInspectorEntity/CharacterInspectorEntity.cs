using Godot;
using DiceRolling.Events;
using DiceRolling.Characters;
using DiceRolling.Components;

namespace DiceRolling.Entities;

[Tool]
[GlobalClass]
public partial class CharacterInspectorEntity : EntityControl {

    [ExportGroup("Preview")]
    [Export] public CharacterType? PreviewCharacterData { get; set; }

    // Add this button property
    [ExportToolButton("Update Preview")]
    public Callable UpdatePreviewData => Callable.From(() => {
        // Ensure data reflects preview in editor before notifying
        if (Engine.IsEditorHint()) {
            if (Data != PreviewCharacterData) {
                Data = PreviewCharacterData; // This already calls NotifyUpdate via the setter
            }
            else {
                // If data hasn't changed, force notify to refresh children
                NotifyUpdate();
            }
            Visible = Data != null;
        }
        else {
            // Optionally do nothing or just notify if needed at runtime
            NotifyUpdate();
        }
    });

    public CharacterType? InspectedCharacterData => GetData<CharacterType>();

    public override void _Ready() {
        // If running in the editor and a preview character is set, use it for initial display
        if (Engine.IsEditorHint()) {
            if (PreviewCharacterData != null && Data != PreviewCharacterData) {
                Data = PreviewCharacterData; // Set internal data for preview
                Visible = true; // Ensure visible in editor if preview data exists
            }
            else if (PreviewCharacterData == null) {
                Data = null; // Clear data if preview is cleared
                Visible = false; // Hide if no preview data
            }
            // Don't connect to runtime signals in the editor
        }
        else {
            // Runtime logic: Hide initially and connect to signals
            Visible = false;
            if (EventBus.Instance != null) { // Ensure EventBus exists at runtime
                EventBus.Instance.ComponentSelected += OnComponentSelected;
                EventBus.Instance.ComponentUnselected += OnComponentUnselected;
            }
            else {
                GD.PrintErr("EventBus instance not found at runtime.");
            }
        }
    }

    public override void _ExitTree() {
        // Only disconnect signals if running outside the editor
        if (!Engine.IsEditorHint() && EventBus.Instance != null) {
            EventBus.Instance.ComponentSelected -= OnComponentSelected;
            EventBus.Instance.ComponentUnselected -= OnComponentUnselected;
        }
    }

    private void OnComponentSelected(Node component) {
        CharacterType? newCharacterData = null;

        if (component is SelectableComponent selectableComponent) {
            var parentEntity = selectableComponent.GetParentOrNull<Entity3D>();
            if (parentEntity is CharacterEntity characterEntity && characterEntity.CharacterData is CharacterType characterData) {
                newCharacterData = characterData;
            }
        }

        // Use the inherited Data property and let its setter call NotifyUpdate (which emits EntityUpdated)
        if (Data != newCharacterData) {
            Data = newCharacterData; // This will emit EntityUpdated
            Visible = Data != null; // Show if data is not null, hide otherwise

            if (Data != null) {
                GD.Print($"CharacterInspectorEntity: Selected {((CharacterType)Data).Name}");
            }
            else {
                GD.Print($"CharacterInspectorEntity: Selection cleared.");
            }
        }
    }

    private void OnComponentUnselected(Node component) {
        if (component is SelectableComponent selectableComponent) {
            // Still need to check the 3D parent for the source of the deselection
            var parentEntity = selectableComponent.GetParentOrNull<Entity3D>();
            // Check if the unselected component's character is the one currently inspected
            if (parentEntity is CharacterEntity characterEntity && characterEntity.CharacterData == Data) {
                // Only clear if the *currently inspected* character is unselected
                if (Data != null) {
                    GD.Print($"CharacterInspectorEntity: Unselected {((CharacterType)Data).Name}");
                    Data = null; // This will emit EntityUpdated
                    Visible = false; // Hide when unselected
                }
            }
        }
    }
}