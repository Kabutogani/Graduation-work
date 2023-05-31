using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;
    public GameObject _itemContentParent,_inventoryItemObj;

    void Awake(){
        if(instance == null){
            instance = this;
        }
    }

    public void AddItemForInventory(string itemName){
        GameObject item =  Instantiate(_inventoryItemObj);
        item.transform.parent = _itemContentParent.transform;
        item.GetComponent<InventoryItem>().ItemName = itemName;
    }
}
