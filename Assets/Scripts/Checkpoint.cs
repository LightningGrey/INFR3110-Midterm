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
    //DLL info
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


    //other game objects
    public DeathPlane deathPlane;
    public ParticleSystem particles;
    ParticleSystem.MainModule main;
    public Checkpoint nextPoint;

    //UI related to checkpoints
    public Image checkpointMarker;
    public GameObject checkpointText;
    private Font arial;
    private int checkpointCounter = 1;
    
    //bools
    private bool isActivated = false;
    [SerializeField]
    private bool isFirst = false;
    [SerializeField]
    private bool isLast = false;


    public void Awake()
    {
        main = particles.GetComponent<ParticleSystem>().main;
        
        //time when entering 
        lastTime = Time.time;

        //load font
        arial = (Font)Resources.GetBuiltinResource(typeof(Font), "Arial.ttf");
    }

    void OnTriggerEnter()
    {
        main.startColor = Color.green;
        deathPlane.checkpoint = gameObject;

        //checkpoints between first and last
        //starting checkpoint not counted
        if (!isActivated && !isFirst && !isLast)
        {
            float currentTime = Time.time;
            float checkpointTime = currentTime - lastTime;
            //send checkpoint time to next checkpoint
            nextPoint.lastTime = currentTime;

            checkpointMarker.color = Color.green;

            SaveTimeTest(checkpointTime);

            //text
            Text myText = checkpointText.AddComponent<Text>();
            myText.text = "Checkpoint " + checkpointCounter + ": " 
                + checkpointTime;
            myText.font = arial;
            myText.color = Color.black;

            //send checkpoint counter to next checkpoint
            nextPoint.checkpointCounter = checkpointCounter + 1;
            //activate checkpoint, times only count first time touching checkpoint
            isActivated = true;
        }

        //last checkpoint, game complete
        if (isLast)
        {
            float currentTime = Time.time;
            float checkpointTime = currentTime - lastTime;

            checkpointMarker.color = Color.green;

            SaveTimeTest(checkpointTime);

            //write to file
            if (File.Exists("Assets/Resources/Times.txt"))
            {
                File.Delete("Assets/Resources/Times.txt");
            }
            string file = "Assets/Resources/Times.txt";

            StreamWriter writer = new StreamWriter(file);

            for (int i = 0; i <= 4; i++)
            {
                writer.WriteLine(LoadTimeTest(i));
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
