[System.Serializable]
public class Item
{
    public int ID;
    public string Name;
    public float Price;

    public Item(int id, string name, float price)
    {
        ID = id;
        Name = name;
        Price = price;
    }
}
