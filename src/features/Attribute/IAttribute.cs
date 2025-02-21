using DiceRolling.Common;

namespace DiceRolling.Attributes;

/// <summary>
/// Interface que define um atributo completo no jogo.
/// </summary>
public interface IAttribute :
    IIdentifiable,
    IAttributeInformation,
    IAttributeAssets,
    IAttributeValues { }