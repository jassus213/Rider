using Zenject;

namespace GameElements.Coin
{
    
    public class CoinPresentersFactory : PlaceholderFactory<ICoinPresenter> { }
    
    public class CoinPresenter : ICoinPresenter, IPoolable<IMemoryPool>
    {
        private ICoinView _coinView;
        
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

        public void Despawn()
        {
            if (_pool != null)
            {
                _pool.Despawn(this);
            }
        }
        
        #endregion

        public void SetView(ICoinView coinView)
        {
            _coinView = coinView;
        }
    }
}