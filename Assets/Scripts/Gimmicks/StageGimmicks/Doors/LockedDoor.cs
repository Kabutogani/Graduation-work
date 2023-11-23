using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TextMessage))]
public class LockedDoor : Door,ILoadableSaveData
{
    private List<string> loadedDatas;
    private List<string> currentDatas;
    [SerializeField] string _keyName;
    [SerializeField] bool isLocked;
    TextMessage textMessage;

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

            isLocked = bool.Parse(datas[0]);

        }else{
            SetDefault();
        }
    }

    public override void OnInteract(){
        textMessage = GetComponent<TextMessage>();

        if(isLocked){
            if(ItemChecker.CheckItemOnInventory(_keyName)){
                ChangeDataValue(0, "false");
                isLocked = false;
                textMessage.DialogStart(1);
            }else{
                textMessage.DialogStart(0);
            }
        }else{
            OpenAndClose(!isActive);
        }
    }

    public void SetDefault()
    {
        isLocked = true;
    }
}
