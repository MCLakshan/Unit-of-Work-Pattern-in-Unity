using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;


public class PopulateShop : MonoBehaviour {
    [SerializeField] private GameObject itemTilePrefab;  // Reference to the Item Tile Prefab
    [SerializeField] private Transform itemsParent;
    
    private List<Item> items = new List<Item>();

    private void Start() {
        LoadItemsFromJson();
        PopulateUI();
    }

    private void LoadItemsFromJson() {
        string filePath = "Assets/Data/ItemData.json";

        if (File.Exists(filePath)) {
            string json = File.ReadAllText(filePath);
        }
    }
}
