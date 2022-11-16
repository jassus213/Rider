using Zenject;

public class MainMenuPresenter : IMainMenuPresenter, IInitializable
{
    private readonly SignalBus _signalBus;
    private readonly IMainMenuView _menuView;
    private readonly GameStatus _gameStatus;

    public MainMenuPresenter(SignalBus signalBus, IMainMenuView menuView, GameStatus gameStatus)
    {
        _signalBus = signalBus;
        _menuView = menuView;
        _gameStatus = gameStatus;
    }

    public void OnStartClick()
    {
        _menuView.Show(false);
        _gameStatus.SetGameStartStatus(true);
        _signalBus.Fire<GameSignals.StartClick>();
    }

    public void OnShopClick()
    {
        _menuView.Show(false);
        _signalBus.Fire<GameSignals.ShopClick>();
    }

    public void OnSettingsClick()
    {
        _menuView.Show(false);
        _signalBus.Fire<GameSignals.SettingsClick>();
    }

    public void Initialize()
    {
        _menuView.SetPresenter(this);
        
        _signalBus.Subscribe<GameSignals.BackToMenu>(OnBackToMenu);
    }

    private void OnBackToMenu(GameSignals.BackToMenu obj)
    {
        _menuView.Show(true);
    }
}
