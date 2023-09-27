using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable, ILoadableSaveData
{
    [SerializeField]
    protected GameObject door;
    [SerializeField]protected bool isActive;
    private List<string> loadedDatas;
    private List<string> currentDatas;

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
            OpenAndClose(bool.Parse(datas[0]));
        }else{
            SetDefault();
        }
    }

    public virtual void OnInteract()
    {   

        OpenAndClose(!isActive);

    }

    void OpenAndClose(bool isOpen){
        door.SetActive(isOpen);
        isActive = isOpen;
        ChangeDataValue(0, isOpen.ToString());
    }

    public virtual void SetDefault(){
        OpenAndClose(true);
    }
}
