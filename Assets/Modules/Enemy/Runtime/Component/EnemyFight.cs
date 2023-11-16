using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;


public class EnemyFight : MonoBehaviour
{
    [SerializeField]
    private Collider2D weaponCollider;

    private bool isAttacking = false;
    public bool IsAttacking => isAttacking;

    private bool isCoolDown;
    public bool IsCoolDown => isCoolDown;

    private int currentAttackCount;
    public int CurrentAttackCount => currentAttackCount;


    private float attackCoolDownTimer = 0f;

    public Subject<Unit> CoolDownEndEvent = new Subject<Unit>();

    public void SetAttackState(bool isAttacking)
    {
        this.isAttacking = isAttacking;
    }
    public void ResetAttackCoolDown()
    {
        attackCoolDownTimer = 1f;
    }

    public void AddAttackCount()
    {
        currentAttackCount++;
    }

    private void Update()
    {
        if (isAttacking == false && attackCoolDownTimer>0)
        {
            isCoolDown = true;
            attackCoolDownTimer -= Time.deltaTime;
            if (attackCoolDownTimer <= 0)
            {
                isCoolDown = false;
                ResetAttackCoolDown();
                CoolDownEndEvent.OnNext(Unit.Default);
                currentAttackCount = 0;
            }
        }
    }

    public void SetWeaponCollierState(bool state)
    {
        weaponCollider.enabled = state;
    }
}
