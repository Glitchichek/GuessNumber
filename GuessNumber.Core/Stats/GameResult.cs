namespace GuessNumber.Core.Stats;

public class GameResult
{
    public DateTime Date { get; set; }
    public bool Won { get; set; }
    public int Attempts { get; set; }
    public string DifficultyName { get; set; } = string.Empty;
}