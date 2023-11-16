using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalAttackOne : StateMachineBehaviour
{
    private PlayerMove playerMove;
    private PlayerFight playerFight;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (playerMove == null)
            playerMove = animator.gameObject.GetComponent<PlayerMove>();
        if (playerFight == null)
            playerFight = animator.gameObject.GetComponent<PlayerFight>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        playerMove.SetLockMove(false);
        playerFight.SetAttackState(false);
        playerFight.SetWeaponCollierState(false);
        playerFight.AddAttackCount();
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}

    public override void OnStateMachineEnter(Animator animator, int stateMachinePathHash)
    {
        Debug.Log("~~~");
    }
}
