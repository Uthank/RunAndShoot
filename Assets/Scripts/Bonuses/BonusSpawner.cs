using UnityEngine;

public class BonusSpawner : MonoBehaviour
{
    [SerializeField] private BonusList _bonusList;

    public void BonusSpawn()
    {
        Instantiate(_bonusList.GetRandomBonus(), transform);
    }
}
