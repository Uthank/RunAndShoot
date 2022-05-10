using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Collider))]
public class Ragdoll : MonoBehaviour
{
    [SerializeField] private Collider[] _ragdollColliders;
    [SerializeField] private Rigidbody[] _ragdollRigidbodys;

    private Animator _animator;
    private Rigidbody _rigidbody;
    private Collider _collider;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _collider = GetComponent<Collider>();
        _animator = GetComponent<Animator>();

        TurnOffRagdoll();
    }

    public void TurnOnRagdoll()
    {
        _animator.enabled = false;
        _collider.enabled = false;
        _rigidbody.isKinematic = true;

        foreach (var collider in _ragdollColliders)
        {
            collider.enabled = true;
        }

        foreach (var rigidbody in _ragdollRigidbodys)
        {
            rigidbody.isKinematic = false;
        }
    }

    private void TurnOffRagdoll()
    {
        _animator.enabled = true;
        _collider.enabled = true;
        _rigidbody.isKinematic = false;

        foreach (var collider in _ragdollColliders)
        {
            collider.enabled = false;
        }

        foreach (var rigidbody in _ragdollRigidbodys)
        {
            rigidbody.isKinematic = true;
        }
    }
}
