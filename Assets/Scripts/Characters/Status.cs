using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody))]
public class Status : MonoBehaviour
{
    [SerializeField] private Renderer _renderer;

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
        float killDelay = 1;

        _enemy.DisableStateMachine();
        _renderer.material.color = Color.blue;
        _rigidbody.velocity = Vector3.zero;
        _animator.speed = 0;
        StartCoroutine(KillAfterDelay(killDelay));
    }

    private IEnumerator KillAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        _enemy.Damage();
    }
}
