using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FloorExit : MonoBehaviour, ILoadableSaveData
{
    [SerializeField]GameObject loadPlayerSetPoint;
    public int SavePointNum, NextFloorSavePointNum;
    private int loadedSavePointNum;
    [SerializeField]string nextFloorSceneName;

    public void ChangeDataValue(int localSaveNum, string data)
    {
        SaveLoader saveLoader = this.gameObject.GetComponent<SaveLoader>();
        int i = int.Parse(data);
        string tmpData = i.ToString();
        saveLoader.tempDatas[localSaveNum] = tmpData;
    }

    public void DataLoad(List<string> datas)
    {
        if(datas[0] != null && datas[0] != ""){
            loadedSavePointNum = int.Parse(datas[0]);
            if(loadedSavePointNum == SavePointNum){
                PlayerStateMgr.instance.gameObject.transform.position = loadPlayerSetPoint.transform.position;
            }
        }else{
            SetDefault();
        }
    }

    public void SetDefault()
    {
        
    }

    public void Save(){
        ChangeDataValue(0,NextFloorSavePointNum.ToString());
        SaveSystem.Save();
        Debug.Log("セーブしました");
    }

    public void AreaEvent(){
        Save();
        Debug.Log("FloorExitに触れた");
        SceneLoader.LoadSceneSingle(nextFloorSceneName);
    }
}
