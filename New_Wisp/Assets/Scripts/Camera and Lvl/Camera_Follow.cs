using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Follow : MonoBehaviour
{
    // Mario style camera script
    public float cameraResetSpeed = 0.5f;
    public float camSpeed = 0.3f;
    public Bounds cameraBounds;
    private Transform target;
    private float offSetZ;
    private Vector3 lastTargertPosition;
    private Vector3 cameraCurrentVelocity;
    private bool cameraFollowingPlayer;

    //
    void Awake()
    {
        BoxCollider2D camCol = GetComponent<BoxCollider2D>();
        camCol.size = new Vector2(Camera.main.aspect * 2f * Camera.main.orthographicSize, 15f); // X axis
        cameraBounds = camCol.bounds;
    }


    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        lastTargertPosition = target.position;
        offSetZ = (transform.position - target.position).z;
        cameraFollowingPlayer = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (cameraFollowingPlayer)
        {
            Vector3 aheadTargetPos = target.position + Vector3.forward * offSetZ;
            if(aheadTargetPos.x >= transform.position.x)
            {
                Vector3 newCamPos = Vector3.SmoothDamp(transform.position, aheadTargetPos, ref cameraCurrentVelocity, camSpeed);
                transform.position = new Vector3(newCamPos.x, transform.position.y, newCamPos.z);
                lastTargertPosition = target.position;
            }
        }
    }





}
