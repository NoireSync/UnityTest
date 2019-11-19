using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject bulletToFire;
    public Transform shotPoint;

    public float timeBetweenShots;
    private float shotCounter;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerController.instance)
        {
            if (shotCounter > 0)
            {
                shotCounter -= Time.deltaTime;
            }
            else
            {

                if (Input.GetMouseButtonDown(0) || Input.GetMouseButton(0))
                {
                    Instantiate(bulletToFire, shotPoint.position, shotPoint.rotation);
                    shotCounter = timeBetweenShots;
                    //AudioManager.instance.PlaySFX(12);

                }
            }
        }
    }
}