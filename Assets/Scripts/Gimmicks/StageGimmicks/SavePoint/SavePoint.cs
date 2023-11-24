using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TextMessage))]
public class SavePoint : MonoBehaviour, IInteractable
{
    TextMessage textMessage;
    public void OnInteract()
    {
        textMessage = GetComponent<TextMessage>();
        textMessage.DialogStart(0);
        Save();
    }

    public void Save(){
        SaveSystem.Save();
        Debug.Log("セーブしました");
    }
}
