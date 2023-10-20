using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using Cysharp.Threading.Tasks;
using System.Threading;
using UnityEngine.PlayerLoop;

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


    public Subject<Unit> SwitchChaseStateEvent = new Subject<Unit>();

    public EnemyPatrolState(EnemyMovePresenter movePresenter,EnemyAnimationPresenter animationPresenter,EnemyDetectPresenter detectPresenter)
    {
        this.movePresenter = movePresenter;
        this.animationPresenter = animationPresenter;
        this.detectPresenter = detectPresenter;

        cancellationTokenSource = new CancellationTokenSource();

        movePresenter.EnemyMovingEvent.Subscribe(_ => { animationPresenter.EnemyMove(1f); });
        movePresenter.EnemyIdleEvent.Subscribe(_ => { animationPresenter.EnemyIdle(); });
        movePresenter.EnemyArrivalEvent.Subscribe(async _ => { await StopPatrolMove(cancellationTokenSource.Token); });

        detectPresenter.EnemyFindTargetEvent.Subscribe(_ => { StopState(); SwitchChaseStateEvent.OnNext(Unit.Default); });
    }

    public void StartState()
    {
        StartPatrolMove();
    }

    public void StopState()
    {
        cancellationTokenSource.Cancel();
    }


    public void StartPatrolMove()
    {
        var result = Random.Range(0f, 100f);
        currentPatrolDirection = (result > 50f) ? -1 : 1;

        movePresenter.StartMoveAction(currentPatrolDirection, Random.Range(minMoveTime, maxMoveTime));
    }

    public async UniTask StopPatrolMove(CancellationToken cancellationToken)
    {
        await UniTask.WaitForSeconds
            (Random.Range(minIdleTime,maxIdleTime),false,PlayerLoopTiming.Update,cancellationToken);
        StartPatrolMove();
    }

}
