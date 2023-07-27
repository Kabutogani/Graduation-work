using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InputField : MonoBehaviour
{
    [SerializeField]private GameObject _inputFieldObj,_inputFieldObjMain;
    public static InputField instance;
    private GameObject _inputEventListener;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    public void SetInputFieldActive(bool i){
        _inputFieldObj.SetActive(i);
    }

    public bool IsActiveInputField(){
        bool i;
        i = _inputFieldObj.activeInHierarchy;
        return i;
    }

    public void InputFieldStart(GameObject inputEventListener){
        if(Dialog.instance.IsActiveDialog()){
            Dialog.instance.DialogEnd();
        }
        SetInputFieldActive(true);
        _inputFieldObjMain.GetComponent<TMP_InputField>().text = "";
        _inputEventListener = inputEventListener;
        CameraMove.ChangePOVCursorMode(false);
    }

    public void EnterInput(string inputText){
        _inputEventListener.SendMessage("OnEnterInputField", inputText);
        SetInputFieldActive(false);
        CameraMove.ChangePOVCursorMode(true);
    }

    void Awake(){
        if(instance == null){
            instance = this;
            DontDestroyOnLoad(gameObject);
        }else{
            Destroy(gameObject);
        }
    }

}
