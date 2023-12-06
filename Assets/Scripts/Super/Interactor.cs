using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

public class Interactor : MonoBehaviour
{
    private SphereCollider _collider;
    private List<Collider> inAreaCollider = new List<Collider>(); 
    private PlayerInputSet playerInputSet;
    private bool onMove;

    void Start(){
        _collider = GetComponent<SphereCollider>();
        playerInputSet = PlayerInputSet.instance;

        playerInputSet.Interact.Where(x => x == true && Dialog.instance.IsActiveDialog() == false).Subscribe(x => OnInteract());
        playerInputSet.MousePos.Subscribe(x => ChangeMousePos());
        playerInputSet.Horizontal.Subscribe(x => {OnMove();
            if(x != new Vector2(0,0)){
                onMove = true;
            }else{
                onMove = false;
            }
        });
        
    }

    void Update(){
        if(onMove){
            OnMove();
        }
    }

    void OnTriggerEnter(Collider collider){
        if(collider != null){
            inAreaCollider.Add(collider);
        }
        
    }

    void OnTriggerExit(Collider collider){
        if(collider != null && inAreaCollider.Contains(collider)){
            inAreaCollider.Remove(collider);
        }
    }

    private GameObject ShootRay(){
        RaycastHit hitInfo;
        GameObject obj = null;
        Vector3 cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;
        if(Physics.Raycast(gameObject.transform.position, cameraForward, out hitInfo, _collider.radius, 1 << 11)){
            obj = hitInfo.collider.gameObject;
        }
        
        return obj;
    }

    void OnInteract(){
        if(inAreaCollider?.Count > 0){
            GameObject target = ShootRay();
            if(target != null){
                if(target.GetComponent<Interactable>() != null){
                    target.SendMessage("InteractEvent");
                }
            }
        }
    }

    void ChangeMousePos(){
        CheckCanInteract();
    }

    void OnMove(){

        CheckCanInteract();
    }

    void CheckCanInteract(){
        if(ShootRay() != null){
            UIMain.instance.InteractUI.SetActive(true);
        }else{
            UIMain.instance.InteractUI.SetActive(false);
        }
    }
}
