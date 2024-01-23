using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyReizouko : MonoBehaviour,IInteractable,ILoadableSaveData
{
    private List<string> loadedDatas;
    private List<string> currentDatas;
    private TextMessage textMessage;
    [SerializeField] bool isGotKey;
    [SerializeField] GameObject itemObj;

    public void ChangeDataValue(int localSaveNum, string data)
    {
        SaveLoader saveLoader = this.gameObject.GetComponent<SaveLoader>();
        saveLoader.tempDatas[localSaveNum] = data;
    }

    public void DataLoad(List<string> datas)
    {
        loadedDatas = datas;
        currentDatas = loadedDatas;
        if(datas[0] != null && datas[0] != ""){
            isGotKey = false;
        }else{
            SetDefault();
        }
    }

    public void OnInteract()
    {
        textMessage = GetComponent<TextMessage>();
        if(isGotKey){
            textMessage.DialogStart(1);
        }else{
            textMessage.DialogStart(0);
            ChangeDataValue(0, true.ToString());
            isGotKey = true;
            Inventory.instance.AddItemForInventory("浴室の鍵",itemObj);
            GameProgress.instance.SetProgressNum(3);
        }
    }

    public void SetDefault()
    {
        isGotKey = false;
    }
}
