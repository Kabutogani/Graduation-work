using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveDetailUI : MonoBehaviour
{
    [SerializeField]TMPro.TMP_Text playTimeText;
    [SerializeField]int dataNum;

    void OnEnable()
    {
        if(SaveSystem.ExistsSaveDataFile(dataNum)){
            WithStart();
        }

    }

    int[] SecondsToTimes(int i){
        int h,m,s;
        h = i / 3600;
        m = i % 3600 / 60;
        s = i % 60;
        int[] times = new int[]{h,m,s};
        return times;
    }

    void WithStart(){
        int[] times = SecondsToTimes(SaveDetailLoader.GetPlaySeconds(dataNum));
        string text = times[0] + " : " + times[1] + " : " + times[2];
        playTimeText.SetText(text);
    }
}
