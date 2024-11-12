using System.Collections.Generic;
using System.IO;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

[System.Serializable]
public class ItemList
{
    public List<Item> items;
}

public class PopulateShop : MonoBehaviour {
    
    [Header("Player")]
    public Player player = new Player("Player", 1000);

    [Header("Items")] 
    public Items items = null;

    
    [SerializeField] private GameObject itemTilePrefab;  // Reference to the Item Tile Prefab
    [SerializeField] private Transform itemsParent;
    
    public float xOffset = 150f;  // Set this to the width of each tile + desired space between them
    
    // private List<Item> _items = new List<Item>();

    private void Start() {
        // LoadItemsFromJson();
        PopulateUI();
        // BuyItem();
    }

    private async void PopulateUI() {
        int index = 0;
        var itemsInJson = await items.GetAllItems();

        if (itemsInJson != null) {
            foreach (Item item in itemsInJson) {
                // Instantiate the item tile prefab
                GameObject newItemTile = Instantiate(itemTilePrefab, itemsParent);
                
                // Position the tile manually
                RectTransform rectTransform = newItemTile.GetComponent<RectTransform>();
                rectTransform.anchoredPosition = new Vector2(xOffset * index, 0); // Stack tiles horizontally
                index++;
        
                // Access the TMP components inside the prefab
                TextMeshProUGUI itemNameText = newItemTile.transform.Find("Panel/ItemNameText").GetComponent<TextMeshProUGUI>();
                TextMeshProUGUI itemPriceText = newItemTile.transform.Find("Panel/ItemPriceText").GetComponent<TextMeshProUGUI>();
                
                // Set the values in the prefab
                itemNameText.text = item.Name;
                itemPriceText.text = "$" + item.Price.ToString();
            }
        }
    }

    public async void BuyItem()
    {
        var itemsInJson = await items.GetAllItems();

        
        if (itemsInJson != null)
        {
            Debug.Log("itemsInJson not null --> " + itemsInJson.Count);
        }
        else
        {
            Debug.Log("itemsInJson is null");
        }
    }
    
}
