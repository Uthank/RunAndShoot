using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody))]
public class BossRunState : State
{
    [SerializeField] private float _runSpeed;

    private Rigidbody _rigidbody;
    private Animator _animator;

    private string _runAnimation = "Run";

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        _animator.SetTrigger(_runAnimation);
    }

    private void OnDisable()
    {
        _rigidbody.velocity = Vector3.zero;
    }

    private void Update()
    {
        _rigidbody.velocity = Vector3.left * _runSpeed;
    }
}
