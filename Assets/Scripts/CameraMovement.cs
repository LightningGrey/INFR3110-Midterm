using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private Vector3 targetPos;
    public Rigidbody player;
    private Vector3 velocity = Vector3.zero;
    private Vector3 offset = new Vector3(0.0f, 4.5f, 0.0f);

    // Update is called once per frame
    void FixedUpdate()
    { 
        //camera follows player
        targetPos = player.transform.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, 0.01f);
    }
}
