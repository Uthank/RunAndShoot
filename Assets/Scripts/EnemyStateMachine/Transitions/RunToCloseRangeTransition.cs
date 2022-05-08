using UnityEngine;

public class RunToCloseRangeTransition : Transition
{
    [SerializeField] private float _detectionDistance = 8f;

    private void Update()
    {
        if (Target.IsAlive == false || Vector3.Distance(transform.position, Target.transform.position) < _detectionDistance)
        {
            NeedTransit = true;
        }
    }
}
