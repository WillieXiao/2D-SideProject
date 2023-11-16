using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class EnemyFightPresenter
{
    private EnemyFight enemyFight;

    public bool IsAttacking => enemyFight.IsAttacking;

    public Subject<Unit> EnemyNeedAttackEvent = new Subject<Unit>();

    public EnemyFightPresenter(EnemyFight fight)
    {
        enemyFight = fight;

        enemyFight.CoolDownEndEvent.Subscribe(_ => { CheckCurrentAttackState(); });
    }

    public void CheckCurrentAttackState()
    {
        if (enemyFight.IsAttacking == true)
            return;

        EnemyNeedAttackEvent.OnNext(Unit.Default);
        enemyFight.SetAttackState(true);
        enemyFight.SetWeaponCollierState(true);
        //EnemyNeedAttackEvent.OnNext(playerFight.CurrentAttackCount);
        //Debug.Log(playerFight.CurrentAttackCount);
        //playerFight.ResetAttackLevelCoolDown();
        //playerFight.SetAttackState(true);
    }
}
