namespace DiceRolling.Interfaces.Attribute;

/// <summary>
/// Interface que define as informações básicas de um atributo.
/// </summary>
public interface IAttributeInformation {
    /// <summary>
    /// Identificador único do atributo.
    /// </summary>
    string Id { get; }

    /// <summary>
    /// Nome do atributo.
    /// </summary>
    string? Name { get; set; }

    /// <summary>
    /// Descrição do atributo.
    /// </summary>
    string? Description { get; set; }
}