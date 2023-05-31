using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedDoor : Door
{
    [SerializeField] string _keyName;

    public override void OnInteract(){
        if(ItemChecker.CheckItemOnInventory(_keyName)){
            if(isActive){
                door.SetActive(false);
                isActive = false;
            }else{
                door.SetActive(true);
                isActive = true;
            }
        }else{
            Debug.Log("YouHaveNotKey!!");
        }
    }
}
