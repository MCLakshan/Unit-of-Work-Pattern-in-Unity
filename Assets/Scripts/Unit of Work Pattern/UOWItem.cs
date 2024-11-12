[System.Serializable]
public class UOWItem
{
    public int ID;
    public string Name;
    public float Price;

    public UOWItem(int id, string name, float price)
    {
        ID = id;
        Name = name;
        Price = price;
    }
}
