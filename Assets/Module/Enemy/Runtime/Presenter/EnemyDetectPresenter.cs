using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class EnemyDetectPresenter
{
    private EnemyDetect enemyDetect;
    public Subject<Unit> EnemyFindTargetEvent = new Subject<Unit>();
    public Subject<Unit> EnemyLostTargetEvent = new Subject<Unit>();

    public EnemyDetectPresenter(EnemyDetect enemyDetect)
    {
        this.enemyDetect = enemyDetect;

        enemyDetect.FindTarget.Subscribe(_ => { EnemyFindTargetEvent.OnNext(Unit.Default); });
        enemyDetect.LostTarget.Subscribe(_ => { EnemyLostTargetEvent.OnNext(Unit.Default); });

    }

    public GameObject GetTarget()
    {
        return enemyDetect.Target;
    }


}
