using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Budget : MonoBehaviour
{
    public float TotalBudget;
    [SerializeField] TextMeshProUGUI BudgetTMP;
    PlayerPickup PPScript;
    // Start is called before the first frame update
    void Start()
    {
        PPScript = GameObject.FindWithTag("Player").GetComponent<PlayerPickup>();
        TotalBudget = PPScript.budget;
    }

    // Update is called once per frame
    void Update()
    {
        BudgetUpdate();
    }

    void BudgetUpdate()
    {
        var PPScript = GameObject.FindWithTag("Player").GetComponent<PlayerPickup>();
        TotalBudget = PPScript.budget;
        BudgetTMP.text = TotalBudget.ToString();
    }
}
