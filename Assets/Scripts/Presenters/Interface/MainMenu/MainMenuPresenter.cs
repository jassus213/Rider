using Zenject;

public class MainMenuPresenter : IMainMenuPresenter, IInitializable
{
    private readonly SignalBus _signalBus;
    private readonly IMainMenuView _menuView;

    public MainMenuPresenter(SignalBus signalBus, IMainMenuView menuView)
    {
        _signalBus = signalBus;
        _menuView = menuView;
    }

    public void OnStartClick()
    {
        _menuView.Show(false);
        _signalBus.Fire<GameSignals.StartClick>();
    }

    public void OnShopClick()
    {
        _menuView.Show(false);
        _signalBus.Fire<GameSignals.ShopClick>();
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
