namespace GuessNumber.Core.Events;

public class GuessEventArgs : EventArgs
{
    public int Attempt { get; init; }
    public int Guess { get; init; }
    public int SecretNumber { get; init; }
    public bool IsWin { get; init; }
}

public class GameEndedEventArgs : EventArgs
{
    public bool Won { get; init; }
    public int Attempts { get; init; }
    public IDifficulty Difficulty { get; init; } = default!;
    public int SecretNumber { get; init; }
}