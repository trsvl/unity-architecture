public interface IGameplayStateObserver : IStateObserver
{
    public void StartGame();
    public void PauseGame();
    public void ResumeGame();
    public void FinishGame();
}