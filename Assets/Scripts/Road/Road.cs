using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour
{
    [SerializeField] private RoadSegment _start;
    [SerializeField] private RoadSegment _finish;
    [SerializeField] private SegmentGroup[] _segmentGroups;

    private Vector3 _placingPosition = Vector3.zero;

    private void Awake()
    {
        InstantiateSegment(_start);

        foreach (var segment in _segmentGroups)
        {
            _placingPosition = segment.InstantiateGroup(_placingPosition);
        }

        InstantiateSegment(_finish);
    }

    private void InstantiateSegment(RoadSegment segment)
    {
        Instantiate(segment.Prefab, _placingPosition, Quaternion.identity);
        _placingPosition += segment.OffsetToNextPlacingPosition;
    }
}
