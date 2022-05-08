using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusFrostBuff : Bonus
{
    [SerializeField] Weapon _weapon;

    private List<Attacker> _attackers = new List<Attacker>();
    private Renderer _renderer;
    private WaitForSeconds _baffDuration = new WaitForSeconds(3);

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.TryGetComponent<Ally>(out Ally ally) == true)
        {
            StartCoroutine(Buff(ally.Player));
        }

        if (other.transform.TryGetComponent<Player>(out Player player) == true)
        {
            StartCoroutine(Buff(player));
        }
    }

    private IEnumerator Buff(Player player)
    {
        _renderer.enabled = false;
        _attackers.AddRange(player.GetComponentsInChildren<Attacker>());

        foreach (var attacker in _attackers)
            attacker.ChangeWeapon(_weapon);

        yield return _baffDuration;

        foreach (var attacker in _attackers)
            attacker.ChangeWeapon();

        Destroy(gameObject);
    }
}
