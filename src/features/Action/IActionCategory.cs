using Godot;
using DiceRolling.Dice;
using DiceRolling.Effects;

namespace DiceRolling.Actions {
    public interface IActionCategory {
        string Id { get; }
        string? Name { get; set; }
        string? Description { get; set; }
        Texture2D? Icon { get; set; }
        string? IconPath { get; }
        Godot.Collections.Array<DiceMana> DefaultRequiredMana { get; set; }
        Godot.Collections.Array<EffectType> DefaultEffects { get; set; }
    }
}