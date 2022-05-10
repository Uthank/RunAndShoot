using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BossFallState : State
{
    [SerializeField] float _fallSpeed;

    private Rigidbody _rigidbody; 
    
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _rigidbody.velocity = Vector3.down * _fallSpeed;
    }
}
