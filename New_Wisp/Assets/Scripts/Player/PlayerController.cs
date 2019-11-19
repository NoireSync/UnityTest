using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    /*
        Source used: https://www.youtube.com/watch?v=yfsqai3ivyA
        %
        https://www.youtube.com/user/gamesplusjames
    }*/

    public Vector2 movementDirection;
    public float movementSpeed;
    public float speed = 1.0f;
    public GameObject bulletToFire;

    public Rigidbody2D rb;

    public Animator animator;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        
    }
    void Update()
    {
        Character_Input();
        Move();
        Animate();
    }

    void Character_Input()
    {
        movementDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        movementSpeed = movementDirection.magnitude;
    }


    void Move()
    {
        //rb.velocity = movementDirection * speed;
        rb.velocity = movementDirection * movementSpeed *speed;
    }

    void Animate()
    {
        if (movementDirection != Vector2.zero)
        {
            animator.SetFloat("Horizontal", movementDirection.x);
            animator.SetFloat("Vertical", movementDirection.y);
        }
        
        animator.SetFloat("Speed", movementSpeed);
    }
}
