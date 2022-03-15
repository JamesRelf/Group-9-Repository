using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIControl : MonoBehaviour
{
    public GameObject ShoppingList;
    public GameObject ScrollList;
    public TextMeshProUGUI ShoppingItems;
    public List<string> ItemsList;
    public List<GameObject> TFList;
    public string[] CompletedList;
    public bool complete = true;
    public string items;
    public int TimeLeft = 1000000;
    public TextMeshProUGUI timer;
    public bool timestop = false;

    public TextMeshProUGUI Budget;
    public float TotalBudget = 1000f;

    // Start is called before the first frame update
    void Start()
    {
        GetChildren();
        ShoppingItems.fontStyle = FontStyles.Strikethrough;
    }

    // Update is called once per frame
    void Update()
    {
        ListInput();
        ActivateList();
        BudgetUpdate();
        if (timestop == false && TimeLeft > 0)
        {
            StartCoroutine(TimeUpdate());
        }
    }

    //Shopping List Codes
    void ActivateList()
    {
        if (Input.GetKey(KeyCode.P))
        {
            ShoppingList.SetActive(true);
            Time.timeScale = 0;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            ShoppingList.SetActive(false);
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
    void GetChildren()
    {
        foreach (Transform child in ShoppingItems.transform)
        {
            TFList.Add(child.gameObject);
            //print(TFList.Count);
        }
    }
    void ListInput()
    {
        for (int i = 0; i < ItemsList.Count; i++)
        {
            TFList[i].SetActive(true);
            var getTMPro = TFList[i].gameObject.GetComponent<TextMeshProUGUI>();
            items = ItemsList[i];
            getTMPro.text = items;
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

    //Budget
    void BudgetUpdate()
    {
        var PPScript = GameObject.FindWithTag("Player").GetComponent<PlayerPickup>();
        TotalBudget = PPScript.budget;
        Budget.text = TotalBudget.ToString();
    }
}

