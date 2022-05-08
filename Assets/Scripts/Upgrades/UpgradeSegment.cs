using UnityEngine;

public class UpgradeSegment : Segment
{
    [SerializeField] private Upgrader _left;
    [SerializeField] private Upgrader _right;

    public void Initialize(UpgradeGoodness firstUpgradeGoodness, UpgradeTypes firstUpgradeTypes, int firstValue, UpgradeGoodness SecondUpgradeGoodness, UpgradeTypes secondUpgradeTypes, int secondValue)
    {
        _left.Initialize(firstUpgradeGoodness, firstUpgradeTypes, firstValue);
        _right.Initialize(SecondUpgradeGoodness, secondUpgradeTypes, secondValue);
    }
}
