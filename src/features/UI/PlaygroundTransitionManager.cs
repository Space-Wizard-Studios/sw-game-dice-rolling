using Godot;

namespace DiceRolling.UI;

public enum PlaygroundScenes {
    DiceGenerator,

}
public partial class PlaygroundTransitionManager : Node {
    [Export]
    public PackedScene? DiceGenerator { get; set; }

    public void TransitionTo(PlaygroundScenes scene) {
        switch (scene) {
            case PlaygroundScenes.DiceGenerator:
                GetTree().ChangeSceneToPacked(DiceGenerator);
                break;
        }
    }
}