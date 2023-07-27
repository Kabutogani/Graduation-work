using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using UniRx.Triggers;

public class Dialog : MonoBehaviour
{
    public Text DialogText;
    [SerializeField]private TextAsset _assetText;
    [SerializeField]private GameObject _dialogObj;
    
    private PlayerInputSet _playerInputSet;

    private int _dialogLength, _dialogPageNum;
    private string[] spString;

    void Start()
    {
        _dialogObj.SetActive(true);
        DialogStart(_assetText);

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

    string[] TextSplitToLine(string text){
        string[] textArray = TextLoad.TextSplit(text, char.Parse("/n"));
        return textArray;
    }

    string[] TextSplitToMessage(string text){
        string[] textArray = TextLoad.TextSplit(text, "[next]");
        return textArray;
    }

    public void DialogStart(TextAsset textAsset){
        string allText = TextLoad.Load(textAsset);
        spString = TextSplitToMessage(allText);
        _dialogLength = spString.Length;
        _dialogPageNum = 0;
        DialogText.text = TextSplitToMessage(allText)[0];
    }

    public void DialogEnd(){
        if(IsActiveDialog()){ 
            SetDialogActive(false);
        }
    }

    void NextDialog(){
        if(_dialogPageNum+1 < _dialogLength){
            DialogText.text = spString[_dialogPageNum +1];
            _dialogPageNum++;
        }else{
            DialogEnd();
        }
    }

    void OnInteract(){
        NextDialog();
    }
}
