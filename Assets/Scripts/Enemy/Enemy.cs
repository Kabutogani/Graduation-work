using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using UnityEngine.AI;

[RequireComponent(typeof(SaveLoader))]
public class Enemy : MonoBehaviour,ILoadableSaveData
{   
    private List<string> loadedDatas;
    private List<string> currentDatas;
    [SerializeField]SearchArea searchArea;
    private Rigidbody _rigidbody;
    protected NavMeshAgent _navMeshAgent;
    public bool isDefaultActive;

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
        if(searchArea.searchAbles.Count != 0 && searchArea.searchAbles[0] != null){
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

    public GameObject GetPlayerObj(){
        GameObject g;
        g = GameObject.FindGameObjectWithTag("Player");
        return g;
    }

    public void DataLoad(List<string> datas)
    {
        loadedDatas = datas;
        currentDatas = loadedDatas;
        if(datas[0] != null && datas[0] != ""){
            if(bool.Parse(datas[0])){
                this.gameObject.SetActive(true);
            }else{
                this.gameObject.SetActive(false);
            }
        }else{
            SetDefault();
            
        }
    }

    public void ChangeDataValue(int localSaveNum, string data)
    {
        SaveLoader saveLoader = this.gameObject.GetComponent<SaveLoader>();
        saveLoader.tempDatas[localSaveNum] = data;
    }

    public void SetDefault()
    {
        ChangeDataValue(0, isDefaultActive.ToString());
        this.gameObject.SetActive(isDefaultActive);
        Debug.Log("setDefault");
    }
}
