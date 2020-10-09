using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public DeathPlane deathPlane;
    public ParticleSystem particles;
    private bool isActivated = false;
    ParticleSystem.MainModule main;
    public void Awake()
    {
        main = particles.GetComponent<ParticleSystem>().main;
    }

    private void OnTriggerEnter()
    {
        main.startColor = Color.green;
        deathPlane.checkpoint = gameObject;
        //if (!isActivated)
        //{
        //
        //}
    }

    private void OnTriggerExit()
    {
        main.startColor = Color.cyan;
    }
}
