namespace GuessNumber.Core;

public interface IUi
{
    void Write(string text);
    void WriteLine(string text);
    string? ReadLine();
}