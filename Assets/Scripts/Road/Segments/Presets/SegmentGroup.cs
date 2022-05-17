using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Road/SegmentGroup")]
public class SegmentGroup : ScriptableObject
{
    [SerializeField] private RoadSegment _upgradeSegment;
    [SerializeField] private UpgradeGoodness _leftGoodness;
    [SerializeField] private UpgradeTypes _leftUpgradeType;
    [SerializeField] private int _leftValue;
    [SerializeField] private UpgradeGoodness _rightGoodness;
    [SerializeField] private UpgradeTypes _rightUpgradeType;
    [SerializeField] private int _rightValue;
    [SerializeField] private List<RoadSegment> _segments = new List<RoadSegment>();

    public Vector3 InstantiateGroup(Vector3 placingPosition)
    {
        GameObject upgradeSegment = Instantiate(_upgradeSegment.Prefab, placingPosition, Quaternion.identity);
        upgradeSegment.GetComponent<UpgradeSegment>().Initialize(_leftGoodness, _leftUpgradeType, _leftValue, _rightGoodness, _rightUpgradeType, _rightValue);
        placingPosition += _upgradeSegment.OffsetToNextPlacingPosition;

        foreach (RoadSegment segment in _segments)
        {
            Instantiate(segment.Prefab, placingPosition, Quaternion.identity);
            placingPosition += segment.OffsetToNextPlacingPosition;
        }

        return placingPosition;
    }
}
