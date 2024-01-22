using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TunaTrap : MonoBehaviour
{
    [SerializeField]Tuna tuna;
    [SerializeField]GameObject shootTarget, beforeShootPos;

    public void AreaEvent(){
        if(tuna._currentMode == ChaseEnemy.Mode.Idle){
            tuna.SwitchMode(ChaseEnemy.Mode.Patrol);
            tuna.gameObject.transform.position = beforeShootPos.transform.position;
            //Vector3 shootPow = tuna.gameObject.transform.position - shootTarget.transform.position;
            // Vector3 shootPow = new Vector3(0,8,0);
            // tuna.gameObject.GetComponent<Rigidbody>().AddForce(shootPow, ForceMode.Impulse);
        }
    }
}
