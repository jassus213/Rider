using UnityEngine;

namespace GameElements.Coin
{
    public interface ICoinCreator
    {
        ICoinPresenter[] Create(float chunkLenght, Vector3[] coinPositions);
    }
}