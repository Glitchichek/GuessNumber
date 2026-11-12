using GuessNumber.Core;

namespace GuessNumber.Console;

public class ConsoleUi : IUi
{
    public void Write(string text) => System.Console.Write(text);
    public void WriteLine(string text) => System.Console.WriteLine(text);
    public string? ReadLine() => System.Console.ReadLine();
}