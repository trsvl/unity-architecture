namespace _Project.Scripts.GameSystemLogic
{
    public class GameplayEntryPoint : EntryPoint
    {
        protected override void Awake()
        {
            base.Awake();

            container.GetService<GameplayStateObserver>().StartGame();
            print(ProjectData.Instance.Currency);
        }
    }
}