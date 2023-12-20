using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TextMessage))]
public class SavePoint : MonoBehaviour, IInteractable, ILoadableSaveData
{
    TextMessage textMessage;
    [SerializeField]GameObject loadPlayerSetPoint;
    public int SavePointNum;
    private int loadedSavePointNum;
    public void OnInteract()
    {
        textMessage = GetComponent<TextMessage>();
        textMessage.DialogStart(0);
        Save();
    }

    public void Save(){
        ChangeDataValue(0,SavePointNum.ToString());
        SaveSystem.Save();
        Debug.Log("セーブしました");
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

    public void ChangeDataValue(int localSaveNum, string data)
    {
        SaveLoader saveLoader = this.gameObject.GetComponent<SaveLoader>();
        int i = int.Parse(data);
        string tmpData = i.ToString();
        saveLoader.tempDatas[localSaveNum] = tmpData;
    }

    public void SetDefault()
    {
        
    }
}
