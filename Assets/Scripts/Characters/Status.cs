using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody))]
public class Status : MonoBehaviour
{
    [SerializeField] private Renderer _renderer;
    [SerializeField] private GameObject _frozen;
    [SerializeField] float _FrozenDuration = 1;
    [SerializeField] Material _frozenMaterial;

    private Enemy _enemy;
    private Animator _animator;
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _enemy = GetComponent<Enemy>();
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void ApplyEffect(EffectTypes hitEffect)
    {
        switch (hitEffect)
        {
            case EffectTypes.Freeze:
                StartCoroutine(Freeze());
                break;
            default:
                throw new MissingReferenceException();
        }
    }

    private IEnumerator Freeze()
    {
        _enemy.DisableStateMachine();
        _animator.speed = 0;
        _rigidbody.isKinematic = true;
        _renderer.material = _frozenMaterial;
        yield return new WaitForSeconds(_FrozenDuration);
        Instantiate(_frozen, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
