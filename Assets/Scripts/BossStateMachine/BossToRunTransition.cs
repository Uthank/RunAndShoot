using UnityEngine;

[RequireComponent(typeof(Boss))]
public class BossToRunTransition : Transition
{
    private Boss _boss;

    private void OnEnable()
    {
        _boss = GetComponent<Boss>();
    }

    private void Update()
    {
        if (Physics.Raycast(new Ray(transform.position, Vector3.down), .5f) == true)
        {
            _boss.KillEnemies();
            NeedTransit = true;
        }
    }
}
