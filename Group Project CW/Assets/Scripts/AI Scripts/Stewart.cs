using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stewart : MonoBehaviour
{
    [SerializeField] AIController animator;

    int animate;

    void Update()
    {
        CallAnimate();
    }

    public void CallAnimate()
    {
        animator.Animate(animate);
    }
}
