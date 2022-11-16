using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkGeneration : MonoBehaviour
{
     [SerializeField] private GameObject[] _worldChunks;

     private int chunkID;
     private int chunkLength = 45;

     public void SpawnChunk(GameObject PreviousChunk)
     {
         float PreviousChunkPosX = PreviousChunk.transform.position.x;
         float PreviousChunkPosY = PreviousChunk.transform.position.y;
         float PreviousChunkPosZ = PreviousChunk.transform.position.z;

         chunkID = Random.Range(0, _worldChunks.Length);

         Instantiate(_worldChunks[chunkID],
             new Vector3(PreviousChunkPosX + chunkLength, PreviousChunkPosY, PreviousChunkPosZ), Quaternion.identity);
     }

     
    

    
    
}
