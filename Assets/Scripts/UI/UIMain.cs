using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class UIMain : MonoBehaviour
{
    private PlayerInputSet _playerInputSet;
    [SerializeField] private GameObject _inventoryUIObj,_configUIObj;

    // Start is called before the first frame update
    void Start()
    {
        _playerInputSet = PlayerInputSet.instance;
        _playerInputSet.Tab.Subscribe(x => {
            CameraMove.ChangePOVCursorMode(!x);
            OnConfigUI(x);
        }).AddTo(this);
    }

    void OnInventoryUI(bool i){
        _inventoryUIObj.SetActive(i);
    }

    void OnConfigUI(bool i){
        _configUIObj.SetActive(i);
    }
}
