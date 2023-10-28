using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UniRx;
using UnityEngine;

public class EnemyFightState
{
    private EnemyMovePresenter movePresenter;
    private EnemyAnimationPresenter animationPresenter;
    private EnemyDetectPresenter detectPresenter;
    private EnemyFightPresenter fightPresenter;

    private bool statusIsActive = false;

    public Subject<Unit> SwitchPatrolStateEvent = new Subject<Unit>();

    public EnemyFightState(EnemyMovePresenter movePresenter, EnemyAnimationPresenter animationPresenter, EnemyDetectPresenter detectPresenter, EnemyFightPresenter fightPresenter)
    {
        this.movePresenter = movePresenter;
        this.animationPresenter = animationPresenter;
        this.detectPresenter = detectPresenter;
        this.fightPresenter = fightPresenter;

        movePresenter.EnemyMovingEvent.Subscribe(_ => { animationPresenter.EnemyMove(1f); });
        movePresenter.EnemyIdleEvent.Subscribe(_ => { animationPresenter.EnemyIdle(); });

        detectPresenter.EnemyCloseToTargetEvent.Subscribe(_ =>
        {
            if (statusIsActive == false)
                return;
            StartChaseTarget();
        });
        detectPresenter.EnemyLostTargetEvent.Subscribe(_ =>
        {
            if (statusIsActive == true)
                SwitchPatrolStateEvent.OnNext(Unit.Default);
        });
        
        detectPresenter.EnemyReachTargetEvent.Subscribe(_ =>
        {
            if (statusIsActive == false)
                return;
            StopChaseTarget();
            StartAttackTarget();

        });

        fightPresenter.EnemyNeedAttackEvent.Subscribe(_ => 
        {
            AttackTargetFlow();
        });

    }

    public void StartState()
    {
        statusIsActive = true;
        StartChaseTarget();
    }

    public void StartChaseTarget()
    {
        if (detectPresenter.GetTarget() != null && fightPresenter.IsAttacking == false)
        {
            movePresenter.StartMoveAction(detectPresenter.GetTarget().transform.position);
        }

        //detectPresenter.GetTarget;
    }

    public void StopChaseTarget()
    {
        movePresenter.StartStopAction();
    }

    public void StartAttackTarget()
    {
        if (detectPresenter.GetTarget() != null)
        {
            fightPresenter.CheckCurrentAttackState();
        }

        //detectPresenter.GetTarget;
    }

    public void AttackTargetFlow()
    {
        animationPresenter.EnemyAttack();
        movePresenter.StartStopAction();
    }

    public void StopState()
    {
        statusIsActive = false;

    }

}
