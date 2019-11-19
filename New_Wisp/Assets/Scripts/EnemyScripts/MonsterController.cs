using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    public Rigidbody2D _rB;
    public float moveSpeed;

    public float range2ChasePlayer;
    private Vector3 moveDIR;

    public Animator anim;
    public int lifeForce = 125;


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, PlayerController.instance.transform.position) < range2ChasePlayer)
        {
            moveDIR = PlayerController.instance.transform.position - transform.position;
        }
        else
        {
            moveDIR = Vector3.zero;
        }

        moveDIR.Normalize();
        _rB.velocity = moveDIR * moveSpeed;

        //Anime
        if (moveDIR != Vector3.zero)
        {
            anim.SetBool("isMoving", true);
        }
        else
        {
            anim.SetBool("isMoving", false);
        }
    }
    public void DamageMonster(int hurt)
    {
        lifeForce -= hurt;
        if (lifeForce <= 0)
        {
            Destroy(gameObject);
        }
    }

}
