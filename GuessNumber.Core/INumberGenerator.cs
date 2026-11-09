namespace GuessNumber.Core;

public interface INumberGenerator
{
    int Next(int min, int max);
}