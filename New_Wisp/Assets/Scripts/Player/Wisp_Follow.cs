using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wisp_Follow : MonoBehaviour
{
    public static Wisp_Follow instance;
    public float speed;
    public Transform target;
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(transform.position, target.position) > 3)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
    }
}
