using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationPresenter
{
    PlayerAnimation playerAnimation;
    public PlayerAnimationPresenter(PlayerAnimation playerAnimation)
    {
        this.playerAnimation = playerAnimation;
    }

    public void CharacterIdle()
    {
        playerAnimation.OnIdle();
    }

    public void CharacterMove(float value)
    {
        playerAnimation.OnMove(value);
    }

    public void CharacterJump()
    {
        playerAnimation.OnGeneralJump();
    }

    public void CharacterAirJump()
    {
        playerAnimation.OnAirJump();
    }

    public void CharacterLand()
    {
        playerAnimation.OnLand();
    }

    public void CharacterFall()
    {
        playerAnimation.OnFall();
    }
    
    public void CharacterAttack(int attackIndex)
    {
        playerAnimation.OnAttack(attackIndex);
    }
}
