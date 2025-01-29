public class BaseMachineState : IMachineState
{
    public bool IsEnter { get; set; }
    public bool IsExit { get; set; }
    public bool IsNextState { get; set; }

    public virtual void OnEnter()
    {
        IsNextState = false;
        IsExit = false;
        IsEnter = true;
    }

    public virtual void Update()
    {
    }

    public virtual void FixedUpdate()
    {
    }

    public virtual void OnExit()
    {
        IsExit = true;
        IsEnter = false;
    }
}