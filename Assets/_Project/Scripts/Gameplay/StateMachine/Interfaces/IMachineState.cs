public interface IMachineState
{
    public bool IsEnter { get; set; }
    public bool IsExit { get; set; }
    public bool IsNextState { get; set; }

    public void OnEnter();
    public void Update();
    public void FixedUpdate();
    public void OnExit();
}