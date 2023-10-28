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

    private Vector2 destination;
    private int direction;
    private float durationTime;
    private bool isResting = true;
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
        if(isResting == false)
        {
            rigidbody.velocity = new Vector2 (direction * moveSpeed, rigidbody.velocity.y);
            MovingEvent.OnNext(Unit.Default);
        }
        else
        {
            IdleEvent.OnNext(Unit.Default);
        }
    }

    public void CheckFlip()
    {
        if (direction > 0 && !facingRight)
            Flip();
        else if (direction < 0 && facingRight)
            Flip();

    }

    public void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }


    public void SetDirection(Vector2 destination)
    {
        this.destination = destination;
        direction = (destination.x > transform.position.x) ? 1 : -1;

        CheckFlip();
    }

    public Vector2 SetRandomDirection()
    {
        int randomSide = UnityEngine.Random.Range(0, 100);
        int randomDistance = UnityEngine.Random.Range(3, 9);
        Vector2 newDestination = 
            new Vector2((randomSide>50)?transform.position.x + randomDistance:transform.position.x - randomDistance, randomDistance);
        return newDestination;
    }

    public void SetResting(bool rest)
    {
        isResting = rest;
    }
}
