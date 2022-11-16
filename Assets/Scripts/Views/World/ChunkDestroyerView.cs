using System;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;

public class ChunkDestroyerView : MonoBehaviour, IChunkDestoryerView
{
    private IChunkDestroyerPresenter _destroyerPresenter;
    
    public void SetPresenter(IChunkDestroyerPresenter presneter)
    {
        _destroyerPresenter = presneter;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(other.transform.parent.gameObject);
    }
}