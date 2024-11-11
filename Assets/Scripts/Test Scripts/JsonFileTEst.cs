using UnityEngine;
using UnityEngine.Windows;
using System.IO;
using File = System.IO.File;

public class JsonFileTEst : MonoBehaviour
{

    private string filePath = "Assets/Data/ItemData.json";

    void Start() {
        // Load JSON from assets folder
        if (File.Exists(filePath)) {
            Debug.Log("\"" + filePath + "\" exists!");
            
            string json = File.ReadAllText(filePath);
            Debug.Log(json);
            
        }
        else {
            Debug.Log("File does not exist!");
        }
    }
    
}
