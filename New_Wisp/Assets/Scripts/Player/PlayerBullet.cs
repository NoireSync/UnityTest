using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    //Source https://www.youtube.com/user/gamesplusjames


    public float speed = 7.5f;
    public float lifeTime;

    //public GameObject impactEffect;

    public int damageToGive = 50;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(gameObject);
        /*if (other.tag == "Enemy")
        {
            other.GetComponent<MonsterController>().DamageMonster(damageToGive);
        }*/
        if(other.tag == "Enemy")
        {
            other.GetComponent<TestEnemyController>().DamageEnemy(damageToGive);
        }

    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
