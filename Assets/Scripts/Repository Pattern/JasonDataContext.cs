using System.IO;
using System.Threading.Tasks;
using UnityEngine;

public class JsonDataContext : DataContext {
    
    // public GameData data = new GameData(); ---> public List<Item> Items; (GameData)
    public string filePath = "Assets/Data/ItemData.json";
    
    public override async Task Load() {
        // Check if the file exists
        if (!File.Exists(filePath)) {
            Debug.LogWarning("File does not exist at " + filePath);
            return;
        }

        // Read the JSON file asynchronously
        using (var reader = new StreamReader(filePath)) {
            var json = await reader.ReadToEndAsync();
            JsonUtility.FromJsonOverwrite(json, data);
        }
    }

    public override async Task Save() {
        // Serialize data to JSON format
        var json = JsonUtility.ToJson(data, true);

        // Write JSON data to the file asynchronously
        using (var writer = new StreamWriter(filePath)) { // Accessing a data stream
            await writer.WriteAsync(json);
        }

         Debug.Log("Data saved to " + filePath);
    }
}