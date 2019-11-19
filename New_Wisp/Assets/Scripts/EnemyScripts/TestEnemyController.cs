using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemyController : MonoBehaviour
{
    public Rigidbody2D rigBDY2D;
    public float moveSpeed;
    public float viewToChaseTarget;
    private Vector3 moveDir;
    public Animator anime;
    public int health = 25;

    [Header("Variables")]
    public SpriteRenderer theBody;
    public Animator anim;

    void Start()
    {
        
    }

    void Update()
    {

        if (theBody.isVisible && PlayerController.instance.gameObject.activeInHierarchy)
        {
            moveDir = PlayerController.instance.transform.position - transform.position;
        }
        else
        {
            moveDir = Vector3.zero;
        }
        moveDir.Normalize();
        rigBDY2D.velocity = moveDir * moveSpeed;

        if(moveDir != Vector3.zero)
        {
            anime.SetBool("isMoving", true);
        }
        else
        {
            anime.SetBool("isMoving", false);
        }
    }
    public void DamageEnemy(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}