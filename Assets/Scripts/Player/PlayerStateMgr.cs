using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class PlayerStateMgr : MonoBehaviour
{   
    public static PlayerStateMgr instance;
    public bool isHiding;
    public bool IsUseUI;

    void Start(){
        isHiding = false;
        IsUseUI = false;
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
