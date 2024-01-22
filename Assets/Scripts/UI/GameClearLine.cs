using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

public class GameClearLine : MonoBehaviour
{
    [SerializeField]GameObject gameClearUI;
    Fade fade;

    public void AreaEvent(){
        fade = UIMain.instance.FadeUI.GetComponent<Fade>();
        fade.CallFadeIn(this.gameObject, 2f);
    }

    public void FadeEndEvent(){
        gameClearUI = UIMain.instance.GameClearUI;
        gameClearUI.SetActive(true);
    }
}
