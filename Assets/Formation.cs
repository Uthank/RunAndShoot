using UnityEngine;

public class Formation : MonoBehaviour
{

    private float _clampHorizontalPosition = 1f;
    private Vector3 _velocity;
    private float _force = 20f;
    private Player _player;
    private Rigidbody _rigidbody;

    private void Start()
    {
        _player = GetComponent<Ally>().Player;
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _velocity = Vector3.zero;

        if (transform.position.z > _player.transform.position.z + _clampHorizontalPosition)
        {
            _velocity += Vector3.back;
        }

        if (transform.position.z < _player.transform.position.z - _clampHorizontalPosition)
        {
            _velocity += Vector3.forward;
        }

        if (transform.TransformPoint(transform.position).x > _player.transform.position.x)
        {
            _velocity += Vector3.left;
        }

        _velocity *= _force;
        _rigidbody.velocity += _velocity;
    }
}
