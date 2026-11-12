using GuessNumber.Core;
using GuessNumber.Core.Difficulties;
using GuessNumber.Console;

var ui = new ConsoleUi();
var generator = new RandomNumberGenerator();
var game = new Game(generator, ui);

var logger = new ConsoleLogger(ui);
game.GuessMade += logger.OnGuessMade;
game.GameEnded += logger.OnGameEnded;

ui.WriteLine("Выберите уровень сложности:");
ui.WriteLine("1 - Легкий (1..10, 5 попыток)");
ui.WriteLine("2 - Средний (1..100, 10 попыток)");
ui.WriteLine("3 - Сложный (1..1000, 15 попыток)");
ui.Write("Ваш выбор: ");

var choice = ui.ReadLine();
IDifficulty difficulty = choice switch
{
    "1" => new EasyDifficulty(),
    "2" => new MediumDifficulty(),
    "3" => new HardDifficulty(),
    _ => new MediumDifficulty()
};

game.Play(difficulty);