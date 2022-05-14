using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CloseRangeState : State
{
    [SerializeField] private float _speed;

    private Rigidbody _rigidbody;
    private Enemy _enemy;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _enemy = GetComponent<Enemy>();
        _speed = _enemy.Speed;
    }

    private void OnEnable()
    {
        GetComponent<Enemy>().OnSpeedChanged += ChangeSpeed;
    }

    private void Update()
    {
        if (Target.IsAlive == true)
        {
            Vector3 direction = (Target.transform.position - transform.position).normalized;
            _rigidbody.velocity = direction * _speed;
        }
    }

    private void OnDisable()
    {
        _rigidbody.velocity = Vector3.zero;
        GetComponent<Enemy>().OnSpeedChanged -= ChangeSpeed;
    }

    private void ChangeSpeed()
    {
        _speed = GetComponent<Enemy>().Speed;
    }
}
