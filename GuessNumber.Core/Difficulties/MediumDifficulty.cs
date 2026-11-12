namespace GuessNumber.Core.Difficulties;

public class MediumDifficulty : IDifficulty
{
    public string Name => "Medium";
    public int Min => 1;
    public int Max => 100;
    public int MaxAttempts => 10;
}