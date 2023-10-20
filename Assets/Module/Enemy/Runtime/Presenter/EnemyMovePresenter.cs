using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class EnemyMovePresenter
{
    private EnemyMove enemyMove;

    public Subject<Unit> EnemyIdleEvent = new Subject<Unit>();
    public Subject<Unit> EnemyMovingEvent = new Subject<Unit>();
    public Subject<Unit> EnemyArrivalEvent = new Subject<Unit>();

    public EnemyMovePresenter(EnemyMove enemyMove)
    {
        this.enemyMove = enemyMove;

        enemyMove.IdleEvent.Subscribe(_ => { EnemyIdleEvent.OnNext(Unit.Default); });
        enemyMove.MovingEvent.Subscribe(_ => { EnemyMovingEvent.OnNext(Unit.Default); });
        enemyMove.ArrivalEvent.Subscribe(_ => { EnemyArrivalEvent.OnNext(Unit.Default); });
    }

    public void StartMoveAction(int direction,float durationTime)
    {
        enemyMove.SetDirection(direction);
        enemyMove.SetMoveDurationTime(durationTime);
    }


}
