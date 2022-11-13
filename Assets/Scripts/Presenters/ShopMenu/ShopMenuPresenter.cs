using System;
using Zenject;

public class ShopMenuPresenter : IInitializable, IShopMenuPresenter, IDisposable
{
    private readonly SignalBus _signalBus;
    private readonly IShopMenuView _shopMenuView;

    public ShopMenuPresenter(SignalBus signalBus, IShopMenuView shopMenuView)
    {
        _signalBus = signalBus;
        _shopMenuView = shopMenuView;
    }

    public void Initialize()
    {
        _signalBus.Subscribe<GameSignals.ShopClick>(OnShopMenuCallback);
    }

    private void OnShopMenuCallback(GameSignals.ShopClick obj)
    {
        _shopMenuView.Show(true);
    }


    public void Dispose()
    {
        
    }
}