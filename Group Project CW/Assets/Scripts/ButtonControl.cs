using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonControl : MonoBehaviour
{
    public void Play()
    {
        string SceneName = "";
        SceneManager.LoadScene("rohit scene");
    }
    public void Exit()
    {
        Application.Quit();
    }
}
