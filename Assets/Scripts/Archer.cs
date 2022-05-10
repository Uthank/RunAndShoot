using System.Collections;
using UnityEngine;

public class Archer : MonoBehaviour
{
    [SerializeField] protected Color _aliveColor;
    [SerializeField] protected Renderer _renderer;
    [SerializeField] protected Color _deathColor;

    protected Ragdoll _ragdoll;

    public Crowd Crowd { get; protected set; }
    public Attacker Attacker { get; protected set; }
    public Rigidbody Rigidbody { get; protected set; }
    public Animator Animator { get; protected set; }

    protected virtual void Awake()
    {
        _ragdoll = GetComponent<Ragdoll>();
        Attacker = GetComponent<Attacker>();
        Animator = GetComponent<Animator>();
        _renderer.material.color = _aliveColor;
    }

    private void Start()
    {
        Rigidbody = GetComponent<Rigidbody>();
    }

    public virtual void Kill(Transform forceSource = null, float force = 0)
    {
        Attacker.DisableInput();
        _ragdoll.TurnOnRagdoll();
        _renderer.material.color = _deathColor;

        if (forceSource != null)
        {
            Vector3 forceDirection = (transform.position - forceSource.position).normalized + Vector3.up;
            Rigidbody.AddForce(forceDirection * force);
        }
    }
}
