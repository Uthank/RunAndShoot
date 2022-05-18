using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Boss : Enemy
{
    [SerializeField] private Transform _body;
    [SerializeField] private float _punchForce = 300;
    [SerializeField] private int _health = 70;
    [SerializeField] private TMP_Text _HealthText;
    [SerializeField] private Rigidbody _headRigifbody;
    [SerializeField] private float _forceOnDeathPower;

    private Collider _collider;

    private EnemySpawner _enemySpawner;
    private FinishZone _finishZone;

    public event UnityAction<int> OnHealthChanged;

    public Vector3 RunTarget { get; private set; }

    private void Start()
    {
        _collider = GetComponent<Collider>();
        OnHealthChanged.Invoke(_health);
    }

    public Transform Body => _body;

    public void Initialize(Vector3 runTarget, EnemySpawner enemySpawner, FinishZone finishZone)
    {
        RunTarget = runTarget;
        _enemySpawner = enemySpawner;
        _finishZone = finishZone;
    }

    public void KillEnemies()
    {
        _enemySpawner.KillAll();
    }

    public void killAllArchers()
    {
        _finishZone.KillArchers(this.transform, _punchForce);
    }

    public override void Damage()
    {
        if (_health <= 0)
        {
            _HealthText.enabled = false;
            _collider.enabled = false;
            base.Damage();
            _headRigifbody.AddForce(Vector3.right * _forceOnDeathPower);
        }

        _health--;
        OnHealthChanged?.Invoke(_health);
    }
}
