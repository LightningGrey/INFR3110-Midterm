using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Runtime.CompilerServices;
using Unity.Profiling;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class WallFloorMovement : MonoBehaviour
{
    //direction
    //negative or positive;
    [SerializeField]
    private float move = 1.0f;

    [SerializeField]
    private float moveSpeed = 0.5f;

    //current timer on movement
    [SerializeField]
    private float counter = 0.0f;
    //bound of movement
    [SerializeField]
    private float timer = 0.0f;

    [SerializeField]
    private bool isHorizontal = true;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (counter > timer) { 
            move = -move;
            counter = 0.0f;
        } else
        {
            counter += 0.1f;
        }

        if (isHorizontal) { 
            XMove();
        } else {
            ZMove();
        }

    }

    private void XMove() {
        transform.position += new Vector3(move * moveSpeed * Time.deltaTime, 0.0f, 0.0f);
    }

    private void ZMove() {
        transform.position += new Vector3(0.0f, 0.0f, move * moveSpeed * Time.deltaTime);
    }

}
