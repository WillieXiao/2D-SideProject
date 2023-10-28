using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using Cysharp.Threading.Tasks;
using System.Threading;
using UnityEngine.PlayerLoop;
using System;
using Unity.VisualScripting.Antlr3.Runtime;

public class EnemyPatrolState
{
    private EnemyMovePresenter movePresenter;
    private EnemyAnimationPresenter animationPresenter;
    private EnemyDetectPresenter detectPresenter;

    private CancellationTokenSource cancellationTokenSource;

    private float minIdleTime = 1f, maxIdleTime = 2f;
    private float minMoveTime = 1f, maxMoveTime = 2f;
    private int currentPatrolDirection = 1;
    private int patrolRange;

    private bool statusIsActive = false;
    public Subject<Unit> SwitchFightStateEvent = new Subject<Unit>();

    public EnemyPatrolState(EnemyMovePresenter movePresenter,EnemyAnimationPresenter animationPresenter,EnemyDetectPresenter detectPresenter)
    {
        this.movePresenter = movePresenter;
        this.animationPresenter = animationPresenter;
        this.detectPresenter = detectPresenter;

        movePresenter.EnemyMovingEvent.Subscribe(_ => { animationPresenter.EnemyMove(1f); });
        movePresenter.EnemyIdleEvent.Subscribe(_ => { animationPresenter.EnemyIdle(); });
        detectPresenter.EnemyFindTargetEvent.Subscribe(_ => 
        { 
            if(statusIsActive == true)
                SwitchFightStateEvent.OnNext(Unit.Default);
        });

    }

    public async UniTask StartState()
    {
        statusIsActive = true;
        cancellationTokenSource = new CancellationTokenSource();
        await StartPatrolMove(cancellationTokenSource.Token);
    }

    public void StopState()
    {
        statusIsActive = false;
        cancellationTokenSource.Cancel();
        cancellationTokenSource = null;
    }


    public async UniTask StartPatrolMove(CancellationToken cancellationToken)
    {
        if (cancellationToken.IsCancellationRequested)
        {
            return;
        }

        movePresenter.StartRandomMoveAction();

        await UniTask.WaitForSeconds(UnityEngine.Random.Range(minMoveTime, maxMoveTime), cancellationToken: cancellationToken);

        await StopPatrolMove(cancellationToken);

        
    }

    public async UniTask StopPatrolMove(CancellationToken cancellationToken)
    {
        if (cancellationToken.IsCancellationRequested)
        {
            return;
        }

        movePresenter.StartStopAction();

        await UniTask.WaitForSeconds(UnityEngine.Random.Range(minIdleTime, maxIdleTime), cancellationToken: cancellationToken);

        await StartPatrolMove(cancellationToken);
    }

}
