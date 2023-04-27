using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

public class Interactor : MonoBehaviour
{
    private bool isInArea = false;
    private SphereCollider _collider;
    private PlayerInputSet playerInputSet;

    void Start(){
        _collider = GetComponent<SphereCollider>();
        playerInputSet = PlayerInputSet.instance;

        playerInputSet.Interact.Where(x => x = true).Subscribe(x => OnInteract());
    }

    void OnTriggerEnter(Collider collider){
        isInArea = true;
    }

    void OnTriggerExit(Collider collider){
        isInArea = false;
    }

    private GameObject ShootRay(){
        RaycastHit hitInfo;
        GameObject obj = null;
        Vector3 cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;
        if(Physics.Raycast(gameObject.transform.position, cameraForward, out hitInfo, _collider.radius)){
            obj = hitInfo.collider.gameObject;
        }
        
        return obj;
    }

    void OnInteract(){
        Debug.Log("PushE");
        if(isInArea){
            GameObject target = ShootRay();
            if(target != null){
                if(target.GetComponent<Interactable>() != null){
                    target.SendMessage("InteractEvent");
                }
            }
        }
    }
}
