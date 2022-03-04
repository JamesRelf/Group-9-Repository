using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawPoints : MonoBehaviour
{
    [SerializeField] Transform[] points;
    float radius = 1;

    void OnDrawGizmos()
    {
        for (int i = 0; i < points.Length; i++)
        {
            Gizmos.DrawSphere(points[i].position, radius);
        }
    }
}
