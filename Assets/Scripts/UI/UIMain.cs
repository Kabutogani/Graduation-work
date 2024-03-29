using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UnityEngine.UI;

public class UIMain : MonoBehaviour
{
    private PlayerInputSet _playerInputSet;
    [SerializeField] private GameObject _inventoryUIObj,_configUIObj;
    public GameObject GameOverUI, FadeUI, InteractUI, PuzzleUI, GameClearUI;
    public static UIMain instance;
    public DashMeter dashMeter;

    // Start is called before the first frame update
    void Start()
    {
        _playerInputSet = PlayerInputSet.instance;
        _playerInputSet.Tab.Where(x => x == true).Subscribe(x => {
            ChangeCursorMode(Cursor.visible);
            OnInventoryUI(!_inventoryUIObj.activeSelf);
            if(Cursor.visible){
                if(!_inventoryUIObj.activeSelf){
                    OnInventoryUI(true);
                }
            }
            OnConfigUI(false);
        }).AddTo(this);
    }

    public void ChangeCursorMode(bool i){
        CameraMove.ChangePOVCursorMode(i);
    }

    public void OnInventoryUI(bool i){
        _inventoryUIObj.SetActive(i);
    }

    public void OnConfigUI(bool i){
        _configUIObj.SetActive(i);
    }

    public void PushExitButton(){
        ExitGame.EndApplication();
    }

    void Awake(){
        if(instance == null){
            instance = this;
            DontDestroyOnLoad(gameObject);
        }else{
            Destroy(gameObject);
        }
    }
}
