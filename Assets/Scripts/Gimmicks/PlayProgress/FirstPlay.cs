using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPlay : MonoBehaviour
{
    TextMessage textMessage;

    void Start()
    {
        textMessage = gameObject.GetComponent<TextMessage>();

        if(!GameProgress.instance.IsPassedProgress(1)){
            Debug.Log("このデータでの初プレイです");
            textMessage.DialogStart(0);
            GameProgress.instance.SetProgressNum(1);
        }else{
            Debug.Log("このデータは既プレイです");
        }
    }
}
