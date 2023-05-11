using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

public class Enemy : MonoBehaviour
{
    [SerializeField]SearchArea searchArea;
    public Rigidbody _rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        searchArea.inSearchAreaEv.Subscribe(x => InSearchArea(x, true)).AddTo(gameObject);
        searchArea.outSearchAreaEv.Subscribe(x => InSearchArea(x, false)).AddTo(gameObject);
        _rigidbody = GetComponent<Rigidbody>();
    }

    public virtual void InSearchArea(GameObject target, bool b){
        
    }

    public GameObject SearchToSearchableRay(){
        GameObject g;
        RaycastHit hitInfo;
        if(Physics.Raycast(gameObject.transform.position, searchArea.searchAbles[0].gameObject.transform.position - gameObject.transform.position ,out hitInfo, 100000f, 1 << 8)){
            g = hitInfo.collider.gameObject;
        }else{
            g = null;
        }
        return g;
    }

    public GameObject SearchToObject(){
        GameObject g;
        RaycastHit hitInfo;
        if(Physics.Raycast(gameObject.transform.position, searchArea.searchAbles[0].gameObject.transform.position - gameObject.transform.position ,out hitInfo, 100000f, 1 << 8 | 1<< 6)){
            g = hitInfo.collider.gameObject;
        }else{
            g = null;
        }
        return g;
    }
}
