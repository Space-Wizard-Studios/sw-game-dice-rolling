using Godot;

namespace DiceRolling.Actions;

/// <summary>
/// Interface que define os recursos visuais de uma ação no jogo.
/// </summary>
public interface IActionAssets {
    /// <summary>
    /// Ícone da ação.
    /// </summary>
    Texture2D? Icon { get; set; }

    /// <summary>
    /// Caminho do ícone da ação.
    /// </summary>
    string? IconPath { get; }
}