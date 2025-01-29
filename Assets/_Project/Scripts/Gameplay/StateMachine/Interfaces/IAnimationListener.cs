public interface IAnimationListener : IStateListener
{
    public void NotifyExit(IMachineState action);
}