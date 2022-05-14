using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class BonusFrostBuff : Bonus
{
    [SerializeField] Weapon _weapon;
    [SerializeField] Color _colorBuffedCrowdTMPText;

    private Renderer _renderer;
    private List<Attacker> _attackers = new List<Attacker>();
    private float _duration = 3;
    private WaitForSeconds _baffDuration;

    private void Awake()
    {
        _baffDuration = new WaitForSeconds(_duration);
        _renderer = GetComponent<Renderer>();
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
