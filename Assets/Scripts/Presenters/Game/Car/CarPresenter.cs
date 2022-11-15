using System;
using Models;
using UnityEngine;
using Zenject;

public class CarPresenter : ICarPresenter, IInitializable, IDisposable
{
    private readonly SignalBus _signalBus;
    private readonly ICarView _carView;
    private readonly CommonGameSettings _commonGameSettings;

    public CarPresenter(SignalBus signalBus, ICarView carView, CommonGameSettings commonGameSettings)
    {
        _signalBus = signalBus;
        _carView = carView;
        _commonGameSettings = commonGameSettings;
    }
    public void CollideWith()
    {
        throw new System.NotImplementedException();
    }

    public void Initialize()
    {
        _carView.SetPresenter(this);
        
        _signalBus.Subscribe<GameSignals.ChangeCar>(OnChangeCar);
        _signalBus.Subscribe<GameSignals.StartClick>(OnStartGame);
    }

    public void Dispose()
    {
        _signalBus.Unsubscribe<GameSignals.ChangeCar>(OnChangeCar);
    }

    private void OnChangeCar(GameSignals.ChangeCar obj)
    {
        _carView.ChangeModel(_commonGameSettings.BodyCarModel);
    }

    private void OnStartGame(GameSignals.StartClick obj)
    {
        var carModel = _carView.GetCar();
        carModel.GetComponent<Rigidbody2D>().simulated = true;
    }
    
}
