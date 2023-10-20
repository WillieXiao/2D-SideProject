using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
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
        animator.SetFloat("Speed",0f);
    }

    public void OnMove(float value)
    {
        animator.SetFloat("Speed", value);
    }
}
