public interface ISettingsMenuPresenter
{
    public void OnBackButtonClick();
    void OnFullscreenToggle(bool value);
    void OnMusicVolumeChange(float volume);
    void OnEffectsVolumeChange(float volume);
}

