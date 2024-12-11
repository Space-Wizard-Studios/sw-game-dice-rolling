using Godot;

namespace DiceRoll.UI {
    [Tool]
    public partial class CloseGameButton : Button {
        public override void _Ready() {
            this.Pressed += OnButtonPressed;
        }

        private void OnButtonPressed() {
            GetTree().Quit();
        }
    }
}