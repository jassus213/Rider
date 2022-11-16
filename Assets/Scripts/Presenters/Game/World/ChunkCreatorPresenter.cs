using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

public class ChunkCreatorPresenter : IChunkCreatorPresenter, IInitializable
{
    private readonly SignalBus _signalBus;
    private readonly IChunkCreatorView _chunkCreatorView;
    

    public ChunkCreatorPresenter(SignalBus signalBus, IChunkCreatorView chunkCreatorView)
    {
        _signalBus = signalBus;
        _chunkCreatorView = chunkCreatorView;
    }

    public void Initialize()
    {
        _chunkCreatorView.SetPresenter(this);
    }
}

    