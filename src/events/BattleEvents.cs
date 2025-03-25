using Godot;
using DiceRolling.Characters;
using DiceRolling.Actions;

namespace DiceRolling.Controllers;

public partial class BattleEvents : Node {
    private static BattleEvents? _instance;

    public static BattleEvents Instance {
        get {
            if (_instance == null) {
                // Try to get from the scene tree first
                if (Engine.GetMainLoop() is SceneTree tree) {
                    _instance = tree.Root.GetNodeOrNull<BattleEvents>("/root/BattleEvents");
                }

                // If not found, create a new instance
                _instance ??= new BattleEvents();
            }
            return _instance;
        }
    }

}