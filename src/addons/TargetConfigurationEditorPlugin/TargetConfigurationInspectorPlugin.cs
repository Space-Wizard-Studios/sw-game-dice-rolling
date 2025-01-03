using Godot;
using DiceRoll.Models.Actions.Target;

namespace DiceRoll.Editor;

public partial class TargetConfigurationInspectorPlugin : EditorInspectorPlugin {
    private MatrixControl? matrixControl;

    public override bool _CanHandle(GodotObject @object) {
        return @object is TargetConfiguration;
    }

    public override void _ParseBegin(GodotObject @object) {
        if (@object is TargetConfiguration targetConfiguration) {
            matrixControl = new MatrixControl(targetConfiguration);
            AddCustomControl(matrixControl);
            if (!targetConfiguration.IsConnected(nameof(TargetConfiguration.ConfigurationChanged), new Callable(this, nameof(OnConfigurationChanged)))) {
                targetConfiguration.Connect(nameof(TargetConfiguration.ConfigurationChanged), new Callable(this, nameof(OnConfigurationChanged)));
            }
        }
    }

    public override void _ParseEnd(GodotObject @object) {
        // ! is it ok to leave this out?
        // if (@object is TargetConfiguration targetConfiguration) {
        //     if (targetConfiguration.IsConnected(nameof(TargetConfiguration.ConfigurationChanged), new Callable(this, nameof(OnConfigurationChanged)))) {
        //         targetConfiguration.Disconnect(nameof(TargetConfiguration.ConfigurationChanged), new Callable(this, nameof(OnConfigurationChanged)));
        //     }
        // }
    }

    private void OnConfigurationChanged() {
        if (matrixControl != null && matrixControl.TargetConfiguration is TargetConfiguration targetConfiguration) {
            matrixControl.UpdateDimensions(targetConfiguration.Rows, targetConfiguration.Columns);
            matrixControl.QueueRedraw();
        }
    }
}
