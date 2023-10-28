using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System.Threading;

public class EnemyChaseState
{
    private EnemyMovePresenter movePresenter;
    private EnemyAnimationPresenter animationPresenter;
    private EnemyDetectPresenter detectPresenter;

    private CancellationTokenSource cancellationTokenSource;

    private bool statusIsActive = false;

    public Subject<Unit> SwitchPatrolStateEvent = new Subject<Unit>();
    public Subject<Unit> SwitchAttackStateEvent = new Subject<Unit>();

    public EnemyChaseState(EnemyMovePresenter movePresenter, EnemyAnimationPresenter animationPresenter, EnemyDetectPresenter detectPresenter)
    {
        this.movePresenter = movePresenter;
        this.animationPresenter = animationPresenter;
        this.detectPresenter = detectPresenter;

        movePresenter.EnemyMovingEvent.Subscribe(_ => { animationPresenter.EnemyMove(1f); });
        movePresenter.EnemyIdleEvent.Subscribe(_ => { animationPresenter.EnemyIdle(); });

        detectPresenter.EnemyLostTargetEvent.Subscribe(_ =>
        {
            if (statusIsActive == true)
                SwitchPatrolStateEvent.OnNext(Unit.Default);
        });

        detectPresenter.EnemyReachTargetEvent.Subscribe(_ =>
        {
            if (statusIsActive == true)
                SwitchAttackStateEvent.OnNext(Unit.Default);
        });
    }

    public void StartState()
    {
        statusIsActive = true;
        StartChaseTarget();
    }

    public void StopState()
    {
        statusIsActive = false;
        StopChaseTarget();
    }

    public void StartChaseTarget()
    {
        //if(detectPresenter.GetTarget() != null)
        //{
        //    movePresenter.StartMoveAction(detectPresenter.GetTarget().transform.position,false);
        //}
        
        //detectPresenter.GetTarget;
    }

    public void StopChaseTarget()
    {
        movePresenter.StartStopAction();
    }

}
