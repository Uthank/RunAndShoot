using UnityEngine;

[CreateAssetMenu(menuName = "Weapon")]
public class Weapon : ScriptableObject
{
    [SerializeField] private GameObject _model;
    [SerializeField] private ArrowType _arrowType;

    public GameObject Model => _model;
    public ArrowType ArrowType => _arrowType;
}
