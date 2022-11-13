using System;
using UnityEngine;

public class ShopMenuView : MonoBehaviour, IShopMenuView
{
    private IShopMenuPresenter _presenter;


    public void SetPresenter(IShopMenuPresenter presenter)
    {
        _presenter = presenter;
        
    }
    
    public void Show(bool show)
    {
        gameObject.SetActive(show);
    }
}
