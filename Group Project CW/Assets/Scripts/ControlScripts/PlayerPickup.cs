using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickup : MonoBehaviour
{
    [SerializeField] LayerMask objectMask;

    Ray ray;
    RaycastHit hit;
    float maxDistance = 5f;

    void Update()
    {
        TrackMouse();
        Pickup();
    }

    void TrackMouse()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    }

    void Pickup()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            print("firing ray");

            if(Physics.Raycast(ray, out hit, maxDistance, objectMask))
            {
                print("Raycast hit");
            }
        }
    }
}
