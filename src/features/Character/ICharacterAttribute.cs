using DiceRolling.Attributes;

namespace DiceRolling.Characters;
/// <summary>
/// Interface que define os atributos de um personagem no jogo.
/// </summary>
public interface ICharacterAttributes {
    /// <summary>
    /// Lista de atributos da personagem.
    /// </summary>
    Godot.Collections.Array<CharacterAttribute> Attributes { get; }

    /// <summary>
    /// Inicializa os atributos da personagem.
    /// </summary>
    void InitializeAttributes();

    /// <summary>
    /// Obtém o valor atual de um atributo.
    /// </summary>
    /// <param name="type">Tipo do atributo.</param>
    /// <returns>Valor atual do atributo.</returns>
    int GetAttributeCurrentValue(AttributeType type);

    /// <summary>
    /// Obtém o valor máximo de um atributo.
    /// </summary>
    /// <param name="type">Tipo do atributo.</param>
    /// <returns>Valor máximo do atributo.</returns>
    int GetAttributeMaxValue(AttributeType type);

    /// <summary>
    /// Obtém o valor base de um atributo.
    /// </summary>
    /// <param name="type">Tipo do atributo.</param>
    /// <returns>Valor base do atributo.</returns>
    int GetAttributeBaseValue(AttributeType type);

    /// <summary>
    /// Atualiza o valor atual de um atributo.
    /// </summary>
    /// <param name="type">Tipo do atributo.</param>
    /// <param name="newValue">Novo valor do atributo.</param>
    void UpdateAttributeCurrentValue(AttributeType type, int newValue);

    // TODO: Implementar eventos para notificar a mudança de atributos.

}

