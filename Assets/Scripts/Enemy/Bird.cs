using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Unity.Collections;

public class Bird : Enemy
{
    enum Mode{
        Idle,
        Caution,
        Alarm
    }

    [SerializeField, ReadOnly]Mode _currentMode = Mode.Idle;

    [SerializeField]GameObject _chaseTarget, _destinationEnemy;

    public override void WithStart(){
        //_firstTargetRoute = GetNearestObjWithTag("EnemyRoute/Monkey");
        SwitchMode(Mode.Idle);
        _destinationEnemy = GetNearestObjWithTag("Enemy/Monkey");
    }

    void Update(){
        UpdateMode(_currentMode);
    }

    void SwitchMode(Mode mode){
        switch(mode){
            case Mode.Idle:
                StartIdle();
            break;

            case Mode.Caution:
                StartCaution();
            break;

            case Mode.Alarm:
                StartAlarm();
            break;
        }
    }

    void UpdateMode(Mode mode){
        switch(mode){
            case Mode.Idle:
                Idle();
            break;

            case Mode.Caution:
                Caution();
            break;

            case Mode.Alarm:
                Alarm();
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
            SwitchMode(Mode.Idle);
        }
    }

    

    void StartIdle(){

        _currentMode = Mode.Idle;
    }

    void StartCaution(){
        _currentMode = Mode.Caution;
    }

    void StartAlarm(){
        _currentMode = Mode.Alarm;
    }

    void Idle(){
        if(SearchToSearchableRay() != null && SearchToObject() == SearchToSearchableRay()){
            SwitchMode(Mode.Alarm);
        }
    }
    
    void Caution(){
        if(SearchToSearchableRay() && SearchToObject() == SearchToSearchableRay()){
            SwitchMode(Mode.Alarm);
        }else{
            SwitchMode(Mode.Idle);
        }
    }

    void Alarm(){
        GameObject g = SearchToSearchableRay();

        if(g != null && SearchToObject() == SearchToSearchableRay()){

            _chaseTarget = g;
            Debug.Log("メッセージを送信");
            _destinationEnemy.SendMessage("AlarmMessage",_chaseTarget);

        }else{
            if(_chaseTarget != null){

            }else{
                SwitchMode(Mode.Caution);

            }
        }
    }
}
