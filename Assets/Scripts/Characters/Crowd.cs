using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(Mover))]
public class Crowd : MonoBehaviour
{
    [SerializeField] King _king;
    [SerializeField] private Paw _ally;
    [SerializeField] private TMP_Text _textField;

    private Mover _mover;

    private List<Paw> _paws = new List<Paw>();
    private Vector3 _allySpawnOffset = new Vector3(-1.5f, 0, 0);
    private Vector3 _allySpawnOffsetExtends = new Vector3(1, 0, 1);

    public King King => _king;

    private void Awake()
    {
        _mover = GetComponent<Mover>();
        _king = Instantiate(_king, transform);
        _king.Killed += StopMover;
        CreateAllies();
    }

    private void OnDisable()
    {
        _king.Killed -= StopMover;
    }

    public void CreateAllies(UpgradeTypes upgradeType = UpgradeTypes.Additive, int count = 1)
    {
        if (upgradeType == UpgradeTypes.Multiplicate)
            count = (count - 1) * _paws.Count;

        for (int i = 0; i < count; i++)
        {
            float offsetZ = Random.Range(-_allySpawnOffsetExtends.z, _allySpawnOffsetExtends.z);
            float offsetX = Random.Range(-_allySpawnOffsetExtends.x, _allySpawnOffsetExtends.x);
            Vector3 offset = _allySpawnOffset + new Vector3(offsetZ, 0, offsetX);

            Paw paw = Instantiate(_ally, transform.position + offset, Quaternion.identity, transform);
            _paws.Add(paw);
        }
        RedrawCount();
    }

    public void AddAllyToList(Paw paw)
    {
        _paws.Add(paw);
        RedrawCount();
    }

    public void Damage()
    {
        if (King.IsAlive == true)
        {
            if (_paws.Count == 0)
            {
                King.Kill();
            }

            Paw paw = _paws[0];
            _paws.RemoveAt(0);
            paw.Kill();

            RedrawCount();
        }
    }

    public void RemovePaw(Paw paw)
    {
        _paws.Remove(paw);
        RedrawCount();
    }

    public void RedrawCount()
    {
        _textField.text = _paws.Count.ToString();
    }

    public List<Archer> GetArchers()
    {
        List<Archer> list = new List<Archer>();

        list.Add(King);

        foreach (var paw in _paws)
        {
            paw.transform.parent = null;
            paw.GetComponent<Attacker>().DisableInput();
            paw.GetComponent<Formation>().enabled = false;
            paw.GetComponent<Collider>().enabled = false;
            list.Add(paw);
        }

        _paws.Clear();
        _textField.enabled = false;
        return list;
    }

    private void StopMover()
    {
        _mover.DisableInput();
        _mover.enabled = false;
    }
}
