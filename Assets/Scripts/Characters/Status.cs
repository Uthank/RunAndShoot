using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody))]
public class Status : MonoBehaviour
{
    [SerializeField] private Renderer _renderer;
    [SerializeField] private GameObject _frozen;

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
                Freeze();
                break;
            default:
                throw new MissingReferenceException();
        }
    }

    private void Freeze()
    {

        _enemy.DisableStateMachine();
        Instantiate(_frozen, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
