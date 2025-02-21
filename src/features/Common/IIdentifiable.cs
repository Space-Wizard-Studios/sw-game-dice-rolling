using Godot;

namespace DiceRolling.Common;

public interface IIdentifiable {
    string Id { get; }
    Callable GenerateNewIdButton { get; }
}