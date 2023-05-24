using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField]SearchArea searchArea;
    public Rigidbody _rigidbody;
    protected NavMeshAgent _navMeshAgent;

    // Start is called before the first frame update
    void Start()
    {
        searchArea.inSearchAreaEv.Subscribe(x => InSearchArea(x, true)).AddTo(gameObject);
        searchArea.outSearchAreaEv.Subscribe(x => InSearchArea(x, false)).AddTo(gameObject);
        _rigidbody = GetComponent<Rigidbody>();
        _navMeshAgent = GetComponent<NavMeshAgent>();
        WithStart();
    }

    public virtual void InSearchArea(GameObject target, bool b){
        
    }

    public virtual void WithStart(){

    }

    public GameObject SearchToSearchableRay(){
        GameObject g;
        RaycastHit hitInfo;
        if(searchArea.searchAbles.Count != 0){
            if(Physics.Raycast(gameObject.transform.position, searchArea.searchAbles[0].gameObject.transform.position - gameObject.transform.position ,out hitInfo, 100000f, 1 << 8)){
                g = hitInfo.collider.gameObject;
            }else{
                g = null;
            }
        }else{
            g= null;
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

    public GameObject GetNearestObjWithTag(string tagName){
        GameObject g = null;
        GameObject[] objects = null;

        objects = GameObject.FindGameObjectsWithTag(tagName);
        foreach(var i in objects){
            if(g == null){
                g = i;
            }else{
                if(Vector3.Distance(g.transform.position, gameObject.transform.position) > Vector3.Distance(i.transform.position, gameObject.transform.position)){
                    g = i;
                }
            }
        }
        return g;
    }

    public EnemyRoute GetNextRouteByNowRoute(EnemyRoute nowRoute, EnemyRoute beforeRoute){ 
        EnemyRoute nextRoute = null;
        List<EnemyRoute> nextRouteList = null;
        var tmpRouteList = new List<EnemyRoute>();
        nextRouteList = nowRoute.AdjoiningRoute;

        foreach(EnemyRoute i in nextRouteList){
            if(i != beforeRoute){
                tmpRouteList.Add(i);
            }
        }
        
        nextRoute = tmpRouteList[Random.Range(0, tmpRouteList.Count)];
        return nextRoute;
    }
}