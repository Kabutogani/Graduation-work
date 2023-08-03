using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using UniRx.Triggers;

public class Dialog : MonoBehaviour
{
    public Text DialogText;
    [SerializeField]private GameObject _dialogObj;
    
    private PlayerInputSet _playerInputSet;

    private int _dialogLength, _dialogPageNum;
    private string[] _spString;
    private GameObject _textEventListener;

    public static Dialog instance;

    void Start()
    {   
        SetDialogActive(false);
        _playerInputSet = PlayerInputSet.instance;
        _playerInputSet.Interact.Where(x => x == true).Subscribe(x => OnInteract());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetDialogActive(bool i){
        _dialogObj.SetActive(i);
    }

    public bool IsActiveDialog(){
        bool i;
        i = _dialogObj.activeInHierarchy;
        return i;
    }

    public void DialogStart(TextAsset textAsset, GameObject textEventListener){
        SetDialogActive(true);
        _textEventListener = textEventListener;
        string allText = TextLoad.Load(textAsset);
        _spString = TextLoad.TextSplitToMessage(allText);
        _dialogLength = _spString.Length;
        _dialogPageNum = 0;
        DialogText.text = TextLoad.TextSplitToMessage(allText)[0];
    }

    public void DialogEnd(){
        if(IsActiveDialog()){ 
            SetDialogActive(false);
        }
    }

    void CheckCommandInText(string text){
        if(text.Contains("[[event:")){
            string eventName = "";
            for (int i = text.IndexOf("[[event:"); i < text.IndexOf("]]"); i++)
            {
                eventName = eventName + text.ToCharArray()[i];
            }
            eventName = eventName.Replace("[[event:", "");
            _textEventListener.SendMessage(eventName);
        }

        if(text.Contains("[end]")){
            DialogEnd();
        }
    }

    void DisplayTextGenerate(){
        string genText = _spString[_dialogPageNum+1];

        if(genText.Contains("[end]")){
            genText = genText.Replace("[end]", "");
        }




        if(genText.Contains("[[event:")){
            string eventName = "";
            for (int i = genText.IndexOf("[[event:"); i < genText.IndexOf("]]"); i++)
            {
                eventName = eventName + genText.ToCharArray()[i];
            }
            genText = genText.Replace(eventName, "");
            genText = genText.Replace("]]", "");
        }

        DialogText.text = genText;
    }

    void TextInEvent(string eventName){

    }

    void NextDialog(){
        if(_dialogPageNum+1 < _dialogLength){
            DisplayTextGenerate();
            CheckCommandInText(_spString[_dialogPageNum]);
            _dialogPageNum++;
        }else{
            //CheckCommandInText(_spString[_dialogPageNum]);
            DialogEnd();
        }
    }

    void OnInteract(){
        NextDialog();
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
