using UnityEngine;

[RequireComponent(typeof(Ragdoll))]
[RequireComponent(typeof(Attacker))]
[RequireComponent(typeof(Animator))]
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

    private void OnEnable()
    {
        Crowd = transform.parent.GetComponent<Crowd>();
    }

    private void Start()
    {
        Rigidbody = GetComponent<Rigidbody>();
    }

    public virtual void Kill()
    {
        Attacker.DisableInput();
        _ragdoll.TurnOnRagdoll();
        _renderer.material.color = _deathColor;
    }
}
