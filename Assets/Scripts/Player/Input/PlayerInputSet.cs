using System.Collections;
using System;
using UnityEngine;
using UniRx;
using UnityEngine.InputSystem;

public class PlayerInputSet : MonoBehaviour, IDisposable
{   
    public static PlayerInputSet instance;
    private GameObject disableTargetObject;

    [SerializeField] private InputActionAsset _inputActionAsset;
    private InputActionMap _inputAction;

    private ReadOnlyReactiveProperty<Vector2> _horizontal = default;
    public IReadOnlyReactiveProperty<Vector2> Horizontal => _horizontal;

    private ReadOnlyReactiveProperty<bool> _tab = default;
    public IReadOnlyReactiveProperty<bool> Tab => _tab;

    private ReadOnlyReactiveProperty<bool> _interact = default;
    public IReadOnlyReactiveProperty<bool> Interact => _interact;

    private void OnEnable(){
        disableTargetObject = GameObject.Find(this.gameObject.name);;
        _inputAction.Enable();
    }

    private void OnDisable(){

        if(disableTargetObject == this.gameObject){
            _inputAction.Disable();
        }
    }

    private void OnDestroy(){

        if(disableTargetObject == this.gameObject){
            Dispose();
        }
    }

    private void Awake(){
        if(instance == null){
            instance = this;
            DontDestroyOnLoad(gameObject);
        }else{
            Destroy(gameObject);
        }
        
        _inputAction = _inputActionAsset.FindActionMap("Player");

        _horizontal = _inputAction.FindAction("Move").GetVector2Property();
        _tab = _inputAction.FindAction("Tab").GetButtonProperty();
        _interact = _inputAction.FindAction("Interact").GetButtonProperty();
    }

    public void Dispose()
    {
        _inputAction?.Dispose();
        _horizontal?.Dispose();
        _tab?.Dispose();
        _interact?.Dispose();
    }
}
