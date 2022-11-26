using System;
using System.Security.Cryptography;
using GameElements.Coin;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

public class ChunkDestroyerView : MonoBehaviour, IChunkDestoryerView
{
    private IChunkDestroyerPresenter _destroyerPresenter;
    public void SetPresenter(IChunkDestroyerPresenter presneter)
    {
        _destroyerPresenter = presneter;
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        var gameElement = other.GetComponent<ICoinView>();
        if (gameElement != null)
        {
            gameElement.Despawn();
        }
        else
        {
            Destroy(other.transform.gameObject);
        }    
        
    }
}