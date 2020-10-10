using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class SceneHandler : MonoBehaviour
{

    public void SceneChange(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

}
