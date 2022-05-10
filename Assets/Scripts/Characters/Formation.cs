using UnityEngine;

[RequireComponent(typeof(Paw))]
[RequireComponent(typeof(Rigidbody))]
public class Formation : MonoBehaviour
{
    private Rigidbody _rigidbody;

    private float _clampHorizontalPosition = 1f;
    private Vector3 _velocity;
    private float _force = 20f;
    private King _king;

    private void Start()
    {
        _king = GetComponent<Paw>().Crowd.King;
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _velocity = Vector3.zero;

        if (transform.position.z > _king.transform.position.z + _clampHorizontalPosition)
        {
            _velocity += Vector3.back;
        }

        if (transform.position.z < _king.transform.position.z - _clampHorizontalPosition)
        {
            _velocity += Vector3.forward;
        }

        if (transform.TransformPoint(transform.position).x > _king.transform.position.x)
        {
            _velocity += Vector3.left;
        }

        _velocity *= _force;
        _rigidbody.velocity += _velocity;
    }
}
