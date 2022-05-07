using UnityEngine;

public class RunState : State
{
    [SerializeField] private float _speed;

    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _rigidbody.velocity = Vector3.left * _speed;
    }

    private void OnDisable()
    {
        _rigidbody.velocity = Vector3.zero;
    }
}
