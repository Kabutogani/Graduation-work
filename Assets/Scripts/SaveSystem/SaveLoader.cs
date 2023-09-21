using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoader : MonoBehaviour
{   
    [SerializeField]int[] saveNumbers;
    [SerializeField]List<string> loadedDatas;

    void Awake(){
        Debug.Log(saveNumbers.Length);
        Debug.Log(SaveSystem.SaveLoaders.Length);
        
        foreach(int i in saveNumbers){
            if(SaveSystem.SaveLoaders[saveNumbers[i]] == null){
                SaveSystem.SaveLoaders[saveNumbers[i]] = this;
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
            loadedDatas.Add(SaveSystem.LoadLine(saveNumbers[i]));
        }

        this.gameObject.SendMessage("DataLoad", loadedDatas);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
