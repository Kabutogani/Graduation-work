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
        _inputAction = _inputActionAsset.FindActionMap("Player");
        _horizontal = _inputAction.FindAction("Move").GetVector2Property();

        if(instance == null){
            instance = this;
            DontDestroyOnLoad(gameObject);
        }else{
            Destroy(gameObject);
        }
    }

    public void Dispose()
    {
        _inputAction?.Dispose();
    }
}
