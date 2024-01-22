using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tuna : ChaseEnemy
{

    int counts;
    [SerializeField]Quaternion defaultRotate;
    [SerializeField]Animator animator;
    //ここ後で改良
    [SerializeField]Vector3 defaultPosition;
    [SerializeField]GameObject gameOverLine;

    public override void WithStart(){
        
        _chaseTarget = GameObject.FindGameObjectWithTag("Player");
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

    public void SwitchMode(Mode mode){
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

            case Mode.Death:
                StartDeath();
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

            case Mode.Death:
                Death();
            break;
        }
    }

    public override void InSearchArea(GameObject target, bool b)
    {
        
    }

    void StartIdle(){
        _currentMode = Mode.Idle;
    }
    void StartPatrol(){
        _currentMode = Mode.Patrol;
    }

    void StartCaution(){
        _currentMode = Mode.Caution;
    }

    void StartChase(){
        _currentMode = Mode.Chase;
    }

    void StartDeath(){
        _currentMode = Mode.Death;
        AnimBoolReset();
        animator.SetBool("Death", true);

        _navMeshAgent.velocity = Vector3.zero;
        ChaseEffect.instance.EffectUIAlpha.Value = 0f;
        _navMeshAgent.isStopped = true;
        gameOverLine.SetActive(false);
        this.gameObject.GetComponent<CapsuleCollider>().enabled = false;
    }

    void Idle(){
        
        
    }

    void Patrol(){

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
    }
    
    void Caution(){
        if(SearchToSearchableRay() && SearchToObject() == SearchToSearchableRay()){
            SwitchMode(Mode.Chase);
        }else{
            if(_chaseTimeRemaining < 0){
                SwitchMode(Mode.Patrol);
            }
        }
    }

    void Chase(){
        GameObject g = SearchToSearchableRay();
        float dis = Mathf.Clamp(Vector3.Distance(g.transform.position, transform.position)/10 , 0.2f, 0.8f);
        ChaseEffect.instance.EffectUIAlpha.Value =  1 - dis;

        if(g != null && SearchToObject() == SearchToSearchableRay()){

            //_chaseTarget = g;
            _chaseTimeRemaining = _maxChaseTime;
            _navMeshAgent.SetDestination(g.transform.position);

        }else{
            if(_chaseTimeRemaining >= 0f && _chaseTarget != null){
                _navMeshAgent.SetDestination(_chaseTarget.transform.position);
                _chaseTimeRemaining -= Time.deltaTime;
                //SwitchMode(Mode.Patrol);
                Debug.Log("Chaseins");
                //ChaseEffect.instance.EffectUIAlpha.Value = 0f;
            }else{
                ChaseEffect.instance.EffectUIAlpha.Value = 0f;
                Debug.Log("ChaseOut");
                SwitchMode(Mode.Idle);
                this.transform.position = defaultPosition;
                _navMeshAgent.SetDestination(defaultPosition);
            }
        }
    }

    void Death(){

    }

    void AnimBoolReset(){
        animator.SetBool("Swim", false);
        animator.SetBool("Death", false);
    }
}
