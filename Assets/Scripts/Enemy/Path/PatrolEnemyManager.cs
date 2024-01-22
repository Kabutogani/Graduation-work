using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolEnemyManager : MonoBehaviour
{
    public PatrolEnemy[] patrolEnemies;
    [SerializeField]float timeCount,maxTimeCount;
    [SerializeField]EnemyRoute[] enemyRoutes;
    private int nextSpawnRouteNum;
    private bool isNowPatrol;
    
    void Update(){
        if(!isNowPatrol){
            timeCount += Time.deltaTime;
            if(maxTimeCount < timeCount){
                PatrolStart();
                Debug.Log("patrol Start");
            }
        }
    }

    void Start(){
        nextSpawnRouteNum = Random.Range(0,2);
        isNowPatrol = false;
    }

    public void PatrolEnd(PatrolEnemy patrolEnemy){
        patrolEnemy.gameObject.SetActive(false);
        isNowPatrol = false;
        if(nextSpawnRouteNum == 0){
            nextSpawnRouteNum = 1;
        }else{
            nextSpawnRouteNum = 0;
        }
    }

    public void PatrolStart(){
        PatrolEnemy patrolEnemey = patrolEnemies[Random.Range(0,patrolEnemies.Length)];
        if(nextSpawnRouteNum == 0){
            Vector3 t = enemyRoutes[1].transform.position;
            t.y = t.y + 1f;
            patrolEnemey.gameObject.transform.position = t;
        }else{
            Vector3 t = enemyRoutes[0].transform.position;
            t.y = t.y + 1f;
            patrolEnemey.gameObject.transform.position = t;
        }
        patrolEnemey.gameObject.SetActive(true);
        patrolEnemey._firstTargetRoute = enemyRoutes[nextSpawnRouteNum].gameObject;
        patrolEnemey.SwitchMode(ChaseEnemy.Mode.Patrol);
        isNowPatrol = true;
        timeCount = 0f;
    }
}
