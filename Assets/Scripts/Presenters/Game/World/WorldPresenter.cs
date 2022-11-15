using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class WorldPresenter : IWorldPresenter, IInitializable, IDisposable
{
    private readonly SignalBus _signalBus;
    private readonly IWorldView _worldView;
    
    public WorldPresenter(SignalBus signalBus, IWorldView WorldView)
    {
        _signalBus = signalBus;
        _worldView = WorldView;
    }
    
    public void Initialize()
    {
        _worldView.SetPresenter(this);
    }

    public void Dispose()
    {
        
    }
}
