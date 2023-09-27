using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleporterOfHub : MonoBehaviour,IInteractable
{
    [SerializeField]string targetSceneName;
    [SerializeField]Vector3 targetPosition;

    public void OnInteract()
    {   
        PlayerStateMgr.instance.gameObject.transform.position = targetPosition;
        SceneLoader.LoadSceneSingle(targetSceneName);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
