using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UnityEngine.UI;
using System;
using UniRx.Triggers;

public class DashMeter : MonoBehaviour,ILoadableSaveData
{
    private List<string> loadedDatas;
    private List<string> currentDatas;
    public Slider slider;
    public ReactiveProperty<float> MeterGauge = new ReactiveProperty<float>();
    [SerializeField]float defaultGaugeMax,rechargeAmount;
    bool isRecharging;
    float reChargeTimeRemining,lastFrameValue,uIActiveSwitchTimeRemining;


    public void ChangeDataValue(int localSaveNum, string data)
    {
        SaveLoader saveLoader = this.gameObject.GetComponent<SaveLoader>();
        saveLoader.tempDatas[localSaveNum] = data;
        slider.maxValue = float.Parse(data);
    }

    public void DataLoad(List<string> datas)
    {
        loadedDatas = datas;
        currentDatas = loadedDatas;
        if(datas[0] != null && datas[0] != ""){

            slider.maxValue = float.Parse(datas[0]);

        }else{
            SetDefault();
        }
    }

    public void SetDefault()
    {
        ChangeDataValue(0,defaultGaugeMax.ToString());
    }

    void Start(){
        MeterGauge.Subscribe(x => ValueChanged(x)).AddTo(this);
        this.UpdateAsObservable().Where(_ => slider.value != slider.maxValue).Subscribe(_ => {if(reChargeTimeRemining >= 0){reChargeTimeRemining -= Time.deltaTime;}else{Recharge();}}).AddTo(this);
        this.UpdateAsObservable().Where(_ => slider.value == slider.maxValue).Subscribe(_ => {if(uIActiveSwitchTimeRemining >= 0){uIActiveSwitchTimeRemining -= Time.deltaTime;}else{slider.gameObject.SetActive(false);}}).AddTo(this);
    }

    void ValueChanged(float x){
        slider.value = x;
        if(!slider.gameObject.activeInHierarchy){
            slider.gameObject.SetActive(true);
        }
        if(lastFrameValue > x){
            reChargeTimeRemining = 1.5f;
        }
        uIActiveSwitchTimeRemining = 2f;
        lastFrameValue = x;
    }

    void Recharge(){
        
        if(MeterGauge.Value != slider.maxValue){
            MeterGauge.Value = Mathf.Clamp(MeterGauge.Value + Time.deltaTime * rechargeAmount, slider.minValue ,slider.maxValue);
        }
    }
}