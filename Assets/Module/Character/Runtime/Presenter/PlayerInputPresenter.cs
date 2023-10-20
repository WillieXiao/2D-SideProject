using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class PlayerInputPresenter
{
    private PlayerInput playerInput;

    public Subject<Unit> PlayerStopInputEvent = new Subject<Unit>();
    public Subject<Vector2> PlayerMoveInputEvent = new Subject<Vector2>();
    public Subject<Unit> PlayerJumpInputEvent = new Subject<Unit>();

    public Subject<Unit> PlayerAttackInputEvent = new Subject<Unit>();

    public PlayerInputPresenter(PlayerInput playerInput)
    {
        this.playerInput = playerInput;

        this.playerInput.StopInputEvent.Subscribe( _=>
        {
            PlayerStopInputEvent.OnNext(Unit.Default);

        });

        this.playerInput.MoveInputEvent.Subscribe(vector2=> 
        { 
            PlayerMoveInputEvent.OnNext(vector2); 

        });

        this.playerInput.JumpInputEvent.Subscribe(_ => 
        {
            PlayerJumpInputEvent.OnNext(Unit.Default); 
        });

        this.playerInput.AttackInputEvent.Subscribe(_ =>
        {
            PlayerAttackInputEvent.OnNext(Unit.Default);
        });


    }

   

}
