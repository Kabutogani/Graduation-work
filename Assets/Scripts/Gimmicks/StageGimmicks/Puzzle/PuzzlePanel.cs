using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PuzzlePanel : MonoBehaviour,IDragHandler, IDropHandler,IEndDragHandler
{  
    bool isSubscribed;
    private PlayerInputSet _playerInputSet;
    private bool isDraging;
    public int PanelNum;
    [SerializeField]Vector3 DefaultTransform;
    public Slot nowSlot;
    public PuzzleUI puzzleUI;
    
    void OnEnable(){
        if(!isSubscribed){
            _playerInputSet = PlayerInputSet.instance;
            _playerInputSet.ClickDown.Where(x => x == true).Subscribe(x => isDraging = x).AddTo(this);
            _playerInputSet.ClickRelease.Where(x => x == true).Subscribe(x => isDraging = !x).AddTo(this);
            isSubscribed = true;
        }
    }

    public void ResetPanelPos(){
        this.gameObject.GetComponent<RectTransform>().anchoredPosition = DefaultTransform;
    }

    public void OnDrag(PointerEventData eventData)
    {
        this.gameObject.transform.position = eventData.position;
        ClearEvent();
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        
    }

    public void OnDrop(PointerEventData eventData)
    {
        
    }

    public void ClearEvent(){
        if(nowSlot != null){
            nowSlot.gameObject.SetActive(true);
            nowSlot.inSidePuzzlePanel = null;
            puzzleUI.PuzzlePanels[nowSlot.slotNum] = null;
            nowSlot = null;
        }
    }
}