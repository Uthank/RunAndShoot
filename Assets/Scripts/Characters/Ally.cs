using UnityEngine;

public class Ally : MonoBehaviour
{
    private float _clampHorizontalPosition = 1f;
    private Rigidbody _rigidbody;
    private Vector3 _velocity;
    private float _force = 20f;
    private Player _player;

    private void Awake()
    {
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
        Debug.Log(transform.TransformPoint(transform.position).x +" "+ _player.transform.position.x);
        _velocity *= _force;
        _rigidbody.velocity += _velocity;
    }
    public void SetPlayer(Player player)
    {
        _player = player;
    }
}
