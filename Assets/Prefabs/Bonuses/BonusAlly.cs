using UnityEngine;

public class BonusAlly : Bonus
{
    [SerializeField] private Renderer _renderer;
    [SerializeField] private Color _deactivatedColor;

    private Animator _animator;
    private Ally _ally;
    private Attacker _attacker;

    private Color _activatedColor;
    private bool _isActivated = false;


    private void Awake()
    {
        _ally = GetComponentInChildren<Ally>();
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
            if (collision.transform.TryGetComponent<Ally>(out Ally ally) == true)
            {
                _ally.Initialize(ally.Player);
                _ally.transform.parent = ally.Player.transform;
                ally.Crowd.AddAllyToList(_ally);
                Activate();
            }

            if (collision.transform.TryGetComponent<Player>(out Player player) == true)
            {
                _ally.Initialize(player);
                _ally.transform.parent = player.transform;
                player.Crowd.AddAllyToList(_ally);
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
