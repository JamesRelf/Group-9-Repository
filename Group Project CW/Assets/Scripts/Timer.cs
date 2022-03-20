using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class Timer : MonoBehaviour
{
    [SerializeField] int TimeLeft = 1000000;
    [SerializeField] TextMeshProUGUI timer;
    [SerializeField] GameObject MessageParent;
    [SerializeField] TextMeshProUGUI Messages;

    bool timestop = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timestop == false && TimeLeft > 0)
        {
            StartCoroutine(TimeUpdate());
        }
        if(TimeLeft == 0)
        {
            Messages.text = "You ran out of time \n Returning to Main Menu";
            StartCoroutine(MessageWait());
        }
    }
    //Timer Coroutine
    IEnumerator TimeUpdate()
    {
        float minutes = Mathf.FloorToInt(TimeLeft / 60);
        float seconds = Mathf.FloorToInt(TimeLeft % 60);
        timestop = true;
        yield return new WaitForSeconds(1);
        TimeLeft -= 1;
        timer.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        timestop = false;
    }

    IEnumerator MessageWait()
    {
        MessageParent.gameObject.SetActive(true);
        yield return new WaitForSeconds(5);
        MessageParent.gameObject.SetActive(false);
        SceneManager.LoadScene("Start");

    }
}
