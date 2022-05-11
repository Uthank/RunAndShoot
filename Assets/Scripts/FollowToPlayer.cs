using UnityEngine;

public class FollowToPlayer : MonoBehaviour
{
    [SerializeField] private Crowd _crowd;
    
    private Vector3 _offset;
    private King _king;

    private void Start()
    {
        _king = _crowd.GetComponentInChildren<King>();
        _offset = transform.position - _king.transform.position;
        _king.Killed += OnTargetKilled;
    }

    private void Update()
    {
        transform.position = new Vector3(_king.transform.position.x, _king.transform.position.y, 0) + _offset;
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
