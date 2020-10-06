using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathPlane : MonoBehaviour
{
    public GameObject checkpoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        collision.transform.position = checkpoint.transform.position;
        Camera.main.transform.position = collision.transform.position + new 
            Vector3 (0.0f, 4.5f, 0.0f);
    }
}
