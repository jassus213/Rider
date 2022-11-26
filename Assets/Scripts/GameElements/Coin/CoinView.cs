using UnityEngine;
using Zenject;

namespace GameElements.Coin
{
    public class CoinViewsFactory : PlaceholderFactory<ICoinView>
    {
    }

    public class CoinView : MonoBehaviour, ICoinView, IPoolable<IMemoryPool>
    {
        private ICoinPresenter _coinPresenter;

        public CoinView()
        {
            Debug.Log("Test const");
        }

        public Transform Transform => transform;

        #region pool

        private IMemoryPool _pool;

        public void OnSpawned(IMemoryPool pool)
        {
            _pool = pool;
        }

        public void OnDespawned()
        {
            _pool = null;
        }

        public void SetPresenter(ICoinPresenter coinPresenter)
        {
            _coinPresenter = coinPresenter;
        }

        public void Despawn()
        {
            if (this != null && gameObject != null)
            {
                _pool.Despawn(this);
                _coinPresenter.Despawn();
            }
        }

        #endregion
    }
}