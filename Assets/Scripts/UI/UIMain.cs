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
        _playerInputSet.Tab.Where(x => x == true).Subscribe(x => {
            ChangeCursorMode(Cursor.visible);
            OnConfigUI(!_configUIObj.activeSelf);
            Debug.Log(Cursor.visible);
            if(Cursor.visible){
                if(!_configUIObj.activeSelf){
                    OnConfigUI(true);
                }
            }
        }).AddTo(this);
    }

    void ChangeCursorMode(bool i){
        CameraMove.ChangePOVCursorMode(i);
    }

    void OnInventoryUI(bool i){
        _inventoryUIObj.SetActive(i);
    }

    void OnConfigUI(bool i){
        _configUIObj.SetActive(i);
    }
}
