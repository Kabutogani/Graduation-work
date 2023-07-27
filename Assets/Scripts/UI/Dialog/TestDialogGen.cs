using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDialogGen : MonoBehaviour, IInteractable
{
    public void OnInteract()
    {
        GetComponent<TextMessage>().DialogStart();
    }

    public void TestTextEvent(){
        Debug.Log("イベント発生");
    }
}
