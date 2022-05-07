using UnityEngine;

[CreateAssetMenu(menuName = "Weapon")]
public class Weapon : ScriptableObject
{
    [SerializeField] GameObject _model;
    [SerializeField] ArrowType _arrowType;

    public GameObject Model => _model;
    public ArrowType ArrowType => _arrowType;
}
