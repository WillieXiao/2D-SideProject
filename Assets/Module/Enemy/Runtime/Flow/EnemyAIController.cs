using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer;
using UniRx;

public class EnemyAIController
{
    [Inject]
    private EnemyPatrolState enemyPatrolState;
    [Inject]
    private EnemyMovePresenter movePresenter;

    public EnemyAIController()
    {
        enemyPatrolState.SwitchChaseStateEvent.Subscribe(_ => { ChaseFlow();});
    }

    public void Initialize()
    {
        PatrolFlow();
    }

    public void PatrolFlow()
    {
        enemyPatrolState.StartState();
    }

    public void ChaseFlow()
    {
        enemyPatrolState.StartState();
    }

}
