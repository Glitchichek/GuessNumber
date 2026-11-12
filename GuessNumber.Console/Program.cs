using GuessNumber.Core;
using GuessNumber.Core.Difficulties;
using GuessNumber.Core.Stats;
using GuessNumber.Console;
using GuessNumber.Console.Stats;

var ui = new ConsoleUi();
var generator = new RandomNumberGenerator();
var game = new Game(generator, ui);

var logger = new ConsoleLogger(ui);
game.GuessMade += logger.OnGuessMade;
game.GameEnded += logger.OnGameEnded;

var statsRepo = new FileStatisticsRepository();
var statsService = new StatisticsService(statsRepo);
game.GameEnded += statsService.OnGameEnded;

ui.WriteLine("Выберите уровень сложности:");
ui.WriteLine("1 - Легкий (1..10, 5 попыток)");
ui.WriteLine("2 - Средний (1..100, 10 попыток)");
ui.WriteLine("3 - Сложный (1..1000, 15 попыток)");
ui.WriteLine("4 - Свои настройки");
ui.Write("Ваш выбор: ");

var choice = ui.ReadLine();
IDifficulty difficulty = choice switch
{
    "1" => new EasyDifficulty(),
    "2" => new MediumDifficulty(),
    "3" => new HardDifficulty(),
    "4" => GetCustomDifficulty(ui), // Вызываем наш новый метод
    _ => new MediumDifficulty()
};

game.Play(difficulty);

static IDifficulty GetCustomDifficulty(IUi ui)
{
    ui.Write("Введите минимальное число: ");
    int min = int.Parse(ui.ReadLine() ?? "1");

    ui.Write("Введите максимальное число: ");
    int max = int.Parse(ui.ReadLine() ?? "100");

    ui.Write("Введите количество попыток: ");
    int attempts = int.Parse(ui.ReadLine() ?? "10");

    if (min >= max) min = max - 10;
    if (attempts <= 0) attempts = 10;

    return new CustomDifficulty(min, max, attempts);
}