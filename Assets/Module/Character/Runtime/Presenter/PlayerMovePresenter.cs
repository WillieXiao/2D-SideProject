using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class PlayerMovePresenter
{
    private PlayerMove playerMove;

    public Subject<Unit> PlayerNeedLandEvent = new Subject<Unit>();
    public Subject<Unit> PlayerNeedFallEvent = new Subject<Unit>();

    public PlayerMovePresenter(PlayerMove playerMove)
    {
        this.playerMove = playerMove;

        playerMove.LandingEvent.Subscribe(_ => { PlayerNeedLandEvent.OnNext(Unit.Default); });
        playerMove.FallingEvent.Subscribe(_ => { PlayerNeedFallEvent.OnNext(Unit.Default); });
    }

    public void CharacterJump()
    {
        playerMove.OnJump();
    }

    public void CharacterMove(Vector2 moveDirection)
    {
        playerMove.OnMove(moveDirection);
    }

    public void CharacterSetLockMove(bool lockMove)
    {
        playerMove.SetLockMove(lockMove);
    }

}
