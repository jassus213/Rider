using UnityEngine;
using UnityEngine.UI;

public class SettingsMenuView : MonoBehaviour, ISettingsMenuView
{
    private ISettingsMenuPresenter _presenter;
    
    [SerializeField] private Button backButton;
    [SerializeField] private Toggle fullscreenToggle;
    [SerializeField] private Slider musicVolumeSlider;
    [SerializeField] private Slider effectsVolumeSlider;

    public void SetPresenter(ISettingsMenuPresenter presenter)
    {
        _presenter = presenter;
        
        backButton.onClick.AddListener(_presenter.OnBackButtonClick);
        fullscreenToggle.onValueChanged.AddListener(_presenter.OnFullscreenToggle);
        musicVolumeSlider.onValueChanged.AddListener(_presenter.OnMusicVolumeChange);
        effectsVolumeSlider.onValueChanged.AddListener(_presenter.OnEffectsVolumeChange);
    }

    public void Show(bool show)
    {
        gameObject.SetActive(show);
    }
}
