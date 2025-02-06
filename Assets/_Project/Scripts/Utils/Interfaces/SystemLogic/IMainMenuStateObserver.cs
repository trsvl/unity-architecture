public interface IMainMenuStateObserver : IStateObserver
{
    public MainMenuState MainMenuState { get; }
    public void BattleScreen();
    public void CardsScreen();
    public void ShopScreen();
    public void TroopStatsScreen();
}