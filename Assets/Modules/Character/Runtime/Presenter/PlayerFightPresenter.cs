using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class PlayerFightPresenter
{
    private PlayerFight playerFight;

 

    public bool attacking = false;

    public Subject<int> PlayerNeedAttackEvent = new Subject<int>();

    public PlayerFightPresenter(PlayerFight fight)
    {
        playerFight = fight;

    }


    public void CheckCurrentAttackState()
    {
        if (playerFight.AttackState == true)
            return;
        PlayerNeedAttackEvent.OnNext(playerFight.CurrentAttackCount);
        Debug.Log(playerFight.CurrentAttackCount);
        playerFight.ResetAttackLevelCoolDown();
        playerFight.SetAttackState(true);
        playerFight.SetWeaponCollierState(true);
    }
}
