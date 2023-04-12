using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

public class PlayerMove : MonoBehaviour
{
    private PlayerInputSet _playerInputSet;

    // Start is called before the first frame update
    void Start()
    {
        _playerInputSet = PlayerInputSet.instance;

        _playerInputSet.Horizontal.Subscribe(x => Debug.Log(x));
    }

}
