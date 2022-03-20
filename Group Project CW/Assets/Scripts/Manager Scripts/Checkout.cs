using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Checkout : MonoBehaviour
{
    public bool complete = true;
    CharacterController charCtrl;
    Ray ray;
    RaycastHit hit;
    float BudgetStart;
    public Budget BudgetScript;
    public GameObject EndScreen;

    [SerializeField] TextMeshProUGUI MessageTMP;
    [SerializeField] GameObject MessageParent;
    // Start is called before the first frame update
    void Start()
    {
        charCtrl = GetComponent<CharacterController>();
        BudgetStart = BudgetScript.TotalBudget;
        print(BudgetStart);
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void OnTriggerEnter(Collider other)
    {
        if (BudgetScript.TotalBudget < BudgetStart)
        {
            if (other.gameObject.tag == "Cashier")
            {
                MessageTMP.text = "Checkout Complete \n These are the items you bought";
                EndScreen.SetActive(true);
                Time.timeScale = 0;
                StartCoroutine(MessageWait());
            }
        }
        else
        {
            MessageTMP.text = "You have noting in your inventory";
            StartCoroutine(MessageWait());
        }
    }
    IEnumerator MessageWait()
    {
        MessageParent.gameObject.SetActive(true);
        yield return new WaitForSeconds(3);
        MessageParent.gameObject.SetActive(false);

    }
}
