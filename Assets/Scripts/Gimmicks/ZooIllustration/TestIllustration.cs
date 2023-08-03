using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestIllustration : MonoBehaviour, IInputableText,IInteractable
{
    TextMessage textMessage;
    [SerializeField] GameObject _pairEnemy;
    [SerializeField] TextAsset _nameFile;
    [SerializeField] string _debugEnemyName;

    // Start is called before the first frame update
    void Start()
    {
        textMessage = GetComponent<TextMessage>();
    }

    public void InputName(){
        InputField.instance.InputFieldStart(this.gameObject);
    }

    public void ClearName(){
        _pairEnemy.SetActive(false);
    }

    public void OnEnterInputField(string inputText)
    {   
        //Debug.Log(inputText);
        string[] nameFileText = TextLoad.TextSplitToLine(TextLoad.Load(_nameFile));
        // for (int i = 0; i < nameFileText.Length; i++)
        // {
        //     //Debug.Log(nameFileText[i]);
        // }
        // if(CheckZooNames.CheckZooName(nameFileText, inputText)){
        //     textMessage.DialogStart(2);
        //     ClearName();
        //     Debug.Log("正解してます");
        // }else{
        //     textMessage.DialogStart(1);
        //     Debug.Log("不正解です");
        // }
        if(inputText == _debugEnemyName){
            textMessage.DialogStart(2);
            ClearName();
            Debug.Log("正解してます");
        }else{
            textMessage.DialogStart(1);
            Debug.Log("不正解です");
        }
    }

    public void OnInteract()
    {
        textMessage.DialogStart(0);
    }
}
