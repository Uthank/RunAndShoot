using UnityEngine;

public class Boss : Enemy
{
    [SerializeField] private Transform _body;
    [SerializeField] private float _punchForce = 300;
    [SerializeField] private int _health = 50;

    private EnemySpawner _enemySpawner;
    private FinishZone _finishZone;

    public Vector3 RunTarget { get; private set; }

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
            base.Damage();

        _health--;
    }
}
