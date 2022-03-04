using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkout : MonoBehaviour
{
    public bool complete = true;
    CharacterController charCtrl;
    Ray ray;
    RaycastHit hit;
    // Start is called before the first frame update
    void Start()
    {
        charCtrl = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Cashier
    //void CheckoutCode()
    //{
    //    if (complete == true)
    //    {
    //        if (Input.GetButtonDown("B"))
    //        {
    //            if (Physics.SphereCast(ray, 2f, out hit, 2f))
    //            {
    //                if (hit.collider.gameObject.tag == "Cashier")
    //                {
    //                    Debug.Log("Checkout Complete");
    //                }
    //            }
    //        }
    //    }
    //}
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Cashier")
        {
            Debug.Log("Checkout Complete");
        }
    }
}
