using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    [SerializeField]
    private GameObject door;

    public void OnInteract()
    {   
        Debug.Log(door.activeSelf);
        door.SetActive(!door.activeSelf);
    }
}
