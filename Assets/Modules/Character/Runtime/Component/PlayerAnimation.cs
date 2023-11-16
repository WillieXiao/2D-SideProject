using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnIdle()
    {
        animator.SetFloat("Speed", 0);
    }

    public void OnMove(float value)
    {
        animator.SetFloat("Speed", value);
    }

    public void OnGeneralJump()
    {
        if (animator.GetBool("Landing") == false)
            return;
        animator.SetTrigger("Jump");
        animator.SetBool("Jumping",true);
        animator.SetBool("Landing", false);
        animator.SetBool("Fall", false);
    }

    public void OnAirJump()
    {
        animator.SetTrigger("AirJump");
        animator.SetBool("Jumping", true);
        animator.SetBool("Landing", false);
        animator.SetBool("Fall", false);
    }

    public void OnLand()
    {
        animator.SetBool("Jumping", false);
        animator.SetBool("Landing", true);
        animator.SetBool("Fall", false);
    }

    public void OnFall()
    {
        animator.SetBool("Fall", true);
    }

    public void OnAttack(int index)
    {
        switch (index)
        {
            case 0:
                animator.SetTrigger("AttackOne");
                break;
            case 1:
                animator.SetTrigger("AttackTwo");
                break;
            case 2:
                animator.SetTrigger("AttackThree");
                break;
        }

    }
}
