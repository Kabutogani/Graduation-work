using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LionAwake : MonoBehaviour
{
    [SerializeField]SkinnedMeshRenderer skinnedMeshRenderer;
    [SerializeField]Material[] materials;
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
}
