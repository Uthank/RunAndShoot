using System;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour, IKillable
{
    private Crowd _crowd;

    public UnityAction Killed;

    public bool IsAlive { get; private set; } = true;

    private void Awake()
    {
        _crowd = GetComponent<Crowd>();
    }

    public void Damage()
    {
        if (_crowd.Damage() == false)
            Kill();
    }

    public void Kill()
    {
        Killed?.Invoke();
        IsAlive = false;
        Destroy(gameObject);
    }
}
