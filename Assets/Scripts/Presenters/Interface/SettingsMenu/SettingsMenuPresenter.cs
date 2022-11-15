using System;
using Models;
using Zenject;

public class SettingsMenuPresenter : IInitializable, ISettingsMenuPresenter, IDisposable
{
    private readonly SignalBus _signalBus;
    private readonly ISettingsMenuView _settingsMenuView;
    private readonly CommonGameSettings _commonGameSettings;


    public SettingsMenuPresenter(SignalBus signalBus, ISettingsMenuView settingsMenuView, CommonGameSettings commonGameSettings)
    {
        _signalBus = signalBus;
        _settingsMenuView = settingsMenuView;
        _commonGameSettings = commonGameSettings;
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

    public void OnFullscreenToggle(bool value)
    {
        _commonGameSettings.SetScreenResolution(value);
    }

    public void OnMusicVolumeChange(float volume)
    {
        _commonGameSettings.SetMusicVolume(volume);
    }

    public void OnEffectsVolumeChange(float volume)
    {
        _commonGameSettings.SetEffectsVolume(volume);
    }

    public void Dispose()
    {
        _signalBus.Unsubscribe<GameSignals.SettingsClick>(OnSettingsMenuCallback);
    }
}
