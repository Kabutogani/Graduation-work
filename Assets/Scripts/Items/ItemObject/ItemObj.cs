using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObj : MonoBehaviour,IInteractable
{
    public void OnInteract()
    {
        Debug.Log("ItemGet!");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }
    
}
