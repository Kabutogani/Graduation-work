using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System.Linq;
using System;

public class SearchArea : MonoBehaviour
{
    public List<SearchAble> searchAbles;
    public Subject<GameObject> inSearchAreaEv = new Subject<GameObject>();
    public Subject<GameObject> outSearchAreaEv = new Subject<GameObject>();

    void OnTriggerEnter(Collider collider){
        AddSearchList(collider.gameObject.GetComponent<SearchAble>());
        inSearchAreaEv.OnNext(collider.gameObject);
    }

    void OnTriggerExit(Collider collider){
       RemoveSearchList(collider.gameObject.GetComponent<SearchAble>());
       outSearchAreaEv.OnNext(collider.gameObject);
    }

    void AddSearchList(SearchAble searchAble){
        searchAbles.Add(searchAble);
    }

    void RemoveSearchList(SearchAble searchAble){
         for(int i = 0; i < searchAbles.Count; i++){
            if(searchAbles[i] == searchAble){
                searchAbles.Remove(searchAbles[i]);
            }
        }
    }
}
