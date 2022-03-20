using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Pause : MonoBehaviour
{
    [SerializeField] GameObject MenuPanel;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            MenuPanel.SetActive(true);
            Time.timeScale = 0;
        }
    }
    public void resumeGame()
    {
        MenuPanel.SetActive(false);
        Time.timeScale = 1;
        Cursor.lockState=CursorLockMode.Locked;
    }
    public void ToMenu()
    {
        SceneManager.LoadScene("Start");
    }
}
