using UnityEngine;
using UnityEngine.UI;

public class SettingsMenuView : MonoBehaviour, ISettingsMenuView
{
    private ISettingsMenuPresenter _presenter;
    
    [SerializeField] private Button _backButton;
    public void SetPresenter(ISettingsMenuPresenter presenter)
    {
        _presenter = presenter;
        
        _backButton.onClick.AddListener(_presenter.OnBackButtonClick);
    }

    public void Show(bool show)
    {
        gameObject.SetActive(show);
    }
}
