namespace GuessNumber.Core.Difficulties;

public class HardDifficulty : IDifficulty
{
    public string Name => "Hard";
    public int Min => 1;
    public int Max => 1000;
    public int MaxAttempts => 15;
}