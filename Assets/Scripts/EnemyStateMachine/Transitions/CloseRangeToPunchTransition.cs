using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseRangeToPunchTransition : Transition
{
    [SerializeField] private float _detectionDistance = 4f;

    private void Update()
    {
        if (Target.IsAlive == true)
        {
            if (Vector3.Distance(transform.position, Target.transform.position) < _detectionDistance)
            {
                NeedTransit = true;
            }
        }
        else
        {
            NeedTransit = true;
        }
    }
}
