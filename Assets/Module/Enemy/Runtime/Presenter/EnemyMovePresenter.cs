using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class EnemyMovePresenter
{
    private EnemyMove enemyMove;

    public Subject<Unit> EnemyIdleEvent = new Subject<Unit>();
    public Subject<Unit> EnemyMovingEvent = new Subject<Unit>();

    public EnemyMovePresenter(EnemyMove enemyMove)
    {
        this.enemyMove = enemyMove;

        enemyMove.IdleEvent.Subscribe(_ => { EnemyIdleEvent.OnNext(Unit.Default); });
        enemyMove.MovingEvent.Subscribe(_ => { EnemyMovingEvent.OnNext(Unit.Default); });
    }

    public void StartMoveAction(Vector2 destination)
    {
        enemyMove.SetDirection(destination);
        enemyMove.SetResting(false);
    }

    public void StartRandomMoveAction()
    {
        enemyMove.SetDirection(enemyMove.SetRandomDirection());
        enemyMove.SetResting(false);
    }

    public void StartStopAction()
    {
        enemyMove.SetResting(true);
    }

}
