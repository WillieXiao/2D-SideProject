using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer;
using UniRx;
using Unity.VisualScripting;
using Cysharp.Threading.Tasks;

public class EnemyAIController
{
    [Inject]
    private EnemyPatrolState enemyPatrolState;
    [Inject]
    private EnemyFightState enemyFightState;

    [Inject]
    private EnemyMovePresenter movePresenter;

    public EnemyAIController()
    {
        
    }

    public void Initialize()
    {
        enemyPatrolState.SwitchFightStateEvent.Subscribe(_ => { enemyPatrolState.StopState(); FightFlow(); });
        enemyFightState.SwitchPatrolStateEvent.Subscribe(_ => { enemyFightState.StopState(); PatrolFlow().Forget(); });
        PatrolFlow().Forget();
    }

    public async UniTask PatrolFlow()
    {
        await enemyPatrolState.StartState();
    }

    public void FightFlow()
    {
        enemyFightState.StartState();
    }

}
