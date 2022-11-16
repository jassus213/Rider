using System;
using Models;
using UnityEngine;
using Zenject;

public class CarPresenter : ICarPresenter, IInitializable, IDisposable, IFixedTickable
{
    private readonly SignalBus _signalBus;
    private readonly ICarView _carView;
    private readonly CommonGameSettings _commonGameSettings;
    private readonly GameStatus _gameStatus;

    private float _movement;

    public CarPresenter(SignalBus signalBus, ICarView carView, CommonGameSettings commonGameSettings, GameStatus gameStatus)
    {
        _signalBus = signalBus;
        _carView = carView;
        _commonGameSettings = commonGameSettings;
        _gameStatus = gameStatus;
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
        var wheels = _carView.GetWheels();
        foreach (var wheel in wheels)
        {
            wheel.GetComponent<Rigidbody2D>().simulated = true;
        }
    }

    private void Move()
    {
        var car = _carView.GetCar();
        var wheels = _carView.GetWheels();
        var firstWheel = wheels[0];
        var secondWheel = wheels[1];
        
        if (Input.GetMouseButton(1))
        {
            firstWheel.GetComponent<WheelJoint2D>().useMotor = true;
            secondWheel.GetComponent<WheelJoint2D>().useMotor = true;
            Debug.Log("test");
            return;
        }

        firstWheel.GetComponent<WheelJoint2D>().useMotor = false;
        secondWheel.GetComponent<WheelJoint2D>().useMotor = false;
    }

    public void ChunkCollide()
    {
        _signalBus.Fire<GameSignals.CarCollideChunk>();
    }

    public void FixedTick()
    {
        if (_gameStatus.IsGameStarted)
        {
            Move();
        }
    }
}
