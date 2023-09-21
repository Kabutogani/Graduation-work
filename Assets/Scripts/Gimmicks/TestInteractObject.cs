using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SaveLoader))]
public class TestInteractObject : MonoBehaviour,IInteractable,ILoadableSaveData
{
    private List<string> loadedDatas;

    public void DataLoad(List<string> datas)
    {
        loadedDatas = datas;
        Debug.Log("OnLoad");
    }

    public void OnInteract()
    {
        Debug.Log(loadedDatas[0]);
    }
}
