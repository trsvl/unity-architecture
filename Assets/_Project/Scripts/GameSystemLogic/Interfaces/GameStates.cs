namespace _Project.Scripts.GameSystemLogic.Interfaces
{
    public enum GameState
    {
        OFF,
        PLAY,
        PAUSE,
        FINISH
    }

    public interface IStartGame
    {
        public void StartGame();
    }

    public interface IPauseGame
    {
        public void PauseGame();
    }

    public interface IResumeGame
    {
        public void ResumeGame();
    }

    public interface IFinishGame
    {
        public void FinishGame();
    }
}