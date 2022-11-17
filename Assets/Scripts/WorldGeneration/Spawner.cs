using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private ChunkGeneration chunkGeneration;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Chunk"))
        {
            chunkGeneration.SpawnChunk(col.gameObject);
        }
    }
}
