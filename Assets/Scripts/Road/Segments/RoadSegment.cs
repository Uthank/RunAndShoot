using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Road/Segment")]
public class RoadSegment : ScriptableObject
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private Vector3 _offsetToNextPlacingPosition;

    public GameObject Prefab => _prefab;
    public Vector3 OffsetToNextPlacingPosition => _offsetToNextPlacingPosition;
}
