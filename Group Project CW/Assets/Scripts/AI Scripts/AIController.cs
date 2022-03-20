using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIController : MonoBehaviour
{
    [SerializeField] Transform[] points;
    [SerializeField] float waitTime = 1.5f;
    [SerializeField] Animator animator;

    NavMeshAgent agent;
    Vector3 target;
    int pointIndex;
    float currentWait;
    int reachedPoint = 0;



    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.autoBraking = true;
        agent.isStopped = false;

        NextPoint();
    }

    void Update()
    {
        if (!agent.isStopped) Animate(1f);

        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            currentWait += Time.deltaTime;
            agent.isStopped = true;
            Animate(0f);
            if (currentWait >= waitTime)
            {
                UpdatePointIndex();
                NextPoint();
                Animate(1f);
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

    public void Animate(float movement)
    {
        animator.SetFloat("Blend", movement, 0.025f, Time.deltaTime);
        //print(movement);
    }


}
