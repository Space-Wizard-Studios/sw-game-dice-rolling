namespace DiceRolling.Interfaces.Role;

/// <summary>
/// Interface que define um arquétipo de personagem completo no jogo.
/// </summary>
public interface IRole :
    IRoleInformation,
    IRoleAttributes,
    IRoleActions { }