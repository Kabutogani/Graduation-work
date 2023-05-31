using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    [SerializeField]
    protected GameObject door;
    [SerializeField]protected bool isActive;

    public virtual void OnInteract()
    {   
        if(isActive){
            door.SetActive(false);
            isActive = false;
        }else{
            door.SetActive(true);
            isActive = true;
        }
    }
}
