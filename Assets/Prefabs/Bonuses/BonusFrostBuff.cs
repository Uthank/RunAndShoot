using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class BonusFrostBuff : Bonus
{
    [SerializeField] Weapon _weapon;

    private Renderer _renderer;
    private List<Attacker> _attackers = new List<Attacker>();
    private WaitForSeconds _baffDuration = new WaitForSeconds(3);

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.TryGetComponent<BodyPart>(out BodyPart bodyPart) == true)
            if (bodyPart.Character.GetType() == typeof(Paw) || bodyPart.Character.GetType() == typeof(King))
                StartCoroutine(Buff(bodyPart.Character.GetComponent<Archer>()));
    }

    private IEnumerator Buff(Archer archer)
    {
        _renderer.enabled = false;
        _attackers.AddRange(archer.Crowd.GetComponentsInChildren<Attacker>());

        foreach (var attacker in _attackers)
            attacker.ChangeWeapon(_weapon);

        yield return _baffDuration;

        foreach (var attacker in _attackers)
            attacker.ChangeWeapon();

        Destroy(gameObject);
    }
}
