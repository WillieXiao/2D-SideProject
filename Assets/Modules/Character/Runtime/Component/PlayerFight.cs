using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFight : MonoBehaviour
{
    private bool attacking;

    public bool AttackState => attacking;

    private int currentAttackCount;

    public int CurrentAttackCount => currentAttackCount;


    private float attackLevelCoolDownTimer = 1f;

    public void SetAttackState(bool isAttacking)
    {
        attacking = isAttacking;
    }

    public void AddAttackCount()
    {
        currentAttackCount++;
        if (currentAttackCount > 2)
            currentAttackCount = 0;
    }

    public void ResetAttackLevelCoolDown()
    {
        attackLevelCoolDownTimer = 1f;
    }

    private void Update()
    {
        if (attackLevelCoolDownTimer >= 0.9)
        {
            Debug.Log(attackLevelCoolDownTimer);
        }
        
        if (currentAttackCount >= 1 && attacking == false)
        {
            attackLevelCoolDownTimer-=Time.deltaTime;
            if (attackLevelCoolDownTimer <= 0)
            {
                ResetAttackLevelCoolDown();
                currentAttackCount = 0;
            }
        }
    }
}
