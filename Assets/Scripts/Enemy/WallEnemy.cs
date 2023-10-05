using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallEnemy : Enemy
{
    private Vector3 defaultPosition;
    private GameObject targetObj;
    private bool isSearch;
    [SerializeField] GameObject enemyBody;
    [SerializeField] BoxCollider boxCollider;

    public override void InSearchArea(GameObject target, bool b){
        isSearch = b;
        if(b){
            targetObj = target;
        }else{
            targetObj = null;
            enemyBody.transform.position = defaultPosition;
        }
    }

    public override void WithStart(){
        defaultPosition = enemyBody.transform.position;
    }

    void Update()
    {
        if(isSearch){
            Vector3 point = targetObj.transform.position;
            point.y = defaultPosition.y;
            enemyBody.transform.position = boxCollider.ClosestPoint(point);

        }
    }
}
