using System.Collections.Generic;

[System.Serializable]
public class UOWPlayer {
    public string Name;
    public float Money;
    public List<UOWItem> Inventory;

    public UOWPlayer(string name, int money) {
        Name = name;
        Money = money;
    }
}
