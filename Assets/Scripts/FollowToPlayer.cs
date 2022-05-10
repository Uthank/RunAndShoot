using UnityEngine;

public class FollowToPlayer : MonoBehaviour
{
    [SerializeField] private Crowd _crowd;
    
    private Vector3 _offset;
    private King _king;

    private void Awake()
    {
        _king = _crowd.GetComponentInChildren<King>();
        _offset = transform.position - _king.transform.position;
    }

    private void Update()
    {
        transform.position = new Vector3(_king.transform.position.x, _king.transform.position.y, 0) + _offset;
    }
    private void OnEnable()
    {
        _king.Killed += OnTargetKilled;
    }

    private void OnDisable()
    {
        _king.Killed -= OnTargetKilled;
    }
    private void OnTargetKilled()
    {
        this.enabled = false;
    }
}
