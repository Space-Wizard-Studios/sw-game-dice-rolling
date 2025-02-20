using Godot;

namespace DiceRolling.Characters;

/// <summary>
/// Interface que define os recursos visuais de um personagem no jogo.
/// </summary>
public interface ICharacterAssets {
    /// <summary>
    /// Retrato do personagem.
    /// </summary>
    Texture2D? Portrait { get; set; }

    /// <summary>
    /// Sprite do personagem.
    /// </summary>
    SpriteFrames? CharacterSprite { get; set; }

    /// <summary>
    /// Sprite da sombra do personagem.
    /// </summary>
    SpriteFrames? ShadowSprite { get; set; }

    /// <summary>
    /// Indica se a sombra do personagem deve ser exibida.
    /// </summary>
    bool ShowShadow { get; set; }

    /// <summary>
    /// Posição X do sprite do personagem.
    /// </summary>
    float SpritePositionX { get; set; }

    /// <summary>
    /// Posição Y do sprite do personagem.
    /// </summary>
    float SpritePositionY { get; set; }
}