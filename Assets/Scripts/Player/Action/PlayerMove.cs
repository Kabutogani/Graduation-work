using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using UnityEngine.AI;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    public float DashSpeed,DefaultMoveSpeed,dashMeterDecreaseSpeed;
    public float MoveSpeed;
    private PlayerInputSet _playerInputSet;
    private Rigidbody _rigidbody;
    private Vector2 _targetVector;
    private bool _isMove,_isDash;
    private NavMeshAgent _navMeshAgent;
    private DashMeter _dashMeter;

    // Start is called before the first frame update
    void Start()
    {   
        _rigidbody = GetComponent<Rigidbody>();
        _playerInputSet = PlayerInputSet.instance;
        _dashMeter = UIMain.instance.dashMeter;
        _navMeshAgent = GetComponent<NavMeshAgent>();
        this.UpdateAsObservable().Where(_ => _playerInputSet.Horizontal.Value != new Vector2(0,0)).Subscribe(_ => Move(_playerInputSet.Horizontal.Value)).AddTo(this);
        _playerInputSet.Dash.Subscribe(x => _isDash = x).AddTo(this);

        MoveSpeed = DefaultMoveSpeed;
    }

    void Move(Vector2 vector){
        if(!PlayerStateMgr.instance.IsUseUI){
            Vector3 camForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1,0,1)).normalized;
            Vector3 moveDirection = camForward * vector.y + Camera.main.transform.right * vector.x;
            if(_isDash && _dashMeter.MeterGauge.Value > 0){
                MoveSpeed = DashSpeed;
                _dashMeter.MeterGauge.Value = Mathf.Clamp(_dashMeter.MeterGauge.Value - Time.deltaTime * dashMeterDecreaseSpeed, _dashMeter.slider.minValue ,_dashMeter.slider.maxValue);
            }else{
                MoveSpeed = DefaultMoveSpeed;
            }
            _rigidbody.velocity = moveDirection * MoveSpeed + new Vector3(0, _rigidbody.velocity.y, 0) * Time.deltaTime;
        }
    }
}
