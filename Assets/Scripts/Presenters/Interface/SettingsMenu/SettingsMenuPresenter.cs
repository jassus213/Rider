using System;
using Zenject;

public class SettingsMenuPresenter : IInitializable, ISettingsMenuPresenter, IDisposable
{
    private readonly SignalBus _signalBus;
    private readonly ISettingsMenuView _settingsMenuView;


    public SettingsMenuPresenter(SignalBus signalBus, ISettingsMenuView settingsMenuView)
    {
        _signalBus = signalBus;
        _settingsMenuView = settingsMenuView;
    }

    public void Initialize()
    {
        _settingsMenuView.SetPresenter(this);
        _signalBus.Subscribe<GameSignals.SettingsClick>(OnSettingsMenuCallback);
    }
    
    private void OnSettingsMenuCallback(GameSignals.SettingsClick obj)
    {
        _settingsMenuView.Show(true);
    }
    
    public void OnBackButtonClick()
    {
        _settingsMenuView.Show(false);
        _signalBus.Fire<GameSignals.BackToMenu>();
    }

    public void Dispose()
    {
        _signalBus.Unsubscribe<GameSignals.SettingsClick>(OnSettingsMenuCallback);
    }
}
