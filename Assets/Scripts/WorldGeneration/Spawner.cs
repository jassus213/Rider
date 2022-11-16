using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private ChunkGeneration _chunkGeneration;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Chunk"))
        {
            _chunkGeneration.SpawnChunk(col.gameObject);
        }
    }
}
