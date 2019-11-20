using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* NOTE - More states can be added or removed */
public enum STATES
{
    IDLING,
    CHASING,
    ATTACKING
    // RETREATING
}

public class PlayerTarget_FSM : Enemy_Base
{
    // State variable
    public STATES _currentState;
    // Transform to target the player or wisp
    public Transform targetWho;
    // Chase state variable for the distance between the enemy and target
    public float chaseRange;
    // Attack state variable for the distance between the enemy and target
    public float attackRange;

    void Start()
    {
        _currentState = STATES.IDLING;
        // Set the enemy's target
        targetWho = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void FixedUpdate()
    {
        DistanceCheck();

        switch (_currentState)
        {
            case STATES.IDLING:
                Debug.Log("idling");
                DistanceCheck();

                if (Vector2.Distance(transform.position, targetWho.transform.position) <= chaseRange &&
                Vector2.Distance(transform.position, targetWho.transform.position) > attackRange)
                {
                    _currentState = STATES.CHASING;
                }

                break;

            case STATES.CHASING:
                transform.position = Vector2.MoveTowards(transform.position, targetWho.transform.position, speed * Time.deltaTime);
                //DistanceCheck();
                Debug.Log("chasing");

                if (Vector2.Distance(transform.position, targetWho.transform.position) < attackRange)
                {
                    _currentState = STATES.ATTACKING;
                }
                else
                {
                    _currentState = STATES.IDLING;
                }

                break;

            case STATES.ATTACKING:
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
        if (_currentState == STATES.ATTACKING)
        {
            if (other.collider.CompareTag("Player"))
            {
                Debug.Log("player hit");
                // Take away player hp
                
            }

        }
    }
}

