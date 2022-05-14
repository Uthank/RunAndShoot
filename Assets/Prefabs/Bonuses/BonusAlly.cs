using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Attacker))]
public class BonusAlly : Bonus
{
    [SerializeField] private Renderer _renderer;
    [SerializeField] private Material _activatedMaterial;

    private Animator _animator;
    private Paw _paw;
    private Attacker _attacker;

    private Material _deactivatedMaterial;
    private bool _isActivated = false;


    private void Awake()
    {
        _paw = GetComponent<Paw>();
        _animator = GetComponent<Animator>();
        _attacker = GetComponent<Attacker>();
        _deactivatedMaterial = _renderer.material;
    }

    private void Start()
    {
        Deactivate();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_isActivated == false)
        {
            if (other.TryGetComponent<Archer>(out Archer archer) == true)
            {
                if (archer != _paw)
                {
                    _paw.transform.parent = archer.transform.parent;
                    _paw.enabled = true;
                    archer.Crowd.AddAllyToList(_paw);
                    Activate();
                }
            }
        }
    }

    private void Deactivate()
    {
        _animator.enabled = false;
        _paw.enabled = false;
        _attacker.DisableInput();
        _renderer.material = _deactivatedMaterial;
    }

    private void Activate()
    {
        _isActivated = true;
        _animator.enabled = true;
        _attacker.EnableInput();
        _renderer.material = _activatedMaterial;
    }
}
