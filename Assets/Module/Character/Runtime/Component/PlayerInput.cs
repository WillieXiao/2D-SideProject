using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    //General 
    public Subject<Unit> StopInputEvent = new Subject<Unit>();

    public Subject<Vector2> MoveInputEvent = new Subject<Vector2>();

    public Subject<Unit> JumpInputEvent = new Subject<Unit>();

    //Fight 
    public Subject<Unit> AttackInputEvent = new Subject<Unit>();
    public Subject<Unit> AttackTwoInputEvent = new Subject<Unit>();
    public Subject<Unit> AttackThreeInputEvent = new Subject<Unit>();

    void Start()
    {
        
    }

    void Update()
    {
        GeneralInput();

        FightInput();
    }

    public void GeneralInput()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        bool jumpInput = Input.GetKeyDown(KeyCode.Space);

        Vector2 moveDirection = new Vector2(horizontalInput, 0).normalized;

        if (moveDirection.normalized.magnitude > 0.01f)
        {
            MoveInputEvent.OnNext(moveDirection);
        }
        else
        {
            StopInputEvent.OnNext(Unit.Default);
        }

        if (jumpInput == true)
        {
            JumpInputEvent.OnNext(Unit.Default);
        }
    }

    public void FightInput()
    {
        bool attack = Input.GetKeyDown(KeyCode.F);

        if (attack == false)
            return;

        AttackInputEvent.OnNext(Unit.Default);

    }

}
