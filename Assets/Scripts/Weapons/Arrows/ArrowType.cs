using UnityEngine;

[CreateAssetMenu(menuName = "ArrowType")]
public class ArrowType : ScriptableObject
{
    [SerializeField] private GameObject _model;
    [SerializeField] private HitEffect _hitEffect;

    public GameObject Model => _model;
    public HitEffect HitEffect => _hitEffect;
}
