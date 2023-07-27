using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextMessage : MonoBehaviour
{
    [SerializeField]private TextAsset _textFile;

    public void DialogStart(){
        Dialog.instance.DialogStart(_textFile, this.gameObject);
    }
}
