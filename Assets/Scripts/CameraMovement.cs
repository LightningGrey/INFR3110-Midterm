using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(new Vector3(0.0f, 3.0f * Time.deltaTime, 0.0f));
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(new Vector3(-3.0f * Time.deltaTime, 0.0f, 0.0f));
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(new Vector3(0.0f, -3.0f * Time.deltaTime, 0.0f));
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(new Vector3(3.0f * Time.deltaTime, 0.0f, 0.0f));
        }
    }
}
