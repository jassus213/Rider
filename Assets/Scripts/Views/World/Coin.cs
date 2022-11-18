using Models;
using UnityEngine;

public class Coin : MonoBehaviour, ICollectable, IDestroyable
{
    private readonly CommonGameSettings _commonGameSettings;

    public Coin(CommonGameSettings commonGameSettings)
    {
        _commonGameSettings = commonGameSettings;
    }
    public void Collect()
    {
        _commonGameSettings.SetValue(1);
    }

    public void DerstoryObject()
    {
        Destroy(this.gameObject);
    }
}