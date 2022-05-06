using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour
{
    [SerializeField] private RoadPreset _roadPreset;
    [SerializeField] private RoadSegment _start;
    [SerializeField] private RoadSegment _finish;

    private Vector3 _placingPosition = Vector3.zero;

    private void Awake()
    {
        InstantiateSegment(_start);

        List<RoadSegment> segments = _roadPreset.GetSegments();

        foreach (RoadSegment segment in segments)
        {
            InstantiateSegment(segment);
        }

        InstantiateSegment(_finish);
    }

    private void InstantiateSegment(RoadSegment segment)
    {
        Instantiate(segment.Prefab, _placingPosition, Quaternion.identity);
        _placingPosition += segment.OffsetToNextPlacingPosition;
    }
}
