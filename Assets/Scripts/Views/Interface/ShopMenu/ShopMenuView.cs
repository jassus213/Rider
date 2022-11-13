using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ShopMenuView : MonoBehaviour, IShopMenuView
{
    private IShopMenuPresenter _presenter;
    
    [SerializeField] private Button _backButton;


    public void SetPresenter(IShopMenuPresenter presenter)
    {
        _presenter = presenter;
     
        _backButton.onClick.AddListener(_presenter.OnBackButtonClick);
    }
    
    public void Show(bool show)
    {
        gameObject.SetActive(show);
    }

    
}
