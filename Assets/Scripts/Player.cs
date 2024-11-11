using System.Collections.Generic;

[System.Serializable]
public class Player {
    public string Name;
    public int Money;
    public List<Item> Inventory;

    public Player(string name, int money) {
        Name = name;
        Money = money;
        Inventory = new List<Item>();
    }

    public void AddItem(Item item) {
        Inventory.Add(item);
    }
}
