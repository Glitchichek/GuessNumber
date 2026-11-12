using System.Text.Json;

namespace GuessNumber.Core.Stats;

public class WalletRepository
{
    private readonly string _filePath = "wallet.json";

    public int Load()
    {
        if (!File.Exists(_filePath)) return 0;
        string json = File.ReadAllText(_filePath);
        return JsonSerializer.Deserialize<int>(json);
    }

    public void Save(int coins)
    {
        string json = JsonSerializer.Serialize(coins);
        File.WriteAllText(_filePath, json);
    }
}