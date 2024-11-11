using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    // Create a Default Player
    [SerializeField] private Player player = new Player("Sam", 1000);

    //Create Test Items
    [SerializeField] private List<Item> items = new List<Item> {
        new Item(1, "item_01", 100),
        new Item(2, "item_02", 150),
        new Item(3, "item_03", 200)
    };
    
    void Start()
    {
        // Example: Printing the items in the inventory
        foreach (var item in items)
        {
            Debug.Log($"Item: {item.Name}, ID: {item.ID}, Price: {item.Price}");
        }
    }

}