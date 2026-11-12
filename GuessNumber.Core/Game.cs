using GuessNumber.Core.Events;

namespace GuessNumber.Core;

public class Game
{
    private readonly INumberGenerator _generator;
    private readonly IUi _ui;

    public event EventHandler<GuessEventArgs>? GuessMade;
    public event EventHandler<GameEndedEventArgs>? GameEnded;

    public Game(INumberGenerator generator, IUi ui)
    {
        _generator = generator;
        _ui = ui;
    }

    public void Play(IDifficulty difficulty)
    {
        int secretNumber = _generator.Next(difficulty.Min, difficulty.Max);
        
        for (int attempt = 1; attempt <= difficulty.MaxAttempts; attempt++)
        {
            _ui.Write($"Введите число от [{difficulty.Min}; {difficulty.Max}]: ");
            string? input = _ui.ReadLine();
            
            if (!int.TryParse(input, out int guess))
            {
                _ui.WriteLine("Неверный ввод. Пожалуйста, введите число.");
                attempt--;
                continue;
            }

            bool isWin = guess == secretNumber;

            GuessMade?.Invoke(this, new GuessEventArgs
            {
                Attempt = attempt,
                Guess = guess,
                SecretNumber = secretNumber,
                IsWin = isWin
            });

            if (isWin)
            {
                GameEnded?.Invoke(this, new GameEndedEventArgs
                {
                    Won = true, Attempts = attempt,
                    Difficulty = difficulty, SecretNumber = secretNumber
                });
                return;
            }
        }

        GameEnded?.Invoke(this, new GameEndedEventArgs
        {
            Won = false, Attempts = difficulty.MaxAttempts,
            Difficulty = difficulty, SecretNumber = secretNumber
        });
    }
}