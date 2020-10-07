using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Animator anim;
    public bool moveFlag = false;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            moveFlag = true;
            transform.Translate(new Vector3(0.0f, 0.0f, 3f * Time.deltaTime));
        }
        if (Input.GetKey(KeyCode.A))
        {
            moveFlag = true;
            transform.Translate(new Vector3(3f * Time.deltaTime, 0.0f, 0.0f));
        }
        if (Input.GetKey(KeyCode.S))
        {
            moveFlag = true;
            transform.Translate(new Vector3(0.0f, 0.0f, 3f * Time.deltaTime));
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveFlag = true;
            transform.Translate(new Vector3(3f * Time.deltaTime, 0.0f, 0.0f));
        }

        if (moveFlag)
        {
            anim.SetBool("walk", true);
        } else
        {
            anim.SetBool("walk", false);
        }

        moveFlag = false;

    }
}
