using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldView : MonoBehaviour, IWorldView
{
    private IWorldPresenter _WorldPresenter;

    public void SetPresenter(IWorldPresenter presenter)
    {
        _WorldPresenter = presenter;
    }
    
}
