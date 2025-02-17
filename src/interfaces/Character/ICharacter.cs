using Godot;
using DiceRolling.Models.Roles;
using DiceRolling.Models.Locations;
using DiceRolling.Models.Characters;

namespace DiceRolling.Interfaces.Character;
/// <summary>
/// Interface que define as propriedades básicas de um personagem no jogo.
/// </summary>
public interface ICharacter {
    /// <summary>
    /// Identificador único do personagem.
    /// </summary>
    string Id { get; set; }

    /// <summary>
    /// Nome do personagem.
    /// </summary>
    string? Name { get; set; }

    /// <summary>
    /// Tipo de personagem.
    /// </summary>
    CharacterType Type { get; set; }

    /// <summary>
    /// Função do personagem.
    /// </summary>
    RoleType? Role { get; set; }

    /// <summary>
    /// Capacidade de dados do personagem.
    /// </summary>
    int DiceCapacity { get; set; }

    /// <summary>
    /// Localização atual do personagem.
    /// </summary>
    LocationType? Location { get; set; }

    /// <summary>
    /// Índice do slot do personagem.
    /// </summary>
    int SlotIndex { get; set; }

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

    /// <summary>
    /// Método para mover o personagem para uma nova localização.
    /// </summary>
    void MoveTo(LocationType newLocation);
}