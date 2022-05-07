using UnityEngine;

public class Ally : MonoBehaviour, IKillable
{
    private float _clampHorizontalPosition = 1f;
    private Rigidbody _rigidbody;
    private Vector3 _velocity;
    private float _force = 20f;
    private Player _player;
    private Crowd _crowd;

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

        _velocity *= _force;
        _rigidbody.velocity += _velocity;
    }
    public void SetPlayer(Player player)
    {
        _player = player;
        _crowd = player.GetComponent<Crowd>();
    }

    public void Kill()
    {
        _crowd.Damage(this);
    }
}
