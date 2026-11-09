namespace GuessNumber.Core;

public class Game
{
    private readonly INumberGenerator _generator;
    private readonly IUi _ui;

    public Game(INumberGenerator generator, IUi ui)
    {
        _generator = generator;
        _ui = ui;
    }

    public void Play()
    {
        int secretNumber = _generator.Next(1, 100);
        
        while (true)
        {
            _ui.Write("Input number from [1; 100]: ");
            string? input = _ui.ReadLine();
            
            if (!int.TryParse(input, out int guess))
            {
                _ui.WriteLine("Wrong input. Please enter a number.");
                continue;
            }

            if (guess < secretNumber)
                _ui.WriteLine("Your number is less");
            else if (guess > secretNumber)
                _ui.WriteLine("Your number is greater");
            else
            {
                _ui.WriteLine("You are win!!!");
                break;
            }
        }
    }
}