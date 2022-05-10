using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishZone : MonoBehaviour
{
    [SerializeField] private Vector3 _gate;
    [SerializeField] private Vector3 _firstPosition;
    [SerializeField] private float _stepX;
    [SerializeField] private float _stepZ;
    [SerializeField] private Boss _boss;
    [SerializeField] private Vector3 _bossSpawnOffset;
    [SerializeField] protected float _positioningSpeed = 5;

    private PlayerInput _playerInput;

    private List<Archer> _archers = new List<Archer>();
    private float _epsylon = .3f;
    private string _finishZoneStayAnimation = "FinishPose";
    private EnemySpawner _enemySpawner;

    private void Awake()
    {
        _playerInput = new PlayerInput();
        _playerInput.FinishZone.Click.started += ctx => Shoot();
        _playerInput.Enable();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Crowd>(out Crowd crowd) == true)
        {
            crowd.GetComponent<Mover>().DisableInput();
            crowd.GetComponent<Mover>().enabled = false;
            _archers.AddRange(crowd.GetArchers());
            MoveCrowdOnPositions();
            BossSpawn();
        }
    }

    public void SetEnemySpawner(EnemySpawner enemySpawner)
    {
        _enemySpawner = enemySpawner;
    }

    public IEnumerator MoveThroughtPath(Archer archer, Vector3[] positions)
    {
        for (int i = 0; i < positions.Length; i++)
        {
            Vector3 pos = positions[i];

            while ((pos - archer.transform.position).magnitude > _epsylon)
            {
                archer.Rigidbody.velocity = (pos - archer.transform.position).normalized * _positioningSpeed;
                yield return null;
            }

            if (i == positions.Length - 1)
                archer.Animator.SetTrigger(_finishZoneStayAnimation);
        }
    }
    public void KillArchers(Transform forceSource, float force)
    {
        foreach (Archer archer in _archers)
        {
            archer.Kill();
        }
    }

    private void MoveCrowdOnPositions()
    {
        for (int i = 0; i < _archers.Count; i++)
        {
            Vector3 position = _firstPosition + new Vector3( -(i / 5) * _stepX, 0, -(i % 5f) * _stepZ);
            StartCoroutine(MoveThroughtPath(_archers[i], new Vector3[] { transform.position + _gate, transform.position + position }));
        }
    }

    private void Shoot()
    {
        foreach (var archer in _archers)
            archer.Attacker.ShootTarget(_boss.transform, _boss.Body.position);
    }

    private void BossSpawn()
    {
        _boss = Instantiate(_boss, transform.position + _bossSpawnOffset, Quaternion.Euler(0, 180, 0));
        _boss.Initialize(transform.position + _gate, _enemySpawner, this);
    }
}
