using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider_FSM : Enemy_Base
{
    /* NOTE - More states can be added or removed 
    public enum STATES
    {
        IDLING,
        CHASING,
        ATTACKING,
        RETREATING
    }*/

    // State variable
    //public STATES current_state;
    // Transform to target the player or wisp
    public Transform target_who;
    // public GameObject target_who;
    // Chase state variable for the distance between the enemy and target
    public float chase_range;
    // Attack state variable for the distance between the enemy and target
    public float attack_range;

    void Start()
    {
        //current_state = STATES.IDLING;
        // Set the enemy's target
        target_who = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        DistanceCheck();
    }

    void DistanceCheck()
    {
        if (Vector2.Distance(transform.position, target_who.transform.position) <= chase_range &&
                Vector2.Distance(transform.position, target_who.transform.position) > attack_range)
        {
            Debug.Log("chasing");
            transform.position = Vector2.MoveTowards(transform.position, target_who.transform.position, speed * Time.deltaTime);
        }
    }

}