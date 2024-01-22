using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PuzzleUI : MonoBehaviour
{
    private float beforeSensi_V, beforeSensi_H;
    [SerializeField]GameObject puzzleUIObj;
    public PuzzlePanel[] PuzzlePanels = new PuzzlePanel[4];

    public void OnInteractPuzzle(){
        PlayerStateMgr.instance.IsUseUI = true;
        UIMain.instance.ChangeCursorMode(false);
        UIMain.instance.OnInventoryUI(false);
        UIMain.instance.OnConfigUI(false);
        puzzleUIObj.SetActive(true);
        SetSensi(true);
    }

    public void ExitPuzzle(){
        PlayerStateMgr.instance.IsUseUI = false;
        UIMain.instance.ChangeCursorMode(true);
        puzzleUIObj.SetActive(false);
        SetSensi(false);
    }

    void SetSensi(bool isOnUI){
        CinemachineBrain cinemachineBrain = Camera.main.gameObject.GetComponent<CinemachineBrain>();
        ICinemachineCamera icCam = cinemachineBrain.ActiveVirtualCamera;
        CinemachineVirtualCamera vcam = icCam.VirtualCameraGameObject.GetComponent<CinemachineVirtualCamera>();
        
        if(isOnUI){
            beforeSensi_V = vcam.GetCinemachineComponent(CinemachineCore.Stage.Aim).GetComponent<CinemachinePOV>().m_VerticalAxis.m_MaxSpeed;
            beforeSensi_H = vcam.GetCinemachineComponent(CinemachineCore.Stage.Aim).GetComponent<CinemachinePOV>().m_HorizontalAxis.m_MaxSpeed;
            vcam.GetCinemachineComponent(CinemachineCore.Stage.Aim).GetComponent<CinemachinePOV>().m_VerticalAxis.m_MaxSpeed = 0;
            vcam.GetCinemachineComponent(CinemachineCore.Stage.Aim).GetComponent<CinemachinePOV>().m_HorizontalAxis.m_MaxSpeed = 0;
        }else{
            vcam.GetCinemachineComponent(CinemachineCore.Stage.Aim).GetComponent<CinemachinePOV>().m_VerticalAxis.m_MaxSpeed = beforeSensi_V;
            vcam.GetCinemachineComponent(CinemachineCore.Stage.Aim).GetComponent<CinemachinePOV>().m_HorizontalAxis.m_MaxSpeed = beforeSensi_H;
        } 
    }

    public void ResetButton(){
        foreach (PuzzlePanel i in PuzzlePanels)
        {
            if(i != null){
                if(i.nowSlot != null){
                    i.nowSlot.inSidePuzzlePanel = null;
                }
                i.ClearEvent();
                i.ResetPanelPos();
            }
        }
    }

    public void CheckSlotPanels(){
        if(CheckSlots()){
            ExitPuzzle();
            Debug.Log("パズルに正解しました");
        }else{
            Debug.Log("パズル不正解");
        }
        
    }

    public bool CheckSlots(){
        bool result = true;
        foreach (var i in PuzzlePanels)
        {
            if(i == null){
                Debug.Log("そもそもパズルが埋まってない");
                return false;
            }
            
        }
        for (int i = 0; i < PuzzlePanels.Length; i++)
        {
            switch (i)
            {
                case 0:
                    if(PuzzlePanels[0].PanelNum != 0){
                        result = false;
                        Debug.Log("0が不正解");
                    }
                break;

                case 1:
                    if(PuzzlePanels[1].PanelNum != 5){
                        result = false;
                        Debug.Log("1が不正解");
                    }
                break;

                case 2:
                    if(PuzzlePanels[2].PanelNum != 6){
                        result = false;
                        Debug.Log("2が不正解");
                    }
                break;

                case 3:
                    if(PuzzlePanels[3].PanelNum != 4){
                        result = false;
                        Debug.Log("3が不正解");
                    }
                break;
            }
        }
        return result;
    }
}
