using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UnityEngine.UI;

public class ChaseEffect : MonoBehaviour
{
    private Image image;
    public ReactiveProperty<float> EffectUIAlpha;
    public static ChaseEffect instance;

    void Awake(){
        if(instance == null){
            instance = this;
            DontDestroyOnLoad(gameObject);
        }else{
            Destroy(gameObject);
        }
    }

    void Start(){
        image = GetComponent<Image>();
        EffectUIAlpha.Subscribe(x => ChangeUI(x));
    }

    void ChangeUI(float i){
        Color c = image.color;
        c.a = i;
        image.color = c;
    }
}
