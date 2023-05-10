using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    [SerializeField]
    private GameObject door;
    [SerializeField]private bool isActive;
    int g;

    public void OnInteract()
    {   
        if(isActive){
            door.SetActive(false);
            isActive = false;
        }else{
            door.SetActive(true);
            isActive = true;
        }
        g++;
        Debug.Log(g);
    }
}
