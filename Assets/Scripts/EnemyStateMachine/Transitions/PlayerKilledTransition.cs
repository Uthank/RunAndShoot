public class PlayerKilledTransition : Transition
{
    private void Update()
    {
        if (Target.IsAlive == false)
        {
            NeedTransit = true;
        }
    }
}
