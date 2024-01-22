using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor1Key : MonoBehaviour,ILoadableSaveData
{
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
            if(bool.Parse(datas[0])){
                this.gameObject.SetActive(!bool.Parse(datas[0]));
            }
        }else{
            SetDefault();
        }
    }

    public void SetDefault()
    {

    }
}
