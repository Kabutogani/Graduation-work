using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Unity.Collections;

public class Monkey : Enemy
{
    enum Mode{
        Idle,
        Patrol,
        Caution,
        Chase
    }

    [SerializeField, ReadOnly]private Mode _currentMode = Mode.Idle;
    [SerializeField]private float chaseSpeed,patrolSpeed;
    [SerializeField]GameObject _firstTargetRoute;
    [SerializeField]EnemyRoute _nextRoute,_beforeRoute;
    [SerializeField]RouteCheckArea routeCheckArea;

    public override void WithStart(){
        _firstTargetRoute = GetNearestObjWithTag("EnemyRoute/Monkey");
        SwitchMode(Mode.Patrol);
    }

    void Update(){
        UpdateMode(_currentMode);
    }

    void SwitchMode(Mode mode){
        switch(mode){
            case Mode.Idle:
                StartIdle();
            break;

            case Mode.Patrol:
                StartPatrol();
            break;

            case Mode.Caution:
                StartCaution();
            break;

            case Mode.Chase:
                StartChase();
            break;
        }
    }

    void UpdateMode(Mode mode){
        switch(mode){
            case Mode.Idle:
                Idle();
            break;

            case Mode.Patrol:
                Patrol();
            break;

            case Mode.Caution:
                Caution();
            break;

            case Mode.Chase:
                Chase();
            break;
        }
    }

    public override void InSearchArea(GameObject target, bool b)
    {
        if(_currentMode == Mode.Idle && b){
            SwitchMode(Mode.Caution);
        }
        if(!b){
            //検証が終わったらMode.Idleに戻せ
            SwitchMode(Mode.Patrol);
        }
    }

    

    void StartIdle(){

        _currentMode = Mode.Idle;
    }
    void StartPatrol(){
        if(_beforeRoute == null){
            _beforeRoute = _nextRoute;
            _nextRoute = _firstTargetRoute.GetComponent<EnemyRoute>();

        }else{
            _nextRoute = GetNextRouteByNowRoute(_nextRoute,_beforeRoute);
            _beforeRoute = _nextRoute;
        }
        _currentMode = Mode.Patrol;
    }

    void StartCaution(){
        _currentMode = Mode.Caution;
    }

    void StartChase(){
        _currentMode = Mode.Chase;
    }

    void Idle(){

    }

    void Patrol(){
        if(routeCheckArea.HitObj != null){
            if(routeCheckArea.HitObj.GetComponent<EnemyRoute>() == _nextRoute){
                SwitchMode(Mode.Patrol);
            }
        }
        _navMeshAgent.SetDestination(_nextRoute.gameObject.transform.position);

        // GameObject g = _nextRoute.gameObject;
        // gameObject.transform.LookAt(g.transform);
        // Vector3 r = gameObject.transform.eulerAngles;
        // r.x = 0;
        // r.z = 0;
        // gameObject.transform.eulerAngles = r;
        // Vector3 moveDirection = gameObject.transform.forward;
        // _rigidbody.velocity = moveDirection * chaseSpeed + new Vector3(0, _rigidbody.velocity.y, 0) * Time.deltaTime;
    }
    
    void Caution(){
        if(SearchToSearchableRay() && SearchToObject() == SearchToSearchableRay()){
            SwitchMode(Mode.Chase);
        }
    }

    void Chase(){
        GameObject g = SearchToSearchableRay();
        if(g != null && SearchToObject() == SearchToSearchableRay()){
            //transform.position = Vector3.MoveTowards(transform.position ,g.transform.position, 1 * Time.deltaTime);
            
            gameObject.transform.LookAt(g.transform);
            Vector3 moveDirection = gameObject.transform.forward;
            _rigidbody.velocity = moveDirection * chaseSpeed + new Vector3(0, _rigidbody.velocity.y, 0) * Time.deltaTime;
        }else{
            SwitchMode(Mode.Caution);
        }
    }
}
