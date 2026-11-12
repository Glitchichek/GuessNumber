using System.Text.Json;
using GuessNumber.Core.Stats;

namespace GuessNumber.Console.Stats;

public class FileStatisticsRepository : IStatisticsRepository
{
    private readonly string _filePath = "stats.json";

    public List<GameResult> Load()
    {
        if (!File.Exists(_filePath)) return new List<GameResult>();
        
        string json = File.ReadAllText(_filePath);
        return JsonSerializer.Deserialize<List<GameResult>>(json) ?? new List<GameResult>();
    }

    public void Save(GameResult result)
    {
        var history = Load();
        history.Add(result);
        
        string json = JsonSerializer.Serialize(history, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(_filePath, json);
    }
}