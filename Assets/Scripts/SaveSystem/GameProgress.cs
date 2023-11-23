using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SaveLoader))]
public class GameProgress : MonoBehaviour, ILoadableSaveData{

    public static GameProgress instance;
    [SerializeField]private int loadedProgressNum;
    private int useSaveLine = 1;


    public void ChangeDataValue(int localSaveNum, string data)
    {
        SaveLoader saveLoader = this.gameObject.GetComponent<SaveLoader>();
        int i = int.Parse(data);
        string tmpData = i.ToString();
        saveLoader.tempDatas[localSaveNum] = tmpData;
        loadedProgressNum = i;
    }

    public void DataLoad(List<string> datas)
    {
        if(datas[useSaveLine] != null && datas[useSaveLine] != ""){
            loadedProgressNum = int.Parse(datas[useSaveLine]);
            Debug.Log("GameProgressをデフォルトではないものに設定");
        }else{
            SetDefault();
            Debug.Log("GameProgressをデフォルト" + loadedProgressNum + "に設定");
        }
    }

    public void SetDefault()
    {
        ChangeDataValue(useSaveLine, 0.ToString());
    }

    void Awake(){
        if(instance == null){
            instance = this;
            DontDestroyOnLoad(gameObject);
        }else{
            Destroy(gameObject);
        }
    }

    public void SetProgressNum(int point){
        if(point > loadedProgressNum){
            if(point - loadedProgressNum > 2){
                Debug.LogWarning("GameProgressが2以上1度に進みました");
            }
            ChangeDataValue(useSaveLine, point.ToString());
        }else{
            Debug.LogError("現在のGameProgressよりも低いProgressを設定しようとしました");
        }
    }

    public bool IsPassedProgress(int progressNum){
        if(progressNum <= loadedProgressNum){
            return true;
        }else{
            return false;
        }
    }

    public bool IsEqualProgress(int progressNum){
        if(progressNum == loadedProgressNum){
            return true;
        }else{
            return false;
        }
    }
}