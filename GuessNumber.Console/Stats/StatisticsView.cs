using GuessNumber.Core.Stats;
using GuessNumber.Core;

namespace GuessNumber.Console.Stats;

public class StatisticsView
{
    private readonly IUi _ui;
    private readonly IStatisticsRepository _repository;

    public StatisticsView(IUi ui, IStatisticsRepository repository)
    {
        _ui = ui;
        _repository = repository;
    }

    public void Show()
    {
        var history = _repository.Load();
        if (history.Count == 0)
        {
            _ui.WriteLine("Статистика пуста. Сыграйте первую игру!");
            return;
        }

        int wins = history.Count(x => x.Won);
        int losses = history.Count - wins;
        double avgAttempts = history.Average(x => x.Attempts);

        _ui.WriteLine("\n ВАША СТАТИСТИКА ");
        _ui.WriteLine($"Всего игр: {history.Count}");
        _ui.WriteLine($"Побед: {wins}, Поражений: {losses}");
        _ui.WriteLine($"Среднее число попыток: {avgAttempts:F2}");
    }
}