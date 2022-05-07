using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private Player _player;

    private float _maxOffset = 2.5f;
    private IEnumerator _spawn;

    private void OnEnable()
    {
        _player.Killed += OnTargetKilled;
    }

    private void OnDisable()
    {
        _player.Killed -= OnTargetKilled;
    }

    private void Update()
    {
        if (_spawn == null)
        {
            _spawn = SpawnEnemy();
            StartCoroutine(_spawn);
        }
    }

    private IEnumerator SpawnEnemy()
    {
        float offsetX = Random.Range(-_maxOffset, _maxOffset);
        float offsetZ = Random.Range(-_maxOffset, _maxOffset);

        Enemy enemy = Instantiate(_enemy, transform.position + new Vector3(offsetX, 0, offsetZ), Quaternion.Euler(0, 180, 0));
        enemy.SetTarget(_player);
        yield return new WaitForSeconds(0.5f);
        _spawn = null;
    }

    private void OnTargetKilled()
    {
        this.enabled = false;
    }
}
