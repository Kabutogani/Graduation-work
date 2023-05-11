using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RouteCheckArea : MonoBehaviour
{
    public Collider HitCollider;
    public GameObject HitObj;

    public void OnTriggerEnter(Collider collider){
        Debug.Log("CheckPoint!");
        HitCollider = collider;
        HitObj = collider.gameObject;
    }
}
