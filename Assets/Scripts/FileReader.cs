using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class FileReader : MonoBehaviour
{
    public List<GameObject> textObjects;

    // Start is called before the first frame update
    void Start()
    {
        //load font
        Font arial = (Font)Resources.GetBuiltinResource(typeof(Font), "Arial.ttf");

        string file = "Assets/Resources/Times.txt";

        StreamReader reader = new StreamReader(file);
        for (int i = 0; i <= 5; i++)
        {
            //Debug.Log(reader.ReadLine());
            Text myText = textObjects[i].AddComponent<Text>();
            myText.text = reader.ReadLine();
            myText.font = arial;
            myText.color = Color.black;
        }
        reader.Close();

        

    }

}
