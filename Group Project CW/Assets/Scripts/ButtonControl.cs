using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ButtonControl : MonoBehaviour
{
    AsyncOperation loadingOperation;

    public GameObject MenuScreen;
    public Slider progressSlider;
    public GameObject SliderGO;
    public Text progress;
    public void Play(string scenename)
    {
        MenuScreen.SetActive(false);
        SliderGO.SetActive(true);
        Time.timeScale = 1;
        StartCoroutine(Loading(scenename));
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void Controls()
    {
        SceneManager.LoadScene("Controls");
    }

    public void Menu()
    {
        SceneManager.LoadScene("Start");
    }
    IEnumerator Loading(string scenename)
    {
        loadingOperation = SceneManager.LoadSceneAsync(scenename);

        while (!loadingOperation.isDone)
        {
            float progressPercent = Mathf.Clamp01(loadingOperation.progress / 0.9f);
            progressSlider.value = progressPercent;
            progress.text = progressPercent * 100 + "%";

            yield return null; 
        }
    }
}
