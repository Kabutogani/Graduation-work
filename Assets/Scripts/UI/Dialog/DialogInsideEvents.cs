using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TextMessage))]
public class DialogInsideEvents : MonoBehaviour
{
    public void Room001KeyPlaceHint(){
        GameProgress.instance.SetProgressNum(2);
    }
}
