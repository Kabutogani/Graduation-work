using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitGame:MonoBehaviour
{
    public static void EndApplication(){
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }
}
