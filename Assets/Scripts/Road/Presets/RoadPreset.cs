using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Road/Preset")]
public class RoadPreset : ScriptableObject
{
    [SerializeField] private List<RoadSegment> _segments = new List<RoadSegment>();

    public List<RoadSegment> GetSegments()
    {
        List<RoadSegment> segments = new List<RoadSegment>();

        foreach (RoadSegment segment in _segments)
        {
            segments.Add(segment);
        }

        return segments;
    }
}
