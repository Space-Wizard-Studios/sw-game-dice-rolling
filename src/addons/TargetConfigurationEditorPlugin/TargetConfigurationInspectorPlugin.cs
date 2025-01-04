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
            matrixControl = new MatrixControl();
            AddCustomControl(matrixControl);

            foreach (var grid in targetConfiguration.Grids) {
                matrixControl.AddGrid(grid);
            }

            flipCheckBox = new CheckBox { Text = "Flip Horizontally" };
            flipCheckBox.Toggled += OnFlipCheckBoxToggled;
            AddCustomControl(flipCheckBox);

            var descriptionRichTextLabel = new RichTextLabel {
                BbcodeEnabled = true,
                Text = "[b]Possible values on the matrix:[/b]\n" +
                "[color=white]0 - Ignored[/color]\n" +
                "[color=yellow]1 - Placement[/color]\n" +
                "[color=green]2 - Ally[/color]\n" +
                "[color=red]3 - Enemy[/color]",
                SizeFlagsHorizontal = Control.SizeFlags.ExpandFill,
                SizeFlagsVertical = Control.SizeFlags.ExpandFill,
                CustomMinimumSize = new Vector2(0, 80)
            };

            AddCustomControl(descriptionRichTextLabel);

            if (!targetConfiguration.IsConnected(nameof(TargetConfiguration.ConfigurationChanged), new Callable(this, nameof(OnConfigurationChanged)))) {
                targetConfiguration.Connect(nameof(TargetConfiguration.ConfigurationChanged), new Callable(this, nameof(OnConfigurationChanged)));
            }
        }
    }

    private void OnConfigurationChanged() {
        if (matrixControl != null && matrixControl.TargetConfiguration is TargetConfiguration targetConfiguration) {
            matrixControl.ClearGrids();
            foreach (var grid in targetConfiguration.Grids) {
                matrixControl.AddGrid(grid);
            }
            matrixControl.QueueRedraw();
        }
    }

    private void OnFlipCheckBoxToggled(bool buttonPressed) {
        if (matrixControl != null) {
            matrixControl.FlipHorizontally(buttonPressed);
        }
    }
}