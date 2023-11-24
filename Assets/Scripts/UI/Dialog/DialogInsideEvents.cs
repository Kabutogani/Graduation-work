using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TextMessage))]
public class DialogInsideEvents : MonoBehaviour
{
    [SerializeField]GameObject[] itemObj;
    [SerializeField]Enemy kaniEnemy;
    public void Room001KeyPlaceHint(){
        GameProgress.instance.SetProgressNum(2);
    }

    public void Floor1KeyGet(){
        GameProgress.instance.SetProgressNum(5);
        Inventory.instance.AddItemForInventory("1階の鍵",itemObj[0]);
        kaniEnemy.ChangeDataValue(0,"true");
        kaniEnemy.gameObject.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
