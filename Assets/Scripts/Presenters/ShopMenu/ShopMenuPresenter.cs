using System;
using System.Collections.Generic;
using Models;
using Unity.VisualScripting.FullSerializer.Internal.Converters;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class ShopMenuPresenter : IInitializable, IShopMenuPresenter, IDisposable
{
    private readonly SignalBus _signalBus;
    private readonly IShopMenuView _shopMenuView;
    private readonly CommonGameSettings _commonGameSettings;
    

    public ShopMenuPresenter(SignalBus signalBus, IShopMenuView shopMenuView, CommonGameSettings commonGameSettings)
    {
        _signalBus = signalBus;
        _shopMenuView = shopMenuView;
        _commonGameSettings = commonGameSettings;
    }

    public void Initialize()
    {
        _shopMenuView.SetPresenter(this);
        
        _signalBus.Subscribe<GameSignals.ShopClick>(OnShopMenuCallback);
    }

    private void OnShopMenuCallback(GameSignals.ShopClick obj)
    {
        _shopMenuView.Show(true);
    }


    public void Dispose()
    {
       _signalBus.Unsubscribe<GameSignals.ShopClick>(OnShopMenuCallback);
    }

    public void OnBackButtonClick()
    {
        _shopMenuView.Show(false);
        _signalBus.Fire<GameSignals.BackToMenu>();
    }

    public void GetCarChoose(GameObject car)
    {
        _commonGameSettings.SetCarModel(car);
        _signalBus.Fire<GameSignals.ChangeCar>();
    }
}