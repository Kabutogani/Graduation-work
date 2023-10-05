using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RouteCheckArea : MonoBehaviour
{
    public Collider HitCollider;
    public GameObject HitObj;

    public void OnTriggerEnter(Collider collider){
        HitCollider = collider;
        HitObj = collider.gameObject;
    }

    public void OnTriggerExit(Collider collider){
        if(collider = HitCollider){
            HitCollider = null;
            HitObj = null;
        }
    }
}
