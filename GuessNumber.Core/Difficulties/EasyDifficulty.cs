namespace GuessNumber.Core.Difficulties;

public class EasyDifficulty : IDifficulty
{
    public string Name => "Easy";
    public int Min => 1;
    public int Max => 10;
    public int MaxAttempts => 5;
}