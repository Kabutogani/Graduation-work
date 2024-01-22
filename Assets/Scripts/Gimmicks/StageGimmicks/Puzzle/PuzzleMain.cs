using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleMain : MonoBehaviour,IInteractable
{
    [SerializeField]PuzzleUI puzzleUI;

    void Start(){
        puzzleUI = UIMain.instance.PuzzleUI.GetComponent<PuzzleUI>();
    }

    public void OnInteract()
    {
        if(!PlayerStateMgr.instance.IsUseUI){
            puzzleUI.SendMessage("OnInteractPuzzle");
        }
    }

    
}
