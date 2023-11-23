using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TextMessage))]
public class InteractToMessage : MonoBehaviour, IInteractable
{
    TextMessage textMessage;
    public void OnInteract()
    {
        textMessage = this.GetComponent<TextMessage>();
        textMessage.DialogStart(0);
    }
}
