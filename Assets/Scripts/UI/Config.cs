using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using Cinemachine;


public class Config : MonoBehaviour
{
    [SerializeField] private GameObject _configUI;
    private PlayerInputSet _playerInputSet;

    private ICinemachineCamera icCam;

    // Start is called before the first frame update
    void Start()
    {
        _playerInputSet = PlayerInputSet.instance;
        _playerInputSet.Tab.Subscribe(x => {
            CameraMove.ChangePOVCursorMode(!x);
            OnConfigUI(x);
        }).AddTo(this);


    }

    void OnConfigUI(bool i){
        _configUI.SetActive(i);
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
