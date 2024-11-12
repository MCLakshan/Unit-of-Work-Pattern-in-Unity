using System.Threading.Tasks;
using UnityEngine;

public class UnitOfWok : MonoBehaviour {
    [SerializeField] private UOWDataContext uowDataContext;
    [SerializeField] private UOWItems uowItems;
    
    public UOWItems items => uowItems;

    public async Task UOWSave() => await uowDataContext.Save();
}
