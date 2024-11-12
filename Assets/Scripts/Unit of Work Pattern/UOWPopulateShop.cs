using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using TMPro;
using UnityEngine.Serialization;
using UnityEngine.UI;
using System.Collections;

public class UOWPopulateShop : MonoBehaviour {
    
    [Header("Player")]
    public UOWPlayer player = new UOWPlayer("Player_001", 1000);

    // [Header("Items")] 
    // public UOWItems items = null;

    [Header("Tile Settings")]
    [SerializeField] private GameObject itemTilePrefab;  // Reference to the Item Tile Prefab
    [SerializeField] private Transform itemsParent;
    public float xOffset = 150f;  // Set this to the width of each tile + desired space between them

    [Header("Player UI Settings")]
    [SerializeField] private TextMeshProUGUI playerNameText;
    [FormerlySerializedAs("playerMoneyText")] 
    [SerializeField] private TextMeshProUGUI playerMoneyAmountText;
    
    [Header("Unit of Work Settings")]
    public UnitOfWok unitOfWok;
    
    private void Start() {
        PopulateUI();
    }

    private async void PopulateUI() {
        int index = 0;
        var itemsInJson = await unitOfWok.items.GetAllItems();

        if (itemsInJson != null) {
            foreach (UOWItem item in itemsInJson) {
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
                // Add a listener to the button to call the async wrapper
                buyButton.onClick.AddListener(() => StartCoroutine(BuyItemWrapper(currentItemId)));
            }
        }
        
        // Player UI
        playerNameText.text = player.Name;
        playerMoneyAmountText.text = player.Money.ToString();
    }
    
    // Async Wrapper as a Coroutine
    private IEnumerator BuyItemWrapper(int itemId)
    {
        yield return BuyItem(itemId); // Waits for async method to complete
    }

    public async Task BuyItem(int currentItemId)
    {
        Debug.Log("Buying item " + currentItemId);
        
        float price = unitOfWok.items.GetPrice(currentItemId);
        if (player.Money < price) {
            Debug.Log("Not enough money");
        }
        else {
            player.Money -= price;
            unitOfWok.items.Delete(currentItemId);
            // await items.Save();
            await unitOfWok.UOWSave();
            ClearTiles();
            PopulateUI();
        }
        
    }

    public void ClearTiles() {
        foreach (Transform child in itemsParent) {
            Destroy(child.gameObject);
        }
    }
    
}
