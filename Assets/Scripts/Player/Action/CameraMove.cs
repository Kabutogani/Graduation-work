using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CameraMove
{
    public static void ChangePOVCursorMode(bool mode){
        if(mode){
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }else{
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
