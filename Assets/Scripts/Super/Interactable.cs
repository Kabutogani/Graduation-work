using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField]
    private GameObject messageListener;

    public void InteractEvent()
    {
        messageListener.SendMessage("OnInteract");
    }
}
