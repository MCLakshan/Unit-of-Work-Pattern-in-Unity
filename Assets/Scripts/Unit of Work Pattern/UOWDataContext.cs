using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public abstract class UOWDataContext : MonoBehaviour {
    public UOWGameData data = new UOWGameData(); // public List<Item> Items;

    public abstract Task Load();
    public abstract Task Save();
    
    public List<UOWItem> Set() {
        // if (data != null) {
        //     Debug.Log("return data.Items as List<Item>;");
        // }
        // else {
        //     Debug.Log("Cannot set data as List<Item>;");
        // }
        
        return data.Items;
    }
}
