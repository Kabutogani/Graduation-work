using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoader : MonoBehaviour
{   
    public int[] saveNumbers;
    [SerializeField]List<string> loadedDatas;
    public List<string> tempDatas;

    void Awake(){
        Debug.Log(saveNumbers.Length);
        Debug.Log(SaveSystem.SaveLoaders.Length);
        
        foreach(int i in saveNumbers){
            if(SaveSystem.SaveLoaders[i] == null){
                SaveSystem.SaveLoaders[i] = this;
            }else{
                Debug.LogError("他のSaveLoaderとセーブの格納行がかぶっています!!", this.gameObject);
            }
        }
    }

    void Start()
    {
        Load();
    }

    void Load(){

        foreach(int i in saveNumbers){
            loadedDatas.Add(SaveSystem.LoadLine(i));
        }

        this.gameObject.SendMessage("DataLoad", loadedDatas);
        tempDatas = loadedDatas;
    }

    public void Save(List<string> data){

    }

    public void Save2(){

    }
}
