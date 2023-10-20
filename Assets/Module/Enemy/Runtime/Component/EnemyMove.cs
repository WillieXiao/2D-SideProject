using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;

    private Rigidbody2D rigidbody;
    private CapsuleCollider2D capsuleCollider;

    private int direction;
    private float durationTime;
    private bool isArrival = true;
    private bool facingRight = false;

    public Subject<Unit> IdleEvent = new Subject<Unit>();
    public Subject<Unit> MovingEvent = new Subject<Unit>();
    public Subject<Unit> ArrivalEvent = new Subject<Unit>();
    
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        capsuleCollider = GetComponent<CapsuleCollider2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if(isArrival == false)
        {
            if(durationTime <= 0)
            {
                isArrival = true;
                IdleEvent.OnNext(Unit.Default);
                ArrivalEvent.OnNext(Unit.Default);
                return;
            }

            rigidbody.velocity = new Vector2 (direction * moveSpeed, rigidbody.velocity.y);
            MovingEvent.OnNext(Unit.Default);
            durationTime -= Time.deltaTime;
        }
    }

    public void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }


    public void SetDirection(int dir)
    {
        direction = dir;
        isArrival = false;

        if (direction > 0 && !facingRight)
            Flip();
        else if (direction < 0 && facingRight)
            Flip();
    }

    public void SetMoveDurationTime(float time)
    {
        durationTime = time;
    }
}
