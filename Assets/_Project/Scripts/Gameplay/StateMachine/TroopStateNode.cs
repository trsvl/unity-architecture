public class TroopStateNode : IStateNode
{
    public bool IsEnter { get; set; }

    private readonly IAnimationListener _animationListener;


    protected TroopStateNode(IAnimationListener animationListener)
    {
        _animationListener = animationListener;
    }

    public virtual void OnEnter()
    {
        IsEnter = true;
        _animationListener.Notify(this);
    }

    public virtual void Update()
    {
    }

    public virtual void FixedUpdate()
    {
    }

    public virtual void OnExit()
    {
        IsEnter = false;
        _animationListener.NotifyExit(this);
    }
}