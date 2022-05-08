using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Segment : MonoBehaviour
{
    [SerializeField][Range(0f, 1f)] float _bonusSpawnProbability = .5f;
    private List<BonusSpawner> _spawners = new List<BonusSpawner>();

    private void Awake()
    {
        _spawners = GetComponentsInChildren<BonusSpawner>().ToList();

        if (_spawners.Count > 0)
        {
            foreach (BonusSpawner spawner in _spawners)
            {
                if (Random.Range(0f, 1f) > _bonusSpawnProbability)
                {
                    spawner.BonusSpawn();
                }
            }
        }
    }
}
