using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextMessage : MonoBehaviour
{
    public TextAsset textFile;

    public void DialogStart(){
        Dialog.instance.DialogStart(textFile, this.gameObject);
    }
}
