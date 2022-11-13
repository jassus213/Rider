using UnityEngine;
using UnityEngine.UI;

public class MainMenuView : MonoBehaviour, IMainMenuView
{
    [SerializeField] private Button _startButton;

    private IMainMenuPresenter _presenter;


    public void SetPresenter(IMainMenuPresenter presenter)
    {
        _presenter = presenter;
        
        _startButton.onClick.AddListener(_presenter.OnStartClick);
    }

    public void Show(bool show)
    {
        gameObject.SetActive(show);
    }
}
