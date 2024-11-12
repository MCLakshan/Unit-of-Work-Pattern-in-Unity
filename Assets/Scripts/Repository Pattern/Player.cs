using System.Collections.Generic;

[System.Serializable]
public class Player {
    public string Name;
    public float Money;
    public List<Item> Inventory;

    public Player(string name, int money) {
        Name = name;
        Money = money;
    }
}
