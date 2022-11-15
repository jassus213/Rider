using UnityEngine;
using UnityEngine.UI;

public class SettingsMenuView : MonoBehaviour, ISettingsMenuView
{
    private ISettingsMenuPresenter _presenter;
    
    [SerializeField] private Button _backButton;
    [SerializeField] private Toggle _fullscreenToggle;
    [SerializeField] private Slider _musicVolumeSlider;
    [SerializeField] private Slider _effectsVolumeSlider;

    public void SetPresenter(ISettingsMenuPresenter presenter)
    {
        _presenter = presenter;
        
        _backButton.onClick.AddListener(_presenter.OnBackButtonClick);
        _fullscreenToggle.onValueChanged.AddListener(_presenter.OnFullscreenToggle);
        _musicVolumeSlider.onValueChanged.AddListener(_presenter.OnMusicVolumeChange);
        _effectsVolumeSlider.onValueChanged.AddListener(_presenter.OnEffectsVolumeChange);
    }

    public void Show(bool show)
    {
        gameObject.SetActive(show);
    }
}
