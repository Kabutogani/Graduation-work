using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaEvent : MonoBehaviour
{
    [SerializeField]GameObject messageListener;
    [SerializeField]bool isAlways, isOnce;

    void OnTriggerEnter(Collider collider){
        if(collider.gameObject.tag =="Player"){
            if(!isAlways){
                messageListener.SendMessage("AreaEvent");
                if(isOnce){
                    this.gameObject.SetActive(false);
                }
            }
        }
    }

    void OnTriggerStay(Collider collider){
        if(collider.gameObject.tag =="Player"){
            if(isAlways){
                messageListener.SendMessage("AreaEvent");
            }
        }
    }
}
