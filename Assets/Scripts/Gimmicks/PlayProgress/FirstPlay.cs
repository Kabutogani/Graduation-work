using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPlay : MonoBehaviour
{
    void Start()
    {
        if(!GameProgress.instance.IsPassedProgress(1)){
            Debug.Log("このデータでの初プレイです");
            GameProgress.instance.SetProgressNum(1);
        }else{
            Debug.Log("このデータは既プレイです");
        }
    }
}
