using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Unity.Collections;

public class ChaseEnemy : Enemy
{
    public enum Mode{
        Idle,
        Patrol,
        Caution,
        Chase
    }

    [SerializeField, ReadOnly]public Mode _currentMode = Mode.Idle;
    [SerializeField]protected float chaseSpeed,patrolSpeed;
    [SerializeField]public GameObject _firstTargetRoute;
    [SerializeField]protected EnemyRoute _nextRoute,_beforeRoute;
    [SerializeField]protected RouteCheckArea routeCheckArea;
    [SerializeField]protected float _chaseTimeRemaining;
    [SerializeField]protected float _maxChaseTime = 7f;
    [SerializeField]protected GameObject _chaseTarget;

    // Update is called once per frame
    void Update()
    {
        
    }
}
