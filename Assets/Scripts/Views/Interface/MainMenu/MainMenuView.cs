using UnityEngine;
using UnityEngine.UI;

public class MainMenuView : MonoBehaviour, IMainMenuView
{
    [SerializeField] private Button _startButton;
    [SerializeField] private Button _shopButton;
    [SerializeField] private Button _settingsButton;

    private IMainMenuPresenter _presenter;

    public void SetPresenter(IMainMenuPresenter presenter)
    {
        _presenter = presenter;

        _startButton.onClick.AddListener(_presenter.OnStartClick);
        _shopButton.onClick.AddListener(_presenter.OnShopClick);
        _settingsButton.onClick.AddListener(_presenter.OnSettingsClick);
    }

    public void Show(bool show)
    {
        gameObject.SetActive(show);
    }
}