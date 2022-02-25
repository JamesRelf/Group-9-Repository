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
    public TextMeshProUGUI CompletedItemsp;
    public List<string> ItemsList;
    //public string[] CompletedList;
    public string itms;

    public int TimeLeft = 1000000;
    public TextMeshProUGUI timer;
    public bool timestop = false;

    public TextMeshProUGUI Budget;
    public float TotalBudget = 1000f;

    // Start is called before the first frame update
    void Start()
    {
        ListInput();
    }

    // Update is called once per frame
    void Update()
    {
        activateList();
        BudgetUpdate();
        if (timestop == false && TimeLeft > 0)
        {
            StartCoroutine(TimeUpdate());
        }
    }

    //Shopping List Codes
    void activateList()
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
    void ListInput()
    {
        for (var i = 0; i < ItemsList.Count; i++)
        {
            itms += "\n" + ItemsList[i];
        }
        ShoppingItems.gameObject.ToString();
        ShoppingItems.text = itms;

        //if (Input.GetKeyDown("q"))
        //{
        //    ShoppingItems.fontStyle = FontStyles.Strikethrough;
        //    ItemsList.RemoveAt(ItemsList.Count - 1);
        //    ItemsList.RemoveAll(s => s == null);
        //}
    }
    //IEnumerator spawnList()
    //{
    //    int currentObj = 0;
    //    while (currentObj < ItemsList.Count)
    //    {
    //        var copy = Instantiate(ShoppingItems);
    //        copy.transform.parent = ShoppingList.transform;
    //        copy.transform.SetSiblingIndex(0);
    //        yield return new WaitForSeconds(3f);
    //    }
    //}

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
    void BudgetUpdate()
    {
        var PPScript = GameObject.FindWithTag("Player").GetComponent<PlayerPickup>();
        TotalBudget = PPScript.budget;
        Budget.text = TotalBudget.ToString();
    }
}
