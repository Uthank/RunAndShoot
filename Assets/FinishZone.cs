using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishZone : MonoBehaviour
{
    [SerializeField] private Vector3 _gate;
    [SerializeField] private Vector3 _firstPosition;
    [SerializeField] private float _StepX;
    [SerializeField] private float _StepZ;

    private List<Archer> _archers = new List<Archer>();

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Player>(out Player player) == true)
        {
            var mover = player.GetComponent<Mover>();
            mover.DisableInput();
            mover.enabled = false;
            player.GetComponent<Attacker>().DisableInput();
            _archers.Add(player);
            _archers.AddRange(player.GetComponent<Crowd>().GetArchers());
            MoveOnPositions();
        }
    }

    private void MoveOnPositions()
    {
        for (int i = 0; i < _archers.Count; i++)
        {
            Vector3 position = _firstPosition + new Vector3( -(i / 5) * _StepX, 0, -(i % 5f) * _StepZ);
            StartCoroutine(_archers[i].MoveThroughtPositions(new Vector3[] { transform.position + _gate, transform.position + position }));
        }
    }
}
