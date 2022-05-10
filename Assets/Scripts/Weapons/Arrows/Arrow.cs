using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Arrow : MonoBehaviour
{
    [SerializeField] private float _speed;

    private AnimationCurve _trajectory;
    private float _range;
    private ArrowType _type;
    private Rigidbody _rigidbody;
    private int _unitPerSecond = 25;
    private float _verticalOffset = 2;
    private Vector3 _startPoint;
    private Vector3 _endPoint;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Enemy>(out Enemy enemy) == true)
        {
            transform.parent = enemy.transform;
            Destroy(gameObject, 5f);
            this.enabled = false;

            if (_type.HitEffect == EffectTypes.None)
                enemy.Kill();
            else
                enemy.ReceiveHitEffect(_type.HitEffect);
        }
    }

    public void Initialize(AnimationCurve trajectory, float range, ArrowType type)
    {
        _trajectory = trajectory;
        _range = range;
        _type = type;

        Instantiate(_type.Model, transform);
        _startPoint = transform.position;
        _endPoint = transform.position + Vector3.right * _range;
        StartCoroutine(Fly());
    }

    private IEnumerator Fly()
    {
        float range = (_endPoint - _startPoint).magnitude;

        while ((transform.position - _startPoint).magnitude < range)
        {
            Vector3 point = transform.position + Vector3.right * _unitPerSecond * Time.deltaTime;
            point.y = _trajectory.Evaluate((transform.position - _startPoint).magnitude / range) * _verticalOffset;
            point = transform.position + transform.rotation * (point - transform.position);
            _rigidbody.MovePosition(point);
            yield return null;
        }

        Destroy(gameObject);
    }
}
