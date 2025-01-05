using Godot;
using DiceRoll.Models.Characters;
using DiceRoll.Models.Attributes;
using DiceRoll.Components.Characters;

namespace DiceRoll.Events;

[Tool]
public partial class EventBus : Node {
    [Signal] public delegate void AttributeChangedEventHandler();
    [Signal] public delegate void CharacterSelectedEventHandler(CharacterComponent character);
    [Signal] public delegate void CharacterUnselectedEventHandler();

    private static EventBus? _instance;

    public static EventBus Instance {
        get {
            _instance ??= GetInstance();
            return _instance;
        }
    }

    public override void _Ready() {
        GD.Print("EventHandler is ready.");
        _instance = this;
    }

    public override void _Input(InputEvent @event) {
        if (@event.IsActionPressed("ui_cancel")) {
            OnCharacterUnselected();
        }
    }

    private static EventBus GetInstance() {
        var root = (Engine.GetMainLoop() as SceneTree)?.Root;
        if (root is null) {
            GD.PrintErr("Root node not found.");
            return new EventBus();
        }
        var eventBus = root.GetNodeOrNull<EventBus>("/root/EventBus");
        if (eventBus is null) {
            GD.Print("EventBus not found in the scene tree. Creating a new instance.");
            eventBus = new EventBus();
            root.AddChild(eventBus);
        }
        return eventBus;
    }

    public void EmitAttributeChanged(Character character, AttributeType attributeType) {
        EmitSignal(nameof(AttributeChanged), character, attributeType);
    }

    public void OnCharacterSelected(CharacterComponent character) {
        var characterName = character?.Character?.Name ?? "Unknown";
        GD.Print("Character selected: ", characterName);

        if (character is not null) {
            GD.Print("Emitting CharacterSelected signal with character: ", characterName);
            EmitSignal(nameof(CharacterSelected), character);
        }
        else {
            GD.PrintErr("Character is null, cannot emit CharacterSelected signal.");
        }
    }

    public void OnCharacterUnselected() {
        GD.Print("Character unselected");
        EmitSignal(nameof(CharacterUnselected));
    }

}