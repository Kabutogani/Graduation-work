using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;


public class Config : MonoBehaviour
{
    [SerializeField] private GameObject _configUI;
    private PlayerInputSet _playerInputSet;

    // Start is called before the first frame update
    void Start()
    {
        _playerInputSet = PlayerInputSet.instance;
        _playerInputSet.Tab.Subscribe(x => {
            CameraMove.ChangePOVCursorMode(!x);
            OnConfigUI(!x);
        }).AddTo(this);
    }

    void OnConfigUI(bool i){
        _configUI.SetActive(i);
    }

    void ChengeSensi(float i){
        
    }
}
