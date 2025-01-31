using _Project.Scripts.Gameplay.Troops;

public class TroopStateNode : IStateNode
{
    public bool IsEnter { get; set; }

    protected readonly TroopBase _troop;
    private readonly IAnimationListener _animationListener;


    protected TroopStateNode(IAnimationListener animationListener, TroopBase troop)
    {
        _animationListener = animationListener;
        _troop = troop;
    }

    public virtual void OnEnter()
    {
        IsEnter = true;
        _animationListener.Notify(this);
        _troop.CheckRotation();
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
    }
}