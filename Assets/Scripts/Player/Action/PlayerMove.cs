using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed;
    private PlayerInputSet _playerInputSet;
    private Rigidbody _rigidbody;
    private Vector2 _targetVector;
    private bool _isMove;

    // Start is called before the first frame update
    void Start()
    {   
        _rigidbody = GetComponent<Rigidbody>();
        _playerInputSet = PlayerInputSet.instance;
        this.UpdateAsObservable().Where(_ => _playerInputSet.Horizontal.Value != new Vector2(0,0)).Subscribe(_ => Move(_playerInputSet.Horizontal.Value));
        _playerInputSet.Tab.Subscribe(x => CameraMove.ChangePOVCursorMode(!x)).AddTo(this);
    }

    void Move(Vector2 vector){
        Vector3 camForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1,0,1)).normalized;
        Vector3 moveDirection = camForward * vector.y + Camera.main.transform.right * vector.x;
        _rigidbody.velocity = moveDirection * moveSpeed + new Vector3(0, _rigidbody.velocity.y, 0) * Time.deltaTime;
    }
}
