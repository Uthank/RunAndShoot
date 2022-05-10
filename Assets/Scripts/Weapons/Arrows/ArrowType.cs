using UnityEngine;

[CreateAssetMenu(menuName = "ArrowType")]
public class ArrowType : ScriptableObject
{
    [SerializeField] private GameObject _model;
    [SerializeField] private EffectTypes _hitEffect;

    public GameObject Model => _model;
    public EffectTypes HitEffect => _hitEffect;
}
