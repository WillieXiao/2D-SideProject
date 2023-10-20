using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;
using System.Reflection;

public class PlayerFlowController
{
    private readonly PlayerInputPresenter playerInputPresenter;
    private readonly PlayerMovePresenter playerMovePresenter;
    private readonly PlayerAnimationPresenter playerAnimationPresenter;
    private readonly PlayerFightPresenter playerFightPresenter;

    public PlayerFlowController(PlayerInputPresenter inputPresenter,PlayerMovePresenter movePresenter,PlayerAnimationPresenter animationPresenter,PlayerFightPresenter fightPresenter)
    {
        playerInputPresenter = inputPresenter;
        playerMovePresenter = movePresenter;
        playerAnimationPresenter = animationPresenter;
        playerFightPresenter = fightPresenter;

        
    }

    public void Initialize()
    {

        //Player Input Presenter Event

        playerInputPresenter.PlayerStopInputEvent.Subscribe(_=>
        {
            playerAnimationPresenter.CharacterIdle();
        });

        playerInputPresenter.PlayerMoveInputEvent.Subscribe(Vector2 => 
        { 
            playerMovePresenter.CharacterMove(Vector2);
            playerAnimationPresenter.CharacterMove(MathF.Abs(Vector2.x));
        });

        playerInputPresenter.PlayerJumpInputEvent.Subscribe(_ => 
        { 
            playerMovePresenter.CharacterJump();
            playerAnimationPresenter.CharacterJump();

        });

        playerInputPresenter.PlayerAttackInputEvent.Subscribe(_ =>
        {
            playerFightPresenter.CheckCurrentAttackState();

        });

        //Player Move Presenter Event
        playerMovePresenter.PlayerNeedLandEvent.Subscribe(_ => 
        {
            playerAnimationPresenter.CharacterLand();
        });

        playerMovePresenter.PlayerNeedFallEvent.Subscribe(_ =>
        {
            playerAnimationPresenter.CharacterFall();
        });

        //Player Fight Presenter Event
        playerFightPresenter.PlayerNeedAttackEvent.Subscribe(index => 
        {
            AttackFlow(index);
        });

        
    }


    public void AttackFlow(int index)
    {
        playerAnimationPresenter.CharacterAttack(index);
        playerMovePresenter.CharacterSetLockMove(true);
    }
}
