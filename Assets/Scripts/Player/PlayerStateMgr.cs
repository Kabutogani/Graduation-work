using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMgr : MonoBehaviour
{   
    public static PlayerStateMgr instance;
    public bool isHiding;

    void Start(){
        isHiding = false;
    }

    void Awake(){
        if(instance == null){
            instance = this;
            DontDestroyOnLoad(gameObject);
        }else{
            Destroy(gameObject);
        }
    }
}
