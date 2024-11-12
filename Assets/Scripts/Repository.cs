using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Repository : MonoBehaviour {
    public JsonDataContext context;
    
    private List<Item> Entities => context.Set();

    public async Task<List<Item>> GetAllItems() {
        await LD();  
        return Entities;  
    }
    
    private async Task LD() {
        await context.Load();
        context.Set();
        
        if (Entities != null) {
            Debug.Log("Entities ---> " + context.data.Items.Count);
        }
    }
    
    public void Add(Item item) {
        Entities.Add(item);
    }

    public void Delete(int id) {
        var item = Entities.Find(x => x.ID == id);
        if (item != null) {
            Entities.Remove(item);
        }
    }

    public async Task Save() {
        await context.Save();
    }
}