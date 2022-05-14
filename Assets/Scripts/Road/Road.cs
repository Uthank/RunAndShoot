using UnityEngine;

public class Road : MonoBehaviour
{
    [SerializeField] private RoadSegment _start;
    [SerializeField] private RoadSegment _finish;
    [SerializeField] private SegmentGroup[] _segmentGroups;
    [SerializeField] private EnemySpawner _enemySpawner;
    [SerializeField] private FollowToPlayer _cameraFollow;

    private Vector3 _placingPosition = Vector3.zero;

    private void Awake()
    {
        GameObject start = InstantiateSegment(_start);

        foreach (var segment in _segmentGroups)
        {
            _placingPosition = segment.InstantiateGroup(_placingPosition);
        }

        GameObject finish = InstantiateSegment(_finish);
        finish.GetComponentInChildren<FinishZone>().Initialize(_enemySpawner, _cameraFollow);
    }

    private GameObject InstantiateSegment(RoadSegment segment)
    {
        GameObject InstantiatedSegment = Instantiate(segment.Prefab, _placingPosition, Quaternion.identity);
        _placingPosition += segment.OffsetToNextPlacingPosition;
        return InstantiatedSegment;
    }
}
