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

    public void AddItemForInventory(string itemName ,GameObject uiItem){
        GameObject item =  Instantiate(uiItem);
        item.transform.parent = _itemContentParent.transform;
        item.GetComponent<InventoryItem>().ItemName = itemName;
    }

    public string[] GetAllItemInInventory(){
        InventoryItem[] inventoryItem = _itemContentParent.GetComponentsInChildren<InventoryItem>();
        string[] itemNames = new string[200];
        for (int i = 0; i < inventoryItem.Length; i++)
        {
            itemNames[i] = inventoryItem[i].ItemName;
        }
        return itemNames;
    }

    void Start(){
        string[] data = TextLoad.TextSplitToLine(SaveSystem.LoadInventoryDataAll(SaveSystem.CurrentLoadDataNum));
        for(int i = 0; i < data.Length; i++){
            if(data[i] != null && data[i] != ""){
                AddItemForInventory(data[i], _inventoryItemObj);
            }
        }
    }
}
