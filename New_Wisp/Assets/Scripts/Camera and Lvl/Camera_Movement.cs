using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Movement : MonoBehaviour
{
    // Source: https://www.youtube.com/watch?v=NwsUxJ3kDR4
    public Transform targetPlayer;
    public float smoothing;
    // public Vector2 maxPos;
    // public Vector2 minPos;

    void LateUpdate()
    {
        // If the camera's position isn't the player's position
        if (transform.position != targetPlayer.position)
        {
            Vector3 targetPosition = new Vector3(targetPlayer.position.x, 
                                                targetPlayer.position.y, transform.position.z);

            // Clamp
            /*
            targetPosition.x = Mathf.Clamp(targetPosition.x, minPos.x, maxPos.x);
            targetPosition.y = Mathf.Clamp(targetPosition.y, minPos.y, maxPos.y);
            */


            transform.position = Vector3.Lerp(transform.position, 
                                                targetPosition, smoothing); 
        }
    }
}
