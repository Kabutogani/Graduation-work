using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LionBlock : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if(!bool.Parse(SaveSystem.LoadLine(28))){
            this.gameObject.SetActive(false);
        }
    }

}
