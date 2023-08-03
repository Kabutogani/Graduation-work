using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextMessage : MonoBehaviour
{
    public TextAsset[] textFile;

    public void DialogStart(int i){
        Dialog.instance.DialogStart(textFile[i], this.gameObject);
    }
}