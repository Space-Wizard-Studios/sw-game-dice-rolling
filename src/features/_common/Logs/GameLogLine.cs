using System;
namespace DiceRolling.Stores;

public enum GameLogLineType
{
    Default,
    Error,
    Info,
    Success,
    Warning,
    Wip,
}

public class GameLogLine
{
    public GameLogLineType Type { get; }
    public string Text { get; }

    public GameLogLine(GameLogLineType type, string text)
    {
        Type = type;
        Text = text ?? throw new ArgumentNullException(nameof(text));
    }
}
