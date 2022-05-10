using UnityEngine;

public class Ally : Archer
{
    public Player Player { get; private set; }

    public void Initialize(Player player)
    {
        Player = player;
    }

    public override void Kill(Transform forceSource = null, float force = 0)
    {
        transform.parent = null;
        Player.Crowd.RemoveAlly(this);
        base.Kill(forceSource, force);
    }
}
