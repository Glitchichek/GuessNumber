using GuessNumber.Core;
using GuessNumber.Core.Difficulties;
using GuessNumber.Core.Stats;
using GuessNumber.Core.Wallet;
using GuessNumber.Console;
using GuessNumber.Console.Stats;
using GuessNumber.Console.Wallet;

var ui = new ConsoleUi();
var generator = new RandomNumberGenerator();
var game = new Game(generator, ui);

var logger = new ConsoleLogger(ui);
game.GuessMade += logger.OnGuessMade;
game.GameEnded += logger.OnGameEnded;

var statsRepo = new FileStatisticsRepository();
var statsService = new StatisticsService(statsRepo);
var statsView = new StatisticsView(ui, statsRepo);
game.GameEnded += statsService.OnGameEnded;

// Инициализируем кошелек
var walletRepo = new WalletRepository();
var wallet = new CoinWallet(walletRepo.Load());
var walletService = new WalletService(wallet);
var quotesProvider = new RandomQuotesProvider();
game.GameEnded += walletService.OnGameEnded;

bool isRunning = true;

while (isRunning)
{
    ui.WriteLine($"\n ГЛАВНОЕ МЕНЮ (Монет: {wallet.Coins})");
    ui.WriteLine("1. Играть");
    ui.WriteLine("2. Посмотреть статистику");
    ui.WriteLine("3. Купить мотивационную фразу (1 монета)");
    ui.WriteLine("4. Выход");
    ui.Write("Ваш выбор: ");

    var choice = ui.ReadLine();

    switch (choice)
    {
        case "1":
            PlayGame(ui, game);
            walletRepo.Save(wallet.Coins); 
            break;
        case "2":
            statsView.Show();
            break;
        case "3":
            if (wallet.TrySpend(1))
            {
                walletRepo.Save(wallet.Coins);
                ui.WriteLine($"\nВаша цитата:1 {quotesProvider.GetRandomQuote()}\n");
            }
            else
            {
                ui.WriteLine("У вас недостаточно монет! Выиграйте игру, чтобы заработать.");
            }
            break;
        case "4":
            isRunning = false;
            break;
        default:
            ui.WriteLine("Неверный выбор.");
            break;
    }
}

static void PlayGame(IUi ui, Game game)
{
    ui.WriteLine("\nВыберите уровень сложности:");
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
        "4" => GetCustomDifficulty(ui),
        _ => new MediumDifficulty()
    };

    game.Play(difficulty);
}

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