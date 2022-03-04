using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIController : MonoBehaviour
{
    [SerializeField] Transform[] points;
    [SerializeField] float waitTime = 1.5f;

    NavMeshAgent agent;
    Vector3 target;
    int pointIndex;
    float currentWait;



    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.autoBraking = true;
        agent.isStopped = false;

        NextPoint();
    }

    void Update()
    {
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            currentWait += Time.deltaTime;
            agent.isStopped = true;
            if (currentWait >= waitTime)
            {
                UpdatePointIndex();
                NextPoint();
                agent.isStopped = false;
                currentWait = 0f;
            }
        }
    }

    void UpdatePointIndex()
    {
        pointIndex++;
        if (pointIndex == points.Length)
        {
            pointIndex = 0;
        }
    }

    void NextPoint()
    {
        if (points.Length == 0)
        {
            return;
        }

        target = points[pointIndex].position;
        agent.SetDestination(target);
    }
}
