using UnityEngine;
using Random = UnityEngine.Random;

public class ChunkCreatorView : MonoBehaviour, IChunkCreatorView
{
    [SerializeField] private GameObject[] _chunks;
    
    private IChunkCreatorPresenter _chunkCreatorPresenter;

    private int _chunkLength = 45;
    

    public void SetPresenter(IChunkCreatorPresenter presenter)
    {
        _chunkCreatorPresenter = presenter;
    }

    public GameObject[] GetChunkTypes()
    {
        return _chunks;
    }


    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Chunk"))
        CreateChunk(other.gameObject);
    }

    private void CreateChunk(GameObject other)
    {
        float lastChunkPosX = other.transform.position.x;
        float lastChunkPosY = other.transform.position.y;
        float lastChunkPosZ = other.transform.position.z;
        Vector3 newChankPos = new Vector3(lastChunkPosX + _chunkLength, lastChunkPosY, lastChunkPosZ);

        var id = GetRandomChunk();
        Instantiate(_chunks[id], newChankPos, Quaternion.identity);
    }

    private int GetRandomChunk()
    {
        return Random.Range(0, _chunks.Length);
    }
}
