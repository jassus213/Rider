using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class ChunksModel
{
    [SerializeField] private List<GameObject> _chunks;
    public List<GameObject> Chunks => _chunks;

    
    public void AddChunk(GameObject chunk)
    {
        _chunks.Add(chunk);
    }

    public void RemoveChunk(GameObject chunk)
    {
        _chunks.Remove(chunk);
    }

    public GameObject[] GetChunks()
    {
        _chunks = GameObject.FindGameObjectsWithTag("Chunk").ToList();
        Debug.Log(_chunks.Count);
        return _chunks.ToArray();
    }
}