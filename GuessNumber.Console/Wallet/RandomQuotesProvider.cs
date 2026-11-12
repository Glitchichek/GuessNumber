using GuessNumber.Core.Wallet;

namespace GuessNumber.Console.Wallet;

public class RandomQuotesProvider
{
    private static readonly string[] Quotes =
    {
        "Ты сегодня уже молодец, что вообще запустил(а) эту игру!",
        "Ошибки — это ступеньки, а не стены.",
        "Даже самый маленький шаг двигает тебя вперёд.",
        "Угадать число — это навык. Верить в себя — суперсила.",
        "Сложности — это просто новые уровни.",
        "Тот, кто не сдался, уже победил.",
        "Твоя настойчивость — твой главный козырь.",
        "Не стесняйся проигрывать: так растут чемпионы.",
        "Каждая попытка — инвестиция в будущий успех.",
        "Ты справишься. Я в тебя верю!"
    };

    private readonly Random _random = new();

    public string GetRandomQuote() => Quotes[_random.Next(Quotes.Length)];
}