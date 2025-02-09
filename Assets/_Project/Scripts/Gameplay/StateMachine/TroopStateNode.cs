using _Project.Scripts.Gameplay.Troops;
using _Project.Scripts.Gameplay.Troops.Base;

public class TroopStateNode : IStateNode
{
    public bool IsEnter { get; set; }

    protected readonly TroopBase _troop;
    private readonly IAnimationListener _animationController;


    protected TroopStateNode(IAnimationListener animationController, TroopBase troop)
    {
        _animationController = animationController;
        _troop = troop;
    }

    public virtual void OnEnter()
    {
        IsEnter = true;
        _animationController.Notify(this);
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