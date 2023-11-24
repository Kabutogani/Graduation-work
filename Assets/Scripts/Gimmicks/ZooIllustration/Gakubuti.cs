using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SaveLoader),typeof(TextMessage))]
public class Gakubuti : MonoBehaviour, ILoadableSaveData,IInputableText,IInteractable
{
    private List<string> loadedDatas;
    private List<string> currentDatas;
    private bool isClearEnemy;
    [SerializeField]Enemy pairEnemy;
    [SerializeField]TextAsset nameFile;
    private TextMessage textMessage;

    void Start(){
        textMessage = GetComponent<TextMessage>();
    }

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
            isClearEnemy = bool.Parse(datas[0]);
        }else{
            SetDefault();
        }
    }

    public void OnEnterInputField(string inputText)
    {
        string[] nameFileText = TextLoad.TextSplitToLine(TextLoad.Load(nameFile));
        if(CheckZooNames.CheckZooName(nameFileText,inputText)){
            textMessage.DialogStart(2);
            pairEnemy.ChangeDataValue(0,"false");
            pairEnemy.gameObject.SetActive(false);
            ChangeDataValue(0, "true");
            isClearEnemy = true;
            Debug.Log("正解してます");
        }else{
            textMessage.DialogStart(3);
            Debug.Log("不正解です");
        }
    }

    public void OnInteract()
    {
        if(GameProgress.instance.loadedProgressNum >= 8){
            if(isClearEnemy){
                textMessage.DialogStart(0);
            }else{
                textMessage.DialogStart(1);
            }
        }else{
            textMessage.DialogStart(4);
        }
        
    }

    public void SetDefault()
    {
        isClearEnemy = false;
    }

    public void InputName(){
        InputField.instance.InputFieldStart(this.gameObject);
    }
}
