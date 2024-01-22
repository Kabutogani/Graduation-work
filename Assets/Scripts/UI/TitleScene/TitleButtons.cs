using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class TitleButtons : MonoBehaviour
{
    [SerializeField]GameObject _UIparent, _UIBackFade;
    [SerializeField]string[] firstLoadSceneName;
    private int nowLoadingDataNum;

    public void PushButton(GameObject g){
        g.SetActive(true);
        CloseOtherUI(g);
        _UIBackFade.SetActive(true);
    }

    public void CloseUI(GameObject g){
        g.SetActive(false);
        _UIBackFade.SetActive(false);
    }

    void CloseOtherUI(GameObject remaingObj){
        for(int i = 0; i < _UIparent.transform.childCount ;i++){
            GameObject g = _UIparent.transform.GetChild(i).gameObject;
            if(g != remaingObj){
                g.SetActive(false);
            }
        }
    }

    public void PushDataButton(int dataNum){
        nowLoadingDataNum = dataNum;
        if(!SaveSystem.ExistsSaveDataFolder()){
            SaveSystem.CreateSaveDataFolder();
        }
        if(!SaveSystem.ExistsSaveDataFile(dataNum)){
            SaveSystem.CreateSaveDataFile(dataNum);
            WriteNullDatas();
        }
        if(!SaveSystem.ExistsInventoryDataFile(dataNum)){
            SaveSystem.CreateInventoryDataFile(dataNum);
            WriteNullDatas();
        }

        SaveSystem.CurrentLoadSaveDataPath = SaveSystem.GetSaveDataPath(dataNum);
        SaveSystem.CurrentLoadInventoryDataPath = SaveSystem.GetInventoryDataPath(dataNum);
        SaveSystem.CurrentLoadDataNum = dataNum;
        if(SaveSystem.LoadLine(2) != null && SaveSystem.LoadLine(2) != ""){
            if(int.Parse(SaveSystem.LoadLine(2)) >= 4){
                SceneLoader.LoadSceneSingle(firstLoadSceneName[1]);
            }else{
                SceneLoader.LoadSceneSingle(firstLoadSceneName[0]);
            }
        } else{
            SceneLoader.LoadSceneSingle(firstLoadSceneName[0]);
        }
    }

    public void ExitsGame(){
        ExitGame.EndApplication();
    }

    void WriteNullDatas(){
        
    }
}
