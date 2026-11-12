namespace GuessNumber.Core.Stats;

public interface IStatisticsRepository
{
    List<GameResult> Load();
    void Save(GameResult result);
}