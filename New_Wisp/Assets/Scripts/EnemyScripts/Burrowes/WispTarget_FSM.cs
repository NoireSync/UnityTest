using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* NOTE - More states can be added or removed */
public enum ISTATES
{
    IDLING,
    CHASING,
    ATTACKING
    // RETREATING
}

public class WispTarget_FSM : Enemy_Base
{
    // State variable
    public ISTATES _currentState;
    // Transform to target the player or wisp
    public Transform targetWho;
    // Chase state variable for the distance between the enemy and target
    public float chaseRange;
    // Attack state variable for the distance between the enemy and target
    public float attackRange;

    void Start()
    {
        _currentState = ISTATES.IDLING;
        // Set the enemy's target
        targetWho = GameObject.FindGameObjectWithTag("Wisp").transform;
    }

    void FixedUpdate()
    {
        DistanceCheck();

        switch (_currentState)
        {
            case ISTATES.IDLING:
                Debug.Log("idling");
                DistanceCheck();

                if (Vector2.Distance(transform.position, targetWho.transform.position) <= chaseRange &&
                Vector2.Distance(transform.position, targetWho.transform.position) > attackRange)
                {
                    _currentState = ISTATES.CHASING;
                }

                break;

            case ISTATES.CHASING:
                transform.position = Vector2.MoveTowards(transform.position, targetWho.transform.position, speed * Time.deltaTime);
                //DistanceCheck();
                Debug.Log("chasing");

                if (Vector2.Distance(transform.position, targetWho.transform.position) < attackRange)
                {
                    _currentState = ISTATES.ATTACKING;
                }
                else
                {
                    _currentState = ISTATES.IDLING;
                }

                break;

            case ISTATES.ATTACKING:
                //transform.position = Vector2.MoveTowards(transform.position, targetWho.transform.position, speed * Time.deltaTime);
                //DistanceCheck();
                Debug.Log("attacking");


                break;
        }
    }

    void DistanceCheck()
    {
        if (Vector2.Distance(transform.position, targetWho.transform.position) <= chaseRange &&
        Vector2.Distance(transform.position, targetWho.transform.position) > attackRange)
        {
            //Debug.Log("chasing");
            transform.position = Vector2.MoveTowards(transform.position, targetWho.transform.position, speed * Time.deltaTime);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (_currentState == ISTATES.ATTACKING)
        {
            if (other.collider.CompareTag("Player"))
            {
                Debug.Log("wisp hit");
                // Take away player hp

            }

        }
    }
}