using System;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class ChunkCreatorFactory : MonoBehaviour
{
    [SerializeField] private GameObject[] _chunks;

    [SerializeField] private CoinsFactory _coinsFactory;

    private void OnTriggerStay(Collider other)
    {
        Debug.Log(other.tag);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Chunk"))
            CreateChunk(other.gameObject);
    }

    private void CreateChunk(GameObject other)
    {
        float lastChunkPosX = other.transform.position.x;
        float lastChunkPosY = other.transform.position.y;
        float lastChunkPosZ = other.transform.position.z;
        float chunkLength = other.gameObject.transform.Find("Ground").localScale.x;
        Vector3 newChankPos = new Vector3(lastChunkPosX + chunkLength, lastChunkPosY, lastChunkPosZ);

        var id = GetRandomChunk();
        var newChunk = _chunks[id];
        Instantiate(newChunk, newChankPos, Quaternion.identity);
        _coinsFactory.CoinsCreator(newChunk, lastChunkPosX);
    }

    private int GetRandomChunk()
    {
        return Random.Range(0, _chunks.Length);
    }
}