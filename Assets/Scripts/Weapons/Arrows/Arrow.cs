using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Arrow : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private AnimationCurve _flatTrajectory;

    private AnimationCurve _trajectory;
    private float _range;
    private ArrowType _type;
    private Rigidbody _rigidbody;
    private int _unitPerSecond = 25;
    private float _verticalOffset = 2;
    private Vector3 _startPoint;
    private Vector3 _endPoint;
    private IEnumerator _flyCoroutine;
    private bool _isHit = false;
    private Collider _collider;

    private void OnEnable()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _collider = GetComponent<Collider>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (_isHit == false)

        if (collision.collider.TryGetComponent<BodyPart>(out BodyPart bodyPart) == true)
        {
            if (bodyPart.Character.GetType() == typeof(Enemy) || bodyPart.Character.GetType() == typeof(Boss))
            {
                Enemy enemy = (Enemy)bodyPart.Character;

                if (enemy.IsAlive == false)
                    return;

                if (_type.HitEffect == EffectTypes.None)
                    enemy.Damage();
                else
                    enemy.ReceiveHitEffect(_type.HitEffect);

                _isHit = true;
                _collider.enabled = false;
                _rigidbody.isKinematic = true;

                if (bodyPart.Character.GetType() == typeof(Boss))
                {
                    StopCoroutine(_flyCoroutine);
                    transform.position = collision.GetContact(0).point;
                    transform.parent = bodyPart.transform;
                    Destroy(gameObject, 5f);
                }
                else
                {
                    Destroy(gameObject);
                }
            }
        }
    }

    public void Initialize(float range, ArrowType type, AnimationCurve trajectory = null)
    {
        if (_trajectory == null)
            _trajectory = _flatTrajectory;
        else
            _trajectory = trajectory;

        _range = range;
        _type = type;

        Instantiate(_type.Model, transform);
        _startPoint = transform.position;
        _endPoint = transform.position + Vector3.right * _range;
        _flyCoroutine = Fly();
        StartCoroutine(_flyCoroutine);
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
