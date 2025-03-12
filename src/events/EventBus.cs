using Godot;
using DiceRolling.Entities;
using DiceRolling.Components;

namespace DiceRolling.Events;

[Tool]
public partial class EventBus : Node {
    private static EventBus? _instance;

    [Signal] public delegate void ComponentSelectedEventHandler(Node component);
    [Signal] public delegate void ComponentUnselectedEventHandler(Node component);

    public static EventBus Instance {
        get {
            if (_instance == null) {
                // Tenta obter do Autoload primeiro (quando em cena)
                if (Engine.GetMainLoop() is SceneTree tree) {
                    _instance = tree.Root.GetNodeOrNull<EventBus>("/root/EventBus");
                }

                // Se não encontrar na árvore, cria uma nova instância
                _instance ??= new EventBus();
            }
            return _instance;
        }
    }

    public override void _Ready() {
        _instance = this;
    }

    public void OnComponentSelected(Node component) {
        EmitSignal(nameof(ComponentSelected), component);

        if (component is SelectableComponent selectableComponent &&
            selectableComponent.GetParent<Entity3D>() is Entity3D parentEntity &&
            parentEntity.Data is { } data) {
            GD.Print("Selected Data ID:", data.Id);
        }
    }

    public void OnComponentUnselected(Node component) {
        EmitSignal(nameof(ComponentUnselected), component);
    }
}