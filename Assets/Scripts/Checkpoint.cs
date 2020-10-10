using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;
using JetBrains.Annotations;
using UnityEngine.UI;
using System.Diagnostics.Tracing;
using UnityEditor.Experimental.GraphView;
using UnityEngine.SceneManagement;
using System.IO;

public class Checkpoint : MonoBehaviour
{
    const string DLL_NAME = "INFR3110 - Midterm DLL";

    [DllImport(DLL_NAME)]
    private static extern void ResetLogger();


    [DllImport(DLL_NAME)]
    private static extern void SaveCheckpointTime(float RTBC);


    [DllImport(DLL_NAME)]
    private static extern float GetTotalTime();

    [DllImport(DLL_NAME)]
    private static extern float GetCheckpointTime(int index);


    [DllImport(DLL_NAME)]
    private static extern int GetNumCheckpoints();

    float lastTime = 0.0f;

    public void SaveTimeTest(float checkpointTime)
    {
        SaveCheckpointTime(checkpointTime);
    }

    public float LoadTimeTest(int index)
    {
        if (index >= GetNumCheckpoints())
        {
            return -1.0f;
        }
        else
        {
            return GetCheckpointTime(index);
        }
    }

    public float LoadTotalTimeTest()
    {
        return GetTotalTime();
    }

    public void ResetLoggerTest()
    {
        ResetLogger();
    }



    public DeathPlane deathPlane;
    public ParticleSystem particles;
    ParticleSystem.MainModule main;
    public Checkpoint nextPoint;

    //UI related to checkpoints
    public Image checkpointMarker;
    public GameObject checkpointText;
    private Font arial;
    private int checkpointCounter = 1;
    
    private bool isActivated = false;
    [SerializeField]
    private bool isFirst = false;
    [SerializeField]
    private bool isLast = false;


    public void Awake()
    {
        main = particles.GetComponent<ParticleSystem>().main;
        lastTime = Time.timeSinceLevelLoad;

        //load font
        arial = (Font)Resources.GetBuiltinResource(typeof(Font), "Arial.ttf");
    }

    void OnTriggerEnter()
    {
        main.startColor = Color.green;
        deathPlane.checkpoint = gameObject;
        if (!isActivated && !isFirst && !isLast)
        {
            float currentTime = Time.time;
            float checkpointTime = currentTime - lastTime;
            nextPoint.lastTime = currentTime;

            checkpointMarker.color = Color.green;

            SaveTimeTest(checkpointTime);

            //text
            Text myText = checkpointText.AddComponent<Text>();
            myText.text = "Checkpoint " + checkpointCounter + ": " 
                + checkpointTime;
            myText.font = arial;
            myText.color = Color.black;

            nextPoint.checkpointCounter = checkpointCounter + 1;
            isActivated = true;
        }

        if (isLast)
        {
            float currentTime = Time.time;
            float checkpointTime = currentTime - lastTime;
            nextPoint.lastTime = currentTime;

            checkpointMarker.color = Color.green;

            SaveTimeTest(checkpointTime);

            //write to file
            string file = "Assets/Times.txt";

            StreamWriter writer = new StreamWriter(file, true);

            for (int i = 0; i <= 4; i++)
            {
                writer.WriteLine(LoadTimeTest(i));
                writer.WriteLine("\n");
            }
            writer.WriteLine(LoadTotalTimeTest());
            writer.Close();

            SceneManager.LoadScene("EndScene");
        }
    }

    void OnTriggerExit()
    {
        main.startColor = Color.cyan;
    }


    void OnDestroy()
    {
        ResetLoggerTest();
    }
}
