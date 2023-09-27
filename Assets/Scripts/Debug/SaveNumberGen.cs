using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveNumberGen : MonoBehaviour
{
    SaveLoader[] SaveLoaders;
    // Start is called before the first frame update
    void Start()
    {
        SaveLoaders = SaveSystem.SaveLoaders;
        if(SaveSystem.CurrentLoadSaveDataPath != null && SaveSystem.CurrentLoadSaveDataPath != ""){
            SaveNumberMemoGen();
        }
    }

    void SaveNumberMemoGen(){
        string[] tempDatas = new string[200];
        for(int i = 0; i < SaveLoaders.Length; i++){
            if(SaveLoaders[i] != null){
                for(int n = 0; n < SaveLoaders[i].saveNumbers.Length; n++){
                    tempDatas[SaveLoaders[i].saveNumbers[n]] = SaveLoaders[i].saveNumbers[n] + " : " + SaveLoaders[i].gameObject.name;
                }
            }
        }
        Debug.Log("Saved!!");
        File.WriteAllLines(SaveSystem.CurrentLoadSaveDataPath + "_SaveNumberMemo.txt", tempDatas);
    }
}
