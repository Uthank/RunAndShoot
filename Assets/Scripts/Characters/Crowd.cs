using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(Player))]
public class Crowd : MonoBehaviour
{
    [SerializeField] private Ally _ally;
    [SerializeField] private TMP_Text _textField;

    private Player _player;

    private List<Ally> _allies = new List<Ally>();
    private Vector3 _allySpawnOffset = new Vector3(-1.5f, 0, 0);
    private Vector3 _allySpawnOffsetExtends = new Vector3(1, 0, 1);

    private void Awake()
    {
        _player = GetComponent<Player>();
        CreateAllies(count: 20);
    }

    public void CreateAllies(UpgradeTypes upgradeType = UpgradeTypes.Additive, int count = 1)
    {
        if (upgradeType == UpgradeTypes.Multiplicate)
            count = (count - 1) * _allies.Count;

        for (int i = 0; i < count; i++)
        {
            float offsetZ = Random.Range(-_allySpawnOffsetExtends.z, _allySpawnOffsetExtends.z);
            float offsetX = Random.Range(-_allySpawnOffsetExtends.x, _allySpawnOffsetExtends.x);
            Vector3 offset = _allySpawnOffset + new Vector3(offsetZ, 0, offsetX);

            Ally ally = Instantiate(_ally, transform.position + offset, Quaternion.identity, transform);
            ally.Initialize(_player);
            _allies.Add(ally);
        }
        RedrawCount();
    }

    public void AddAllyToList(Ally ally)
    {
        _allies.Add(ally);
        RedrawCount();
    }

    public bool Damage()
    {
        if (_allies.Count == 0)
            return false;

        Ally ally = _allies[0];
        _allies.RemoveAt(0);
        ally.Kill();

        RedrawCount();
        return true;
    }

    public void RemoveAlly(Ally ally)
    {
        _allies.Remove(ally);
        RedrawCount();
    }

    public void RedrawCount()
    {
        _textField.text = _allies.Count.ToString();
    }

    public List<Archer> GetArchers()
    {
        List<Archer> list = new List<Archer>();

        foreach (var ally in _allies)
        {
            ally.transform.parent = null;
            ally.GetComponent<Attacker>().DisableInput();
            ally.GetComponent<Formation>().enabled = false;
            ally.GetComponent<Collider>().enabled = false;
            list.Add(ally);
        }

        _allies.Clear();
        _textField.enabled = false;
        return list;
    }
}
