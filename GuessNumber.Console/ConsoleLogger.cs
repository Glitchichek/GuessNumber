using GuessNumber.Core;
using GuessNumber.Core.Events;

namespace GuessNumber.Console;

public class ConsoleLogger
{
    private readonly IUi _ui;

    public ConsoleLogger(IUi ui) => _ui = ui;

    public void OnGuessMade(object? sender, GuessEventArgs e)
    {
        if (e.IsWin) 
        {
            _ui.WriteLine($"Вы угадали!!! (Попыток: {e.Attempt})");
        }
        else if (e.Guess < e.SecretNumber)
        {
            _ui.WriteLine("Загаданное число больше"); 
        }
        else
        {
            _ui.WriteLine("Загаданное число меньше"); 
        }
    }

    public void OnGameEnded(object? sender, GameEndedEventArgs e)
    {
        if (!e.Won)
        {
            _ui.WriteLine($"Вы проиграли! Загаданное число было: {e.SecretNumber}.");
        }
    }
}