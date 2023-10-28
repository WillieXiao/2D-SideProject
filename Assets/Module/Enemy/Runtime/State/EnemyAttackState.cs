using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState
{
    private EnemyMovePresenter movePresenter;
    private EnemyAnimationPresenter animationPresenter;
    private EnemyDetectPresenter detectPresenter;

    private bool statusIsActive = false;

    public EnemyAttackState(EnemyMovePresenter movePresenter, EnemyAnimationPresenter animationPresenter, EnemyDetectPresenter detectPresenter)
    {
        this.movePresenter = movePresenter;
        this.animationPresenter = animationPresenter;
        this.detectPresenter = detectPresenter;


    }

    public void StartState()
    {
        statusIsActive = true;
        StartAttackTarget();
    }

    public void StartAttackTarget()
    {
        if (detectPresenter.GetTarget() != null)
        {
            animationPresenter.EnemyAttack();
        }

        //detectPresenter.GetTarget;
    }
}
