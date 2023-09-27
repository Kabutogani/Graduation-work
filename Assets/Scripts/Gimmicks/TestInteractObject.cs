using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SaveLoader))]
public class TestInteractObject : MonoBehaviour,IInteractable,ILoadableSaveData
{
    private List<string> loadedDatas;
    private List<string> currentDatas;

    public void ChangeDataValue(int localSaveNum , string data)
    {
        SaveLoader saveLoader = this.gameObject.GetComponent<SaveLoader>();
        saveLoader.tempDatas[localSaveNum] = data;
    }

    public void DataLoad(List<string> datas)
    {
        loadedDatas = datas;
        currentDatas = loadedDatas;
    }

    public void OnInteract()
    {
        SaveSystem.Save();
    }

    public void SetDefault()
    {
        ChangeDataValue(0, "new DATA");
    }
}
