using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using Cinemachine;


public class Config : MonoBehaviour
{
    private PlayerInputSet _playerInputSet;

    private ICinemachineCamera icCam;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void ChangeSensi(float value){
        Debug.Log("ChangeTo" + value);
        CinemachineBrain cinemachineBrain = Camera.main.gameObject.GetComponent<CinemachineBrain>();
        icCam = cinemachineBrain.ActiveVirtualCamera;
        CinemachineVirtualCamera vcam = icCam.VirtualCameraGameObject.GetComponent<CinemachineVirtualCamera>();
        vcam.GetCinemachineComponent(CinemachineCore.Stage.Aim).GetComponent<CinemachinePOV>().m_VerticalAxis.m_MaxSpeed = value * 10;
        vcam.GetCinemachineComponent(CinemachineCore.Stage.Aim).GetComponent<CinemachinePOV>().m_HorizontalAxis.m_MaxSpeed = value * 10;
        
    }

    public void Func1(float value){
        ChangeSensi(value);
    }
}
