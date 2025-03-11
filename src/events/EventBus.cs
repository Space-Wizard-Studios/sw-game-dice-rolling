using Godot;
using DiceRolling.Entities;
using DiceRolling.Components;

namespace DiceRolling.Events;

[Tool]
public partial class EventBus : Node {
    [Signal] public delegate void ComponentSelectedEventHandler(Node component);
    [Signal] public delegate void ComponentUnselectedEventHandler(Node component);

    private static EventBus? _instance;

    public static EventBus Instance {
        get {
            _instance ??= new EventBus();
            return _instance;
        }
    }

    public override void _Ready() {
        _instance = this;
    }

    public void OnComponentSelected(Node component) {
        EmitSignal(nameof(ComponentSelected), component);

        if (component is SelectableComponent selectableComponent && selectableComponent.GetParent<Entity3D>() is Entity3D parentEntity && parentEntity.Data is { } data) {
            GD.Print("Selected Data ID:", data.Id);
        }
    }

    public void OnComponentUnselected(Node component) {
        EmitSignal(nameof(ComponentUnselected), component);
    }
}