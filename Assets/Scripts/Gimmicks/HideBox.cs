using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideBox : MonoBehaviour
{
    void OnTriggerEnter(Collider collider){
        if(collider.gameObject.tag == "Player"){
            collider.gameObject.GetComponent<PlayerStateMgr>().isHiding = true;
        }
    }

    void OnTriggerExit(Collider collider){
        if(collider.gameObject.tag == "Player"){
            collider.gameObject.GetComponent<PlayerStateMgr>().isHiding = false;
        }
    }
}
