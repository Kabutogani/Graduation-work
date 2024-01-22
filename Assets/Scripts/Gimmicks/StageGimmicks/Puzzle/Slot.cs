using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour,IDropHandler
{  
    bool isSubscribed;
    private PlayerInputSet _playerInputSet;
    private bool isDraging;
    public PuzzlePanel nearPuzzlePanel, inSidePuzzlePanel;
    [SerializeField]PuzzleUI puzzleUI;
    public int slotNum;
    
    void OnEnable(){
        if(!isSubscribed){
            _playerInputSet = PlayerInputSet.instance;
            _playerInputSet.ClickDown.Where(x => x == true).Subscribe(x => isDraging = x).AddTo(this);
            _playerInputSet.ClickRelease.Where(x => x == true).Subscribe(x => DragStop()).AddTo(this);
            isSubscribed = true;
        }
    }

    void DragStop(){
        // if(nearPuzzlePanel != null){
        //     if(inSidePuzzlePanel != null){
        //         inSidePuzzlePanel.ResetPanelPos();
        //     }
        //     inSidePuzzlePanel = nearPuzzlePanel;
        //     puzzleUI.PuzzlePanels[slotNum] = inSidePuzzlePanel;
        //     inSidePuzzlePanel.gameObject.GetComponent<RectTransform>().transform.position = this.gameObject.GetComponent<RectTransform>().transform.position;
        // }
    }

    public void OnDrop(PointerEventData eventData)
    {
        if(eventData.pointerDrag.GetComponent<PuzzlePanel>()){
            eventData.pointerDrag.gameObject.GetComponent<RectTransform>().position = this.gameObject.GetComponent<RectTransform>().position;
            if(inSidePuzzlePanel != null){
                inSidePuzzlePanel.ResetPanelPos();
            }
            inSidePuzzlePanel = eventData.pointerDrag.gameObject.GetComponent<PuzzlePanel>();
            puzzleUI.PuzzlePanels[slotNum] = inSidePuzzlePanel;
            inSidePuzzlePanel.nowSlot = this;
            this.gameObject.SetActive(false);
        }
    }

}
