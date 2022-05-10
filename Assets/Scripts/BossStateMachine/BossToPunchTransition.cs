using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossToPunchTransition : Transition
{
    private Vector3 _runTarget;
    private Vector3 _startPosition;
    private float _runDistance;

    private void Awake()
    {
        _startPosition = transform.position;
        _startPosition.y = 0;
    }

    private void OnEnable()
    {
        _runTarget = GetComponent<Boss>().RunTarget;
        _runDistance = (_runTarget - _startPosition).magnitude;
    }

    private void Update()
    {
        if ((transform.position - _startPosition).magnitude > _runDistance)
            NeedTransit = true;
    }
}
