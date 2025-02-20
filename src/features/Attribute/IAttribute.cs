namespace DiceRolling.Attributes;

/// <summary>
/// Interface que define um atributo completo no jogo.
/// </summary>
public interface IAttribute :
    IAttributeInformation,
    IAttributeAssets,
    IAttributeValues { }