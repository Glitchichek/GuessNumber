namespace GuessNumber.Core.Difficulties;

public class CustomDifficulty : IDifficulty
{
    public string Name => "Custom";
    public int Min { get; }
    public int Max { get; }
    public int MaxAttempts { get; }

    public CustomDifficulty(int min, int max, int maxAttempts)
    {
        Min = min;
        Max = max;
        MaxAttempts = maxAttempts;
    }
}