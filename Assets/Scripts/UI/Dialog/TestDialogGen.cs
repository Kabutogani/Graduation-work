using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDialogGen : MonoBehaviour, IInteractable
{
    [SerializeField]private string _password;
    [SerializeField]private TextAsset[] _textAsset;
    private TextMessage textMessage;

    void Start(){
        textMessage = this.gameObject.GetComponent<TextMessage>();
    }

    public void OnInteract()
    {
        textMessage.textFile = _textAsset[0];
        GetComponent<TextMessage>().DialogStart();
    }

    public void TestTextEvent(){
        Debug.Log("イベント発生");
    }

    public void NeedPassWord(){
        textMessage.DialogStart();
        InputField.instance.InputFieldStart(this.gameObject);
    }

    public void OnEnterInputField(string inputText){
        if(inputText == _password){
            textMessage.textFile = _textAsset[2];
            GetComponent<TextMessage>().DialogStart();
        }else{
            textMessage.textFile = _textAsset[1];
            GetComponent<TextMessage>().DialogStart();
        }
    }
}
