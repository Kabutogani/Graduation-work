using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObj : MonoBehaviour,IInteractable
{
    [SerializeField]private string _itemName; 
    [SerializeField]private GameObject _itemObj;

    public void OnInteract()
    {
        Debug.Log("ItemGet");
        Inventory.instance.AddItemForInventory(_itemName,_itemObj);
        Destroy(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }
    
}
