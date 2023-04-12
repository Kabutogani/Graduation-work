using System.Collections;
using System;
using UnityEngine;
using UniRx;
using UnityEngine.InputSystem;

public class PlayerInputSet : MonoBehaviour, IDisposable
{   
    public static PlayerInputSet instance;

    [SerializeField] private InputActionAsset _inputActionAsset;
    private InputActionMap _inputAction;

    private ReadOnlyReactiveProperty<Vector2> _horizontal = default;
    public IReadOnlyReactiveProperty<Vector2> Horizontal => _horizontal;

    private ReadOnlyReactiveProperty<bool> _tab = default;
    public IReadOnlyReactiveProperty<bool> Tab => _tab;

    private void OnEnable(){
        _inputAction.Enable();
    }

    private void OnDisable(){
        _inputAction.Disable();
    }

    private void OnDestroy(){
        Dispose();
    }

    private void Awake(){
        instance = this;
        
        _inputAction = _inputActionAsset.FindActionMap("Player");

        _horizontal = _inputAction.FindAction("Move").GetVector2Property();
        _tab = _inputAction.FindAction("Tab").GetButtonProperty();
    }

    public void Dispose()
    {
        _inputAction?.Dispose();
        _horizontal?.Dispose();
        _tab?.Dispose();
    }
}
