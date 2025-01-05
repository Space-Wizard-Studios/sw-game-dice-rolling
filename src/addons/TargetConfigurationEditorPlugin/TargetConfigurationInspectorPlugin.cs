using Godot;
using DiceRoll.Models.Actions.Target;

namespace DiceRoll.Editor;

public partial class TargetConfigurationInspectorPlugin : EditorInspectorPlugin {
    private MatrixControl? matrixControl;
    private CheckBox? flipCheckBox;
    private Button? clearGridButton;

    public override bool _CanHandle(GodotObject @object) {
        return @object is TargetConfiguration;
    }

    public override void _ParseBegin(GodotObject @object) {
        if (@object is TargetConfiguration targetConfiguration) {
            var container = new VBoxContainer();
            AddCustomControl(container);

            // Initialize and add MatrixControl
            matrixControl = new MatrixControl();
            container.AddChild(matrixControl);

            // Add grids to MatrixControl
            foreach (var grid in targetConfiguration.Grids) {
                matrixControl.AddGrid(grid);
            }

            // Add Flip CheckBox
            flipCheckBox = new CheckBox { Text = "Flip Horizontally (preview)" };
            flipCheckBox.Toggled += OnFlipCheckBoxToggled;
            container.AddChild(flipCheckBox);

            // Add Clear Grid Button
            clearGridButton = new Button { Text = "Clear Grid Inputs" };
            clearGridButton.Pressed += OnClearGridButtonPressed;
            container.AddChild(clearGridButton);

            // Add description RichTextLabel
            var descriptionRichTextLabel = new RichTextLabel {
                BbcodeEnabled = true,
                Text = "[b]Possible values on the matrix:[/b]\n" +
                       "[color=white]0 - Ignored[/color]\n" +
                       "[color=yellow]1 - Placement[/color]\n" +
                       "[color=green]2 - Ally[/color]\n" +
                       "[color=red]3 - Enemy[/color]\n",
                SizeFlagsHorizontal = Control.SizeFlags.ExpandFill,
                SizeFlagsVertical = Control.SizeFlags.ExpandFill,
                CustomMinimumSize = new Vector2(0, 80)
            };
            container.AddChild(descriptionRichTextLabel);

            // Connect ConfigurationChanged signal
            if (!targetConfiguration.IsConnected(nameof(TargetConfiguration.ConfigurationChanged), new Callable(this, nameof(OnConfigurationChanged)))) {
                targetConfiguration.Connect(nameof(TargetConfiguration.ConfigurationChanged), new Callable(this, nameof(OnConfigurationChanged)));
            }
        }
    }

    /// <summary>
    /// Called when the target configuration changes.
    /// Updates the MatrixControl with the new configuration.
    /// </summary>
    private void OnConfigurationChanged() {
        // Implementation here
    }

    /// <summary>
    /// Called when the flip checkbox is toggled.
    /// Flips the MatrixControl horizontally based on the checkbox state.
    /// </summary>
    /// <param name="toggled">If set to <c>true</c>, the grid will be flipped horizontally.</param>
    private void OnFlipCheckBoxToggled(bool toggled) {
        matrixControl.FlipHorizontally(toggled);
    }

    /// <summary>
    /// Called when the clear grid button is pressed.
    /// Clears all grid inputs in the MatrixControl.
    /// </summary>
    private void OnClearGridButtonPressed() {
        matrixControl.ClearGridInputs();
    }
}