using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDialogGen : MonoBehaviour, IInteractable, IInputableText
{
    [SerializeField]private string _password;
    [SerializeField]private TextAsset[] _textAsset;
    private TextMessage textMessage;

    void Start(){
        textMessage = this.gameObject.GetComponent<TextMessage>();
    }

    public void OnInteract()
    {
        GetComponent<TextMessage>().DialogStart(0);
    }

    public void TestTextEvent(){
        Debug.Log("イベント発生");
    }

    public void NeedPassWord(){
        InputField.instance.InputFieldStart(this.gameObject);
    }

    public void OnEnterInputField(string inputText){
        if(inputText == _password){
            GetComponent<TextMessage>().DialogStart(2);
        }else{
            GetComponent<TextMessage>().DialogStart(1);
        }
    }
}
