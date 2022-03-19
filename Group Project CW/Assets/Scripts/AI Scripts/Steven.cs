using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Steven : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        collision.gameObject.GetComponent<AIController>().Animate(1f);  
    }
}
