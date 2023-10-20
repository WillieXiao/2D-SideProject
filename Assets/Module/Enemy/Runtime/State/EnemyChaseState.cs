using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChaseState
{
    private EnemyMovePresenter movePresenter;
    private EnemyAnimationPresenter animationPresenter;
    private EnemyDetectPresenter detectPresenter;

    public EnemyChaseState(EnemyMovePresenter movePresenter, EnemyAnimationPresenter animationPresenter, EnemyDetectPresenter detectPresenter)
    {
        this.movePresenter = movePresenter;
        this.animationPresenter = animationPresenter;
        this.detectPresenter = detectPresenter;


    }

    public void StartState()
    {
        StartChaseTarget();
    }

    public void StartChaseTarget()
    {

        //detectPresenter.GetTarget;
    }
}
