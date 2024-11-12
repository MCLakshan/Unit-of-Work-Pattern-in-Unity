using System.Collections.Generic;
using System.IO;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.UI;

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
                
                // Add listener to Buy button with item ID
                int currentItemId = item.ID; // Capture the correct item ID for the button
                Button buyButton = newItemTile.GetComponentInChildren<Button>();
                buyButton.onClick.AddListener(() => BuyItem(currentItemId)); // Pass item ID to BuyItem
            }
        }
    }

    public void BuyItem(int currentItemId)
    {
        // var itemsInJson = await items.GetAllItems();
        //
        //
        // if (itemsInJson != null)
        // {
        //     Debug.Log("itemsInJson not null --> " + itemsInJson.Count);
        // }
        // else
        // {
        //     Debug.Log("itemsInJson is null");
        // }
        
        Debug.Log("Buying item " + currentItemId);
    }
    
}
