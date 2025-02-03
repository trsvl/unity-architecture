public interface IAnimationListener : IStateListener
{
}

public interface IAttackAnimationListener : IAnimationListener
{
    public bool IsReadyForAttack { get; }
}