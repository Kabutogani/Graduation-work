using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ItemChecker
{
    public static bool CheckItemOnInventory(string itemName){
        bool b = false;
        GameObject itemContentParent = Inventory.instance._itemContentParent;
        
        for(int i = 0; i < itemContentParent.transform.childCount; i++){
            if(itemContentParent.transform.childCount == 0){
                b = false;
                break;
            }
            if(itemContentParent.transform.GetChild(i).GetComponent<InventoryItem>().ItemName == itemName){
                b = true;
            }       
        }

        return b;
    }
}
