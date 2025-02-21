using Godot;
using DiceRolling.Dice;
using DiceRolling.Effects;
using DiceRolling.Common;

namespace DiceRolling.Actions;

public interface IActionCategory : IIdentifiable {
    string? Name { get; set; }
    string? Description { get; set; }
    Texture2D? Icon { get; set; }
    string? IconPath { get; }
    Godot.Collections.Array<DiceMana> DefaultRequiredMana { get; set; }
    Godot.Collections.Array<EffectType> DefaultEffects { get; set; }
    void ValidateConstructor();
}