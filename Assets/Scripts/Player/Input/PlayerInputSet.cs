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

    private ReadOnlyReactiveProperty<Vector2> _mousePos = default;
    public IReadOnlyReactiveProperty<Vector2> MousePos => _mousePos;

    private ReadOnlyReactiveProperty<bool> _tab = default;
    public IReadOnlyReactiveProperty<bool> Tab => _tab;

    private ReadOnlyReactiveProperty<bool> _dash = default;
    public IReadOnlyReactiveProperty<bool> Dash => _dash;

    private ReadOnlyReactiveProperty<bool> _interact = default;
    public IReadOnlyReactiveProperty<bool> Interact => _interact;

    private ReadOnlyReactiveProperty<bool> _clickDown = default;
    public IReadOnlyReactiveProperty<bool> ClickDown => _clickDown;

    private ReadOnlyReactiveProperty<bool> _clickRelease = default;
    public IReadOnlyReactiveProperty<bool> ClickRelease => _clickRelease;

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
        _mousePos = _inputAction.FindAction("Look").GetVector2Property();
        _tab = _inputAction.FindAction("Tab").GetButtonProperty();
        _dash = _inputAction.FindAction("Dash").GetButtonProperty();
        _interact = _inputAction.FindAction("Interact").GetButtonProperty();
        _clickDown = _inputAction.FindAction("ClickDown").GetButtonProperty();
        _clickRelease = _inputAction.FindAction("ClickRelease").GetButtonProperty();
    }

    public void Dispose()
    {
        _inputAction?.Dispose();
        _horizontal?.Dispose();
        _mousePos?.Dispose();
        _tab?.Dispose();
        _dash?.Dispose();
        _interact?.Dispose();
        _clickDown?.Dispose();
        _clickRelease?.Dispose();
    }
}
