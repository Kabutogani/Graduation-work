using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SaveLoader),typeof(TextMessage))]
public class Gakubuti : MonoBehaviour, ILoadableSaveData,IInputableText,IInteractable
{
    private List<string> loadedDatas;
    private List<string> currentDatas;
    [SerializeField] bool isClearEnemy;
    [SerializeField]Enemy pairEnemy;
    [SerializeField]TextAsset nameFile;
    private TextMessage textMessage;
    [SerializeField]string getPanelName;
    [SerializeField]GameObject[] itemObj;

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
        if(!pairEnemy.isDefaultActive){
            if(datas[0] != null && datas[0] != ""){
                if(isClearEnemy){
                    pairEnemy.gameObject.SetActive(false);   
                }
                
            }
        }
        if(isClearEnemy){
            if(pairEnemy.GetComponent<PatrolEnemy>()){
                pairEnemy.GetComponent<PatrolEnemy>().isDead = true;
                pairEnemy.gameObject.SetActive(false);
            }
        }
    }

    public void OnEnterInputField(string inputText)
    {
        string[] nameFileText = TextLoad.TextSplitToLine(TextLoad.Load(nameFile));
        if(CheckZooNames.CheckZooName(nameFileText,inputText)){
            if(pairEnemy.GetComponent<PatrolEnemy>()){
                pairEnemy.GetComponent<PatrolEnemy>().isDead = true;
                pairEnemy.gameObject.SetActive(false);
            }else{
                pairEnemy.ChangeDataValue(0,"false");
                pairEnemy.gameObject.SetActive(false);
            }
            textMessage.DialogStart(2);
            
            ChangeDataValue(0, "true");
            isClearEnemy = true;
            Debug.Log("正解してます");
            Inventory.instance.AddItemForInventory(getPanelName,itemObj[0]);
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
