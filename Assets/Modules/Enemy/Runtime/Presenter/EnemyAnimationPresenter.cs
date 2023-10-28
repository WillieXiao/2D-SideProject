using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationPresenter
{
    private EnemyAnimation enemyAnimation;

    public EnemyAnimationPresenter(EnemyAnimation enemyAnimation)
    {
        this.enemyAnimation = enemyAnimation;
    }

    public void EnemyIdle()
    {
        enemyAnimation.OnIdle();
    }

    public void EnemyMove(float value)
    {
        enemyAnimation.OnMove(value);
    }

    public void EnemyAttack()
    {
        enemyAnimation.OnAttack();
    }

}

