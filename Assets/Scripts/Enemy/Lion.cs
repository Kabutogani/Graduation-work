using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lion : Enemy
{
    int counts;
    [SerializeField]Quaternion defaultRotate;
    public Animator animator;
    //ここ後で改良
    [SerializeField]Vector3 defaultPosition;
    public Tuna tuna;
    [SerializeField]GameObject lionBlockObj,pieceObj;

    public enum Mode{
        Idle,
        Sleep,
        Chase,
        Eating
    }

    [SerializeField]public Mode _currentMode;

    public override void WithStart(){
        
        
    }

    void Update(){
        UpdateMode(_currentMode);
    }

    public void SwitchMode(Mode mode){
        switch(mode){
            case Mode.Idle:
                StartIdle();
            break;

            case Mode.Sleep:
                StartSleep();
            break;

            case Mode.Eating:
                StartEating();
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

            case Mode.Sleep:
                Sleep();
            break;

            case Mode.Eating:
                Eating();
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
    void StartSleep(){
        _currentMode = Mode.Sleep;
        AnimBoolReset();
        animator.SetBool("Sleep", true);
    }

    void StartEating(){
        _currentMode = Mode.Eating;
        AnimBoolReset();
        animator.SetBool("Eating", true);
        this.gameObject.transform.LookAt(tuna.gameObject.transform);
        ChangeDataValue(0, "false");
        tuna.ChangeDataValue(0, "false");
        pieceObj.SetActive(true);
        pieceObj.GetComponent<LionPanel>().ChangeDataValue(0,"true");
        _navMeshAgent.velocity = Vector3.zero;
        this.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        _navMeshAgent.isStopped = true;
    }

    void StartChase(){
        _currentMode = Mode.Chase;
        AnimBoolReset();
        animator.SetBool("Run", true);
        lionBlockObj.SetActive(false);
        this.gameObject.GetComponent<CapsuleCollider>().enabled = true;
    }

    void Idle(){
        
    }

    void Sleep(){

    }
    
    void Eating(){

    }

    void Chase(){
        _navMeshAgent.SetDestination(tuna.gameObject.transform.position);
        Debug.Log("NowChase");
    }

    void AnimBoolReset(){
        animator.SetBool("Run", false);
        animator.SetBool("Eating", false);
        animator.SetBool("Idle", false);
        animator.SetBool("Sleep", false);
    }

    void OnCollisionEnter(Collision collision){
        if(collision.gameObject.GetComponent<Tuna>()){
            tuna = collision.gameObject.GetComponent<Tuna>();
            tuna.SwitchMode(ChaseEnemy.Mode.Death);
            SwitchMode(Mode.Eating);
        }
    }
}
