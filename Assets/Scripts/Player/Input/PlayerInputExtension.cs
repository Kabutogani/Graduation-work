using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UnityEngine.InputSystem;

public static class PlayerInputExtension
{
    public static ReadOnlyReactiveProperty<Vector2> GetVector2Property(this InputAction inputAction){
        return Observable.FromEvent<InputAction.CallbackContext>(
            h => inputAction.performed += h,
            h => inputAction.performed -= h)
            .Select(x => x.ReadValue<Vector2>())
            .ToReadOnlyReactiveProperty(new Vector2(0,0));
    }
}
