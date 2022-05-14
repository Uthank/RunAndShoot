using UnityEngine;

[CreateAssetMenu(menuName = "Weapon")]
public class Weapon : ScriptableObject
{
    [SerializeField] private GameObject _model;
    [SerializeField] private ArrowType _arrowType;
    [SerializeField] private Gradient _DrawedLineColor;

    public GameObject Model => _model;
    public ArrowType ArrowType => _arrowType;
    public Gradient DrawedLineColor => _DrawedLineColor;
}
