namespace _Project.Scripts.GameSystemLogic
{
    public class MainMenuEntryPoint : EntryPoint
    {
        protected override void Awake()
        {
            base.Awake();

            container.GetService<IMainMenuStateObserver>().BattleScreen();
        }
    }
}