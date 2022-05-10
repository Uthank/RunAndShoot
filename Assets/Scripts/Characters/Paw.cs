using UnityEngine;

public class Paw : Archer
{
    public void Initialize(Crowd crowd)
    {
        Crowd = crowd;
    }

    public override void Kill()
    {
        transform.parent = null;
        Crowd.RemovePaw(this);
        base.Kill();
    }
}
