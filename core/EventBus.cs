using Godot;
using DiceRoll.Components;

namespace DiceRoll.Events;

public partial class EventBus : Node {
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
        if (root == null) {
            GD.PrintErr("Root node not found.");
            return new EventBus();
        }
        var eventBus = root.GetNodeOrNull<EventBus>("/root/EventBus");
        if (eventBus == null) {
            GD.PrintErr("EventBus not found in the scene tree.");
            eventBus = new EventBus();
            root.AddChild(eventBus);
        }
        return eventBus;
    }

    public void OnCharacterInspected(CharacterComponent character) {
        if (Engine.IsEditorHint()) return;
        GD.Print("Character inspection: ", character.Name);
        EmitSignal(nameof(CharacterSelected), character);
    }
}