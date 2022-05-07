using System.Collections;
using UnityEngine;

public class Trap : MonoBehaviour
{
    [SerializeField] private float _rotateSpeed;
    [SerializeField] Vector3[] _movePoints;

    private Vector3 _targetPosition;
    private float _speed = 1f;
    private float _minimalDistance = 0.3f;
    private Vector3 _direction;
    private IEnumerator _move;
    private float _rotation;
    private int _indexOfCurrentPosition = 0;

    private void Awake()
    {
        for (int i = 0; i < _movePoints.Length; i++)
        {
            _movePoints[i] += transform.position;
        }

        if (_movePoints.Length > 0)
            _targetPosition = _movePoints[0];
    }

    private void Update()
    {
        if (_movePoints.Length > 0)
            Patrol();
        Rotate();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<IKillable>(out IKillable iKillable))
        {
            iKillable.Kill();
        }
    }

    private void Rotate()
    {
        transform.Rotate(Vector3.up * _rotateSpeed * Time.deltaTime);
    }

    private void Patrol()
    {
        if ((_targetPosition - transform.position).magnitude < _minimalDistance && _move == null)
        {
            _targetPosition = GetNextPosition();
            _move = Move();
            StartCoroutine(_move);
        }
    }

    private IEnumerator Move()
    {
        while ((_targetPosition - transform.position).magnitude > _minimalDistance)
        {
            _direction = (_targetPosition - transform.position).normalized;
            transform.Translate(_direction * _speed * Time.deltaTime);
            yield return null;
        }

        _move = null;
    }

    private Vector3 GetNextPosition()
    {
        _indexOfCurrentPosition++;

        if (_indexOfCurrentPosition == _movePoints.Length)
            _indexOfCurrentPosition = 0;

        return _movePoints[_indexOfCurrentPosition];
    }
}
