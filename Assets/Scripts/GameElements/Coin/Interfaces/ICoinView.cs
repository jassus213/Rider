using UnityEngine;

namespace GameElements.Coin
{
    public interface ICoinView
    {
        Transform Transform { get; }

        void SetPresenter(ICoinPresenter coinPresenter);
        void Despawn();

    }
}