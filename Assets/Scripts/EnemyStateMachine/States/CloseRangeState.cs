using UnityEngine;

public class CloseRangeState : State
{
    [SerializeField] private float _speed;

    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Target != null)
        {
            Vector3 direction = (Target.transform.position - transform.position).normalized;
            _rigidbody.velocity = direction * _speed;
        }
    }

    private void OnDisable()
    {
        _rigidbody.velocity = Vector3.zero;
    }
}
