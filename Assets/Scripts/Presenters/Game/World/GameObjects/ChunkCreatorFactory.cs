using System;
using System.Collections.Generic;
using GameElements.Coin;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

public class ChunkCreatorFactory : MonoBehaviour
{
    [SerializeField] private GameObject[] _chunks;

    [Inject] private ICoinCreator _coinCreator;

    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log(true);
        if(other.CompareTag("Chunk"))
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
        var worldPeace = Instantiate(newChunk, newChankPos, Quaternion.identity);
        var chunkLenght = this.gameObject.transform.localScale.x;
        _coinCreator.Create(chunkLenght, CoinsPos(worldPeace));
    }
    private Vector3[] CoinsPos(GameObject chunk)
    {
        var childCount = chunk.transform.Find("CoinsPositions").childCount;
        var result = new List<Vector3>(childCount);
        for (int i = 0; i < childCount; i++)
        {
            var pos = chunk.transform.Find("CoinsPositions").GetChild(i);
            result.Add(pos.transform.position);
        }

        return result.ToArray();
    }

    private int GetRandomChunk()
    {
        return Random.Range(0, _chunks.Length);
    }
}