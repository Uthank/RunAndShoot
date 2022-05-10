using System.Collections;
using UnityEngine;

[CreateAssetMenu(menuName ="HitEffect")]
public class HitEffect : ScriptableObject
{
    [SerializeField] EffectTypes effectType;

    public EffectTypes EffectType => EffectType;
}
