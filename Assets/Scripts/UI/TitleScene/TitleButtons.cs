using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleButtons : MonoBehaviour
{
    [SerializeField]GameObject _UIparent, _UIBackFade;

    public void PushButton(GameObject g){
        g.SetActive(true);
        CloseOtherUI(g);
        _UIBackFade.SetActive(true);
    }

    public void CloseUI(GameObject g){
        g.SetActive(false);
        _UIBackFade.SetActive(false);
    }

    void CloseOtherUI(GameObject remaingObj){
        for(int i = 0; i < _UIparent.transform.childCount ;i++){
            GameObject g = _UIparent.transform.GetChild(i).gameObject;
            if(g != remaingObj){
                g.SetActive(false);
            }
        }
    }
}
