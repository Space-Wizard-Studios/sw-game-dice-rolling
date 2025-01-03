using Godot;
using DiceRoll.Models.Actions.Target;

namespace DiceRoll.Editor;

public partial class TargetConfigurationInspectorPlugin : EditorInspectorPlugin {
    private MatrixControl? matrixControl;
    private CheckBox? flipCheckBox;

    public override bool _CanHandle(GodotObject @object) {
        return @object is TargetConfiguration;
    }

    public override void _ParseBegin(GodotObject @object) {
        if (@object is TargetConfiguration targetConfiguration) {
            matrixControl = new MatrixControl(targetConfiguration);
            AddCustomControl(matrixControl);

            var descriptionControl = new Control {
                SizeFlagsHorizontal = Control.SizeFlags.ExpandFill,
                SizeFlagsVertical = Control.SizeFlags.ExpandFill
            };

            var descriptionRichTextLabel = new RichTextLabel {
                BbcodeEnabled = true,
                Text = string.Format(
                    "[b]Possible values on the matrix:[/b]\n" +
                    "[color=white]0 - Whatever[/color]\n" +
                    "[color=yellow]1 - Distance[/color]\n" +
                    "[color=green]2 - Ally[/color]\n" +
                    "[color=red]3 - Enemy[/color]"
                ),
                SizeFlagsHorizontal = Control.SizeFlags.ExpandFill,
                SizeFlagsVertical = Control.SizeFlags.ExpandFill,
                CustomMinimumSize = new Vector2(0, 80)
            };
            AddCustomControl(descriptionRichTextLabel);

            flipCheckBox = new CheckBox { Text = "Flip Horizontally (Preview)" };
            flipCheckBox.Toggled += OnFlipCheckBoxToggled;
            AddCustomControl(flipCheckBox);

            if (!targetConfiguration.IsConnected(nameof(TargetConfiguration.ConfigurationChanged), new Callable(this, nameof(OnConfigurationChanged)))) {
                targetConfiguration.Connect(nameof(TargetConfiguration.ConfigurationChanged), new Callable(this, nameof(OnConfigurationChanged)));
            }
        }
    }

    public override void _ParseEnd(GodotObject @object) {
        // Do not disconnect the signal here to avoid premature disconnection
    }

    private void OnConfigurationChanged() {
        if (matrixControl != null && matrixControl.TargetConfiguration is TargetConfiguration targetConfiguration) {
            matrixControl.UpdateDimensions(targetConfiguration.Rows, targetConfiguration.Columns);
            matrixControl.QueueRedraw();
        }
    }

    private void OnFlipCheckBoxToggled(bool buttonPressed) {
        if (matrixControl != null) {
            matrixControl.FlipHorizontally(buttonPressed);
            matrixControl.QueueRedraw();
        }
    }
}