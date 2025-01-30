public interface IStateNode
{
    public bool IsEnter { get; set; }

    public void OnEnter();
    public void Update();
    public void FixedUpdate();
    public void OnExit();
}