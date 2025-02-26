using Godot;

namespace DiceRolling.Characters;

/// <summary>
/// Interface que define os recursos visuais de um personagem.
/// </summary>
public interface ICharacterAssetSheet {
    Texture2D? Portrait { get; set; }
    SpriteFrames? CharacterSprite { get; set; }
    SpriteFrames? ShadowSprite { get; set; }
    bool ShowShadow { get; set; }
    float SpritePositionX { get; set; }
    float SpritePositionY { get; set; }
}