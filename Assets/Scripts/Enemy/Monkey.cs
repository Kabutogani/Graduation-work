using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Unity.Collections;

public class Monkey : ChaseEnemy
{
    int counts;

    public override void WithStart(){
        _firstTargetRoute = GetNearestObjWithTag("EnemyRoute/Monkey");
        SwitchMode(Mode.Patrol);
        _chaseTimeRemaining = 0f;
    }

    void Update(){
        UpdateMode(_currentMode);

        if(_chaseTimeRemaining > 0){
            
            if(_chaseTimeRemaining - Time.deltaTime >= 0){
                _chaseTimeRemaining -= Time.deltaTime;
            }else{
                _chaseTimeRemaining = 0;
            }
        }
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
        // if(_currentMode == Mode.Idle && b){
        //     SwitchMode(Mode.Caution);
        // }
        // if(!b){
        //     //検証が終わったらMode.Idleに戻せ
        //     SwitchMode(Mode.Patrol);
        // }
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

        _navMeshAgent.SetDestination(_nextRoute.gameObject.transform.position);
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
        
        if(SearchToSearchableRay() != null && SearchToObject() == SearchToSearchableRay()){
            SwitchMode(Mode.Chase);
        }

        if(SearchToSearchableRay() && SearchToObject() == SearchToSearchableRay()){
            SwitchMode(Mode.Chase);
        }else{
            if(_chaseTimeRemaining < 0){
                SwitchMode(Mode.Patrol);
            }
        }

        // if(_chaseTimeRemaining > 0){
        //     if(_chaseTimeRemaining - Time.deltaTime < 0){
        //         SwitchMode(Mode.Patrol);
        //         _chaseTimeRemaining = 0;
        //     }else{
        //         _chaseTimeRemaining -= Time.deltaTime;
        //     }
        // }
    }
    
    void Caution(){
        if(SearchToSearchableRay() && SearchToObject() == SearchToSearchableRay()){
            SwitchMode(Mode.Chase);
        }else{
            if(_chaseTimeRemaining < 0){
                SwitchMode(Mode.Patrol);
            }
        }
        Debug.Log("Cautionいった");
    }

    void Chase(){
        GameObject g = SearchToSearchableRay();
        float dis = Mathf.Clamp(Vector3.Distance(g.transform.position, transform.position)/10 , 0.2f, 0.8f);
        ChaseEffect.instance.EffectUIAlpha.Value =  1 - dis;

        if(g != null && SearchToObject() == SearchToSearchableRay()){

            _chaseTarget = g;
            _chaseTimeRemaining = _maxChaseTime;
            _navMeshAgent.SetDestination(g.transform.position);

        }else{
            if(_chaseTimeRemaining >= 0f && _chaseTarget != null){
                _navMeshAgent.SetDestination(_chaseTarget.transform.position);
                _chaseTimeRemaining -= Time.deltaTime;
            }else{
                SwitchMode(Mode.Patrol);
                ChaseEffect.instance.EffectUIAlpha.Value = 0f;
            }
        }
    }


    public void AlarmMessage(GameObject g){
        if(_currentMode != Mode.Chase){
            SwitchMode(Mode.Patrol);
            _navMeshAgent.SetDestination(g.transform.position);
            _chaseTimeRemaining = _maxChaseTime * 2;
        }else{
            _navMeshAgent.SetDestination(GetPlayerObj().transform.position);
            _chaseTimeRemaining = _maxChaseTime * 2;
        }
        Debug.Log("Alarm count : " + counts);
        counts++;
    }
}
