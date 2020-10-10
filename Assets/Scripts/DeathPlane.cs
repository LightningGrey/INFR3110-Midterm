using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathPlane : MonoBehaviour
{
    public GameObject checkpoint;
    
    
    void OnCollisionEnter(Collision collision)
    {
        //reset character and camera to checkpoint
        collision.transform.position = checkpoint.transform.position;
        Camera.main.transform.position = collision.transform.position + new 
            Vector3 (0.0f, 4.5f, 0.0f);
    }
}
