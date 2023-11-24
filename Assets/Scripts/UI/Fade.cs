using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    Image fadeImage;
    bool isFadeIn, nowFade;
    float fadeSpeed;
    GameObject endEventListener;
    
    // Start is called before the first frame update
    void Start()
    {
        fadeImage = UIMain.instance.FadeUI.GetComponent<Image>();
        nowFade = false;
    }

    void Update()
    {
        if(nowFade){
            FadeMethod();
        }
        
    }

    public void CallFadeIn(GameObject fadeEndListener,float fadeInSpeed){
        isFadeIn = true;
        fadeSpeed = fadeInSpeed;
        endEventListener = fadeEndListener;
        Color color = fadeImage.color;
        color.a = 0;
        nowFade = true;
    }

    public void CallFadeOut(GameObject fadeEndListener,float fadeOutSpeed){
        isFadeIn = true;
        fadeSpeed = -fadeOutSpeed;
        endEventListener = fadeEndListener;
        Color color = fadeImage.color;
        color.a = 1;
        nowFade = true;
    }

    void EndEvent(){
        endEventListener.SendMessage("FadeEndEvent");
    }

    void FadeMethod(){
        Color color = fadeImage.color;
        color.a += Time.deltaTime * fadeSpeed;
        if(color.a >= 1 && isFadeIn){
            EndEvent();
            nowFade = false;
        }
        if(color.a <= 0 && !isFadeIn){
            EndEvent();
            nowFade = false;
        }
        fadeImage.color = color;
    }
}
