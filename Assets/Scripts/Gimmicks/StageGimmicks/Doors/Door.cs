using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    [SerializeField]
    protected GameObject[] doors;
    [SerializeField]protected bool isActive;

    public virtual void OnInteract()
    {   

        OpenAndClose(!isActive);

    }

    protected void OpenAndClose(bool isOpen){
        foreach (var item in doors)
        {
            item.SetActive(isOpen);
        }
        isActive = isOpen;
    }

}
