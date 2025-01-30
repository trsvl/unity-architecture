public interface IAnimationListener : IStateListener
{
    public bool IsReadyForNextAnimation { get; }
}

public interface IAttackAnimationListener : IAnimationListener
{
    public bool IsReadyForAttack { get; }
}