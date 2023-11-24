using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TextMessage))]
public class DialogInsideEvents : MonoBehaviour
{
    [SerializeField]GameObject[] itemObj;
    [SerializeField]Enemy enemy;
    public void Room001KeyPlaceHint(){
        GameProgress.instance.SetProgressNum(2);
    }

    public void MonoOkiKeyGet(){
        GameProgress.instance.SetProgressNum(5);
        Inventory.instance.AddItemForInventory("物置の鍵",itemObj[0]);
        enemy.ChangeDataValue(0,"true");
        enemy.gameObject.SetActive(true);
        this.gameObject.SetActive(false);
    }

    public void Floor1KeyGet(){
        GameProgress.instance.SetProgressNum(6);
        Inventory.instance.AddItemForInventory("1階の鍵",itemObj[0]);
        this.gameObject.SetActive(false);
    }

    public void GakubutiUnlock(){
        if(GameProgress.instance.IsEqualProgress(6)){
            GameProgress.instance.SetProgressNum(7);
            enemy.ChangeDataValue(0,"true");
            enemy.gameObject.SetActive(true);
        }
    }
}
