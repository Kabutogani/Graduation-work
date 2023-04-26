using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactor : MonoBehaviour
{
    private bool isInArea = false; 

    void Start(){

    }

    void Update(){
        if(isInArea){
            
        }
    }

    void OnTriggerEnter(Collider collider){
        isInArea = true;
    }

    void OnTriggerExit(Collider collider){
        isInArea = false;
    }

    void ShootRay(){
        
    }
}
