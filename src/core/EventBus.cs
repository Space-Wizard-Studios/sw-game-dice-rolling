using Godot;
using DiceRoll.Components;
using DiceRoll.Models;

namespace DiceRoll.Events;

public partial class EventBus : Node {
    [Signal]
    public delegate void AttributeChangedEventHandler();

    [Signal]
    public delegate void CharacterSelectedEventHandler(CharacterComponent character);

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

    public void OnCharacterInspected(Character character) {
        var characterName = character?.Name ?? "Unknown";
        GD.Print("Character inspection: ", characterName);

        if (character is not null) {
            GD.Print("Emitting CharacterSelected signal with character: ", characterName);
            EmitSignal(nameof(CharacterSelected), character);
        }
        else {
            GD.PrintErr("Character is null, cannot emit CharacterSelected signal.");
        }
    }
}