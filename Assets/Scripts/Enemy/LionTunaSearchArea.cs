using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LionTunaSearchArea : MonoBehaviour
{
    [SerializeField]Lion lion;

    void OnTriggerEnter(Collider collider){
        if(collider.gameObject.GetComponent<Tuna>()){
            lion.tuna = collider.gameObject.GetComponent<Tuna>();
            lion.animator.SetBool("Awake", true);
        }
    }
}
