using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SaveLoader))]
public class TimeCounter : MonoBehaviour,ILoadableSaveData
{
    public static TimeCounter instance;
    public int playTime;
    private int loadedPlayTime;
    private float count;

    public void ChangeDataValue(int localSaveNum, string data)
    {
        SaveLoader saveLoader = this.gameObject.GetComponent<SaveLoader>();
        int i = int.Parse(data) + loadedPlayTime;
        string tmpData = i.ToString();
        saveLoader.tempDatas[localSaveNum] = tmpData;
        loadedPlayTime = i;
    }

    public void DataLoad(List<string> datas)
    {
        playTime = 0;
        if(datas[0] != null && datas[0] != ""){
            loadedPlayTime = int.Parse(datas[0]);
        }else{
            SetDefault();
        }
    }

    public void SetDefault()
    {
        ChangeDataValue(0, 1.ToString());
    }

    void Awake(){
        if(instance == null){
            instance = this;
            DontDestroyOnLoad(gameObject);
        }else{
            Destroy(gameObject);
        }
    }

    void Update()
    {   
        count = count + Time.deltaTime;
        if(count >= 1){
            playTime++;
            count = 0f;
        }
    }

    public void SetTime(){
        ChangeDataValue(0, playTime.ToString());
        playTime = 0;
    }

}
