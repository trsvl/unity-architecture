using UnityEngine;

public class TroopState : BaseMachineState
{
    private readonly IAnimationListener _animationListener;


    protected TroopState(IAnimationListener animationListener)
    {
        _animationListener = animationListener;
    }

    public override void OnEnter()
    {
        base.OnEnter();
        _animationListener.Notify(this);
        Debug.Log("Enter State: " + this);
    }

    public override void Update()
    {
    }

    public override void FixedUpdate()
    {
    }

    public override void OnExit()
    {
        base.OnExit();
        _animationListener.NotifyExit(this);
        Debug.Log("Leave State: " + this);
    }
}