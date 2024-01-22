using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LionAwake : MonoBehaviour
{
    [SerializeField]SkinnedMeshRenderer skinnedMeshRenderer;
    [SerializeField]Material[] materials;
    [SerializeField]Lion lion;
    [SerializeField]GameObject chasePos;
    public void LionAwakeEvent(){
        Material[] beforeMaterials = skinnedMeshRenderer.sharedMaterials;
        beforeMaterials[0] = materials[1];
        skinnedMeshRenderer.materials = beforeMaterials;
        Debug.Log("LionAwake");
    }

    public void LionSleepEvent(){
        Material[] beforeMaterials = skinnedMeshRenderer.sharedMaterials;
        beforeMaterials[0] = materials[0];
        skinnedMeshRenderer.materials = beforeMaterials;
        Debug.Log("LionSleep");
    }

    public void LionRunEvent(){
        lion.SwitchMode(Lion.Mode.Chase);
        //lion.gameObject.transform.position = chasePos.transform.position;
    }
}
