using UnityEngine;

[CreateAssetMenu(menuName = "BonusList")]
public class BonusList : ScriptableObject
{
    [SerializeField] Bonus[] _bonuses;

    public Bonus GetRandomBonus()
    {
        return _bonuses[Random.Range(0, _bonuses.Length)];
    }
}
