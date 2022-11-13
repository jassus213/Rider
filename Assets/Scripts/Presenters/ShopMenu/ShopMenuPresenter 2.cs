using Zenject;

public class ShopMenuPresenter : IInitializable, IShopMenuPresenter
{
    private readonly SignalBus _signalBus;

    public ShopMenuPresenter(SignalBus signalBus)
    {
        _signalBus = signalBus; 
    }

    public void Initialize()
    {
        
    }
}