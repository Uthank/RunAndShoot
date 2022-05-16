using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusFrostBuff : Bonus
{
    [SerializeField] Weapon _weapon;
    [SerializeField] Color _colorBuffedCrowdTMPText;
    [SerializeField] GameObject _model;
    [SerializeField] AnimationCurve _jumpCurve;

    private Renderer _renderer;
    private List<Attacker> _attackers = new List<Attacker>();
    private float _duration = 3;
    private WaitForSeconds _baffDuration;
    private float _time;

    private void Awake()
    {
        _baffDuration = new WaitForSeconds(_duration);
        _renderer = GetComponentInChildren<Renderer>();
    }

    private void Update()
    {
        _time = (_time + Time.deltaTime) % 1;
        _model.transform.position = transform.position + new Vector3(0, _jumpCurve.Evaluate(_time), 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.TryGetComponent<Archer>(out Archer archer) == true)
            StartCoroutine(Buff(archer));
    }

    private IEnumerator Buff(Archer archer)
    {
        _renderer.enabled = false;
        archer.Crowd.SetColor(_colorBuffedCrowdTMPText, _duration);
        _attackers.AddRange(archer.Crowd.GetComponentsInChildren<Attacker>());

        foreach (var attacker in _attackers)
            attacker.ChangeWeapon(_weapon);

        yield return _baffDuration;

        foreach (var attacker in _attackers)
            attacker.ChangeWeapon();

        Destroy(gameObject);
    }
}
