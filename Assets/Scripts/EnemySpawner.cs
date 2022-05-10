using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private Crowd _crowd;
    [SerializeField] private float _spawnFrequency = .5f;

    private List<Enemy> _enemies = new List<Enemy>();
    private float _maxOffset = 2.5f;
    private IEnumerator _spawn;
    private WaitForSeconds _frequency;

    private void Awake()
    {
        _frequency = new WaitForSeconds(_spawnFrequency);
    }

    private void OnEnable()
    {
        _crowd.King.Killed += TurnOff;
    }

    private void OnDisable()
    {
        _crowd.King.Killed -= TurnOff;
    }

    private void Update()
    {
        if (_spawn == null)
        {
            _spawn = SpawnEnemy();
            StartCoroutine(_spawn);
        }
    }

    public void KillAll()
    {
        if (_enemies.Count > 0)
            foreach (Enemy enemy in _enemies)
                enemy.Kill();

        TurnOff();
    }

    private IEnumerator SpawnEnemy()
    {
        float offsetX = Random.Range(-_maxOffset, _maxOffset);
        float offsetZ = Random.Range(-_maxOffset, _maxOffset);

        Enemy enemy = Instantiate(_enemy, transform.position + new Vector3(offsetX, 0, offsetZ), Quaternion.Euler(0, 180, 0));
        _enemies.Add(enemy);
        enemy.SetTarget(_crowd.King);
        yield return _frequency;
        _spawn = null;
    }

    private void TurnOff()
    {
        this.enabled = false;
    }
}
