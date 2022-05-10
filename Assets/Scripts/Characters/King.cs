using UnityEngine.Events;

public class King : Archer
{
    public UnityAction Killed;

    public bool IsAlive { get; private set; } = true;

    public void Damage()
    {
        Crowd.Damage();
    }

    public override void Kill()
    {
        Killed?.Invoke();
        IsAlive = false;
        base.Kill();
    }
}
