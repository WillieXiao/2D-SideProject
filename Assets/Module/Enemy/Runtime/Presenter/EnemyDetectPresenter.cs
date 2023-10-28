using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class EnemyDetectPresenter
{
    private EnemyDetect enemyDetect;
    public Subject<Unit> EnemyFindTargetEvent = new Subject<Unit>();
    public Subject<Unit> EnemyCloseToTargetEvent = new Subject<Unit>();
    public Subject<Unit> EnemyLostTargetEvent = new Subject<Unit>();
    public Subject<Unit> EnemyReachTargetEvent = new Subject<Unit>();

    public EnemyDetectPresenter(EnemyDetect enemyDetect)
    {
        this.enemyDetect = enemyDetect;

        enemyDetect.FindTarget.Subscribe(_ => { EnemyFindTargetEvent.OnNext(Unit.Default); });
        enemyDetect.CloseToTarget.Subscribe(_ => { EnemyCloseToTargetEvent.OnNext(Unit.Default); });
        enemyDetect.LostTarget.Subscribe(_ => { EnemyLostTargetEvent.OnNext(Unit.Default); });
        enemyDetect.ReachTarget.Subscribe(_ => { EnemyReachTargetEvent.OnNext(Unit.Default); });
    }

    public GameObject GetTarget()
    {
        return enemyDetect.Target;
    }

    public void StopDetect()
    {
        enemyDetect.OnStopDetect();
    }

    public void StartDetect()
    {
        enemyDetect.OnStartDetect();
    }
}
