using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class PlayerMovement : MonoBehaviour
{
    private Vector3 movement;
    private float speed = 3.0f;

    [SerializeField]
    private Rigidbody body;

    //animations
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //rigidbody movement
        movement = new Vector3 (Input.GetAxis("Horizontal"), 
            0.0f, Input.GetAxis("Vertical"));
        movement = Vector3.ClampMagnitude(movement, 1.0f);

        if (movement != Vector3.zero) {
            transform.rotation = Quaternion.LookRotation(movement);
            anim.SetBool("walk", true);
        }
        else
        {
            anim.SetBool("walk", false);
        }
    }

    void FixedUpdate()
    {
        body.MovePosition(transform.position + (movement * speed * Time.fixedDeltaTime));
    }


}
