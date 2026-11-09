using GuessNumber.Core;

namespace GuessNumber.ConsoleApp;

public class RandomNumberGenerator : INumberGenerator
{
    private readonly Random _random = new();
    public int Next(int min, int max) => _random.Next(min, max + 1);
}