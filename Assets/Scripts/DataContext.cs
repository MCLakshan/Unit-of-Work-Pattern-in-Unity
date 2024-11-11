using UnityEngine;

public abstract class DataContext : MonoBehaviour {
    public GameData data = new GameData();

    public abstract Item Load();
    public abstract Item Save();
    
}
