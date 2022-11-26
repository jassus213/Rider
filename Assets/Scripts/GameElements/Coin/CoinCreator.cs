using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GameElements.Coin
{
    public class CoinCreator: ICoinCreator
    {
        private readonly CoinPresentersFactory _coinPresentersFactory;
        private readonly CoinViewsFactory _coinViewsFactory;

        public CoinCreator(CoinViewsFactory coinViewsFactory,
            CoinPresentersFactory coinPresentersFactory)
        {
            _coinViewsFactory = coinViewsFactory;
            _coinPresentersFactory = coinPresentersFactory;

        }

        public ICoinPresenter[] Create(float chunkLenght, Vector3[] coinPositions)
        {
            var result = new List<ICoinPresenter>();
            var positions = GetCoinsPositions(coinPositions);
            foreach (var pos in positions)
            {
                var presenter = InternalCreate(pos);
                result.Add(presenter);
            }

            return result.ToArray();

        }
        
        private ICoinPresenter InternalCreate(Vector3 coinPosition)
        {
            var coinView = _coinViewsFactory.Create();
            
            coinView.Transform.position = coinPosition;

            var presenter = _coinPresentersFactory.Create();
            presenter.SetView(coinView);
            coinView.SetPresenter(presenter);

            return presenter;

        }
        
        private Vector3[] GetCoinsPositions(Vector3[] coinsPositions)
        {
            Dictionary<int, Vector3> result = new Dictionary<int, Vector3>();
            var coinsCount = Random.Range(1, coinsPositions.Length + 1);
            while (result.Count < coinsCount)
            {
                var id = Random.Range(0, coinsCount);

                if (!result.ContainsKey(id))
                {
                    result.Add(id, coinsPositions[id]);
                }
            }

            return result.Values.ToArray();
        }
    }
}