using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PuzzleUI : MonoBehaviour
{
    private float beforeSensi_V, beforeSensi_H;
    [SerializeField]GameObject puzzleUIObj;

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
}
