using Godot;
using DiceRolling.Helpers;

namespace DiceRolling.Entities;

[Tool]
[GlobalClass]
[Icon("res://assets/editor/entity-3d.svg")]
public abstract partial class Entity3D : Node3D {
    [Signal] public delegate void EntityUpdatedEventHandler();

    private Resource? _data;

    [Export]
    public Resource? Data {
        get => _data;
        set {
            if (_data == value) {
                return;
            }

            // Disconnect from old data if exists
            // SignalHelper.DisconnectSignal(_data, "Changed", this, nameof(OnDataChanged));

            _data = value;

            // Connect to new data if exists
            // SignalHelper.ConnectSignal(_data, "Changed", this, nameof(OnDataChanged));

            NotifyUpdate();
        }
    }

    protected void NotifyUpdate() {
        EmitSignal(nameof(EntityUpdated));
    }

    // Changed from protected to public to allow components to access it
    public T? GetData<T>() where T : Resource {
        return Data as T;
    }

    public override void _Ready() {
        // SignalHelper.ConnectSignal(_data, "Changed", this, nameof(OnDataChanged));
    }

    public override void _ExitTree() {
        // SignalHelper.DisconnectSignal(_data, "Changed", this, nameof(OnDataChanged));
    }

    private void OnDataChanged() {
        NotifyUpdate();
    }
}