using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class Crowd : MonoBehaviour
{
    [SerializeField] private Ally _ally;

    private Player _player;
    private List<Ally> _allies = new List<Ally>();
    private Vector3 _allySpawnOffset = new Vector3(-1.5f, 0, 0);
    private Vector3 _allySpawnOffsetExtends = new Vector3(1, 0, 1);

    private void Awake()
    {
        _player = GetComponent<Player>();
    }

    private void AddAllies(int count = 1)
    {
        for (int i = 0; i < count; i++)
        {
            float offsetZ = Random.Range(-_allySpawnOffsetExtends.z, _allySpawnOffsetExtends.z);
            float offsetX = Random.Range(-_allySpawnOffsetExtends.x, _allySpawnOffsetExtends.x);
            Vector3 offset = _allySpawnOffset + new Vector3(offsetZ, 0, offsetX);

            Ally ally = Instantiate(_ally, transform.position + offset, Quaternion.identity, transform);
            ally.SetPlayer(_player);
            _allies.Add(ally);
        }
    }

    public bool Damage(Ally allyToKill = null)
    {
        if (_allies.Count == 0)
            return false;

        if (allyToKill == null)
        {
            Ally ally = _allies[0];
            _allies.RemoveAt(0);
            Destroy(ally.gameObject);
        }
        else
        {
            _allies.Remove(allyToKill);
            Destroy(allyToKill.gameObject);
        }

        return true;
    }
}
