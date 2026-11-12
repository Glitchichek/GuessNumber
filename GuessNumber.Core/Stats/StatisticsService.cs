using GuessNumber.Core.Events;

namespace GuessNumber.Core.Stats;

public class StatisticsService
{
    private readonly IStatisticsRepository _repository;

    public StatisticsService(IStatisticsRepository repository)
    {
        _repository = repository;
    }

    public void OnGameEnded(object? sender, GameEndedEventArgs e)
    {
        var result = new GameResult
        {
            Date = DateTime.Now,
            Won = e.Won,
            Attempts = e.Attempts,
            DifficultyName = e.Difficulty.Name
        };
        
        _repository.Save(result);
    }
}