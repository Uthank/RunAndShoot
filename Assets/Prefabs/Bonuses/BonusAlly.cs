using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Attacker))]
public class BonusAlly : Bonus
{
    [SerializeField] private Renderer _renderer;
    [SerializeField] private Color _deactivatedColor;

    private Animator _animator;
    private Paw _ally;
    private Attacker _attacker;

    private Color _activatedColor;
    private bool _isActivated = false;


    private void Awake()
    {
        _ally = GetComponentInChildren<Paw>();
        _animator = _ally.GetComponent<Animator>();
        _attacker = _ally.GetComponent<Attacker>();
    }

    private void Start()
    {
        Deactivate();
    }

    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if (_isActivated == false)
        {
            if (collision.transform.TryGetComponent<Archer>(out Archer archer) == true)
            {
                Crowd crowd = archer.transform.parent.GetComponent<Crowd>();
                _ally.Initialize(crowd);
                _ally.transform.parent = archer.transform.parent;
                crowd.AddAllyToList(_ally);
                Activate();
            }
        }
    }

    private void Deactivate()
    {
        _animator.enabled = false;
        _ally.enabled = false;
        _attacker.DisableInput();
        _activatedColor = _renderer.material.color;
        _renderer.material.color = _deactivatedColor;
    }

    private void Activate()
    {
        _isActivated = true;
        _animator.enabled = true;
        _ally.enabled = true;
        _attacker.EnableInput();
        _renderer.material.color = _activatedColor;
        Destroy(gameObject);
    }
}
