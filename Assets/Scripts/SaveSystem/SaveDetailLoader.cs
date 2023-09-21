using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public static class SaveDetailLoader
{
    public static int GetPlaySeconds(int dataNum){
        int i;
        if(int.TryParse(SaveSystem.LoadLine(dataNum, 0),out i)){
            return i;
        }else{
            Debug.LogError("セーブデータのプレイ時間が不正です");
            return i;
        }
    }
}
