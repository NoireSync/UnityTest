using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room_Transfer : MonoBehaviour
{
    public Vector2 cameraChange;
    //public Vector2 cameraChangeMin; // shift the camera min
    //public Vector2 cameraChangeMax; // shift the camera max
    public Vector3 playerChange; // shift the player
    private Camera_Movement cam; // Camera ref

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main.GetComponent<Camera_Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            cam.minPos += cameraChange;
            cam.maxPos += cameraChange;

            other.transform.position += playerChange;
        }
    }*/
}
