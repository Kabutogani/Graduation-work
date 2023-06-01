using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecoyObj : MonoBehaviour
{
    [SerializeField]private float _maxDeceiveTime = 5,_currentDeceiveTime;

    // Start is called before the first frame update
    void Start()
    {
        _currentDeceiveTime = _maxDeceiveTime;
    }

    void OnTriggerStay(Collider collider){
        if(collider.gameObject.tag == "Enemy"){
            _currentDeceiveTime -= Time.deltaTime;
            Debug.Log("Enemy Hit Decoy");
        }
        if(_currentDeceiveTime <= 0){
            Destroy(this.gameObject);
        }
    }
}
