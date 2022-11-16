using UnityEngine;
using Zenject;

public class ChunkDestroyPresenter : IChunkDestroyerPresenter, IInitializable
{
    private readonly IChunkDestoryerView _chunkDestoryerView;

    public ChunkDestroyPresenter(IChunkDestoryerView chunkDestroyerPresenter)
    {
        _chunkDestoryerView = chunkDestroyerPresenter;
    }

    public void Initialize()
    {
        _chunkDestoryerView.SetPresenter(this);
    }
}



