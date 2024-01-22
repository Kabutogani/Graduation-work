using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolEnemy : ChaseEnemy
{
    int counts;
    [SerializeField]Quaternion defaultRotate;
    [SerializeField]Animator animator;
    //ここ後で改良
    [SerializeField]GameObject Floor1Key;
    [SerializeField]PatrolEnemyManager patrolEnemyManager;
    [SerializeField]float stackClearTime,maxStackClearTime;

    public override void WithStart(){
        SwitchMode(Mode.Patrol);
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
        if(stackClearTime > maxStackClearTime){
            patrolEnemyManager.SendMessage("PatrolEnd", this);
            stackClearTime = 0;
        }
        stackClearTime += Time.deltaTime;
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
        
    }

    

    void StartIdle(){

        _currentMode = Mode.Idle;
        AnimBoolReset();
        animator.SetBool("Idle", true);
        
    }
    void StartPatrol(){
        _currentMode = Mode.Patrol;
        AnimBoolReset();
        animator.SetBool("Walk", true);
        
    }

    void StartCaution(){
        _currentMode = Mode.Caution;
        AnimBoolReset();
        animator.SetBool("Walk", true);
        
    }

    void StartChase(){
        _currentMode = Mode.Chase;
        AnimBoolReset();
        animator.SetBool("Run", true);
        
    }

    void Idle(){
        
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

        if(routeCheckArea.HitObj == _firstTargetRoute){
            if(SearchToSearchableRay() == null){
                patrolEnemyManager.SendMessage("PatrolEnd", this);
                stackClearTime = 0;
            }
        }
    }

    void Patrol(){
        if(routeCheckArea.HitObj == null){
            _navMeshAgent.SetDestination(_firstTargetRoute.gameObject.transform.position);
        }else{
            if(routeCheckArea.HitObj == _firstTargetRoute){
                SwitchMode(Mode.Idle);
                this.gameObject.transform.rotation = defaultRotate;
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
                SwitchMode(Mode.Patrol);
                ChaseEffect.instance.EffectUIAlpha.Value = 0f;
                Debug.Log("ChaseOut");
            }
        }

        stackClearTime = 0;
    }

    void AnimBoolReset(){
        animator.SetBool("Run", false);
        animator.SetBool("Idle", false);
        animator.SetBool("Walk", false);
    }

    void OnEnable(){
        SaveLoader saveLoader = this.gameObject.GetComponent<SaveLoader>();
        if(!bool.Parse(saveLoader.tempDatas[0])){
            this.gameObject.SetActive(false);
        }else{

        }
    } 
}
