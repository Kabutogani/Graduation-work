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
                Debug.LogError("他のSaveLoaderとセーブの格納行がかぶっています!! 対象 :" + this.gameObject.name, this.gameObject);
                //SaveSystem.SaveLoaders[i] = this;
            }
        }
    }

    void Start()
    {
        Load();
    }

    public void Load(){

        foreach(int i in saveNumbers){
            loadedDatas.Add(SaveSystem.LoadLine(i));
        }
        tempDatas = loadedDatas;
        this.gameObject.SendMessage("DataLoad", loadedDatas);
    }

    public void Save(List<string> data){

    }

    public void Save2(){

    }
}
