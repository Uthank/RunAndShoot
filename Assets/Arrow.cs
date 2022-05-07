using System.Collections;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] private float _speed;

    private AnimationCurve _trajectory;
    private float _range;
    private ArrowType _type;
    private float _startPointX;
    private float _endPointX;
    private Rigidbody _rigidbody;
    private int _unitPerSecond = 10;
    private float _verticalOffset = 2;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Enemy>(out Enemy enemy) == true)
        {
            enemy.Kill();
            Destroy(gameObject);
        }
    }

    public void Initialize(AnimationCurve trajectory, float range, ArrowType type)
    {
        _trajectory = trajectory;
        _range = range;
        _type = type;

        Instantiate(_type.Model, transform);
        _startPointX = transform.position.x;
        _endPointX = _startPointX + _range;
        Debug.Log(1);
        StartCoroutine(Fly());
        Debug.Log(2);
    }

    private IEnumerator Fly()
    {
            Debug.Log(5);
        while (transform.position.x < _endPointX)
        {
            Debug.Log(6);
            Vector3 point = transform.position + new Vector3(_unitPerSecond * Time.deltaTime, 0, 0);
            point.y = _trajectory.Evaluate((transform.position.x - _startPointX) / _range) * _verticalOffset;
            _rigidbody.MovePosition(point);
            yield return null;
        }
    }
}
