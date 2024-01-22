using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TextMessage))]
public class PuzzleMain : MonoBehaviour,IInteractable
{
    [SerializeField]PuzzleUI puzzleUI;
    [SerializeField]string[] panelNames;
    TextMessage textMessage;

    void Start(){
        puzzleUI = UIMain.instance.PuzzleUI.GetComponent<PuzzleUI>();
    }

    public void OnInteract()
    {
        textMessage = GetComponent<TextMessage>();
        if(!PlayerStateMgr.instance.IsUseUI){
            if(CheckHavePanels()){
                if(puzzleUI.isCleared){
                    textMessage.DialogStart(2);
                }else{
                    textMessage.DialogStart(1);
                }
            }else{
                textMessage.DialogStart(0);
            }
        }
    }

    public bool CheckHavePanels(){
        bool result = false;
        foreach (var i in panelNames)
        {
            if(ItemChecker.CheckItemOnInventory(i)){
                result = true;
            };
        }
        return result;
    }

    public void EnablePuzzle(){
        puzzleUI.SendMessage("OnInteractPuzzle", panelNames);
    }
}
