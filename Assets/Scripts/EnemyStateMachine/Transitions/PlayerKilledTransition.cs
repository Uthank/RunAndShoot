public class PlayerKilledTransition : Transition
{
    private void Update()
    {
        if (Target == null)
        {
            NeedTransit = true;
        }
    }
}
