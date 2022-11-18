using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CoinsFactory : MonoBehaviour, IChunkDestroyerPresenter
{
    [SerializeField] private GameObject _coin;
    private List<Vector3> _coinsPositions = new List<Vector3>();
    [SerializeField] private List<Transform> _coinsVariablesPositions;


    public void CoinsCreator(GameObject chunk, float lastChunkPos)
    {
        CoinsPos(chunk);
        var coinsCount = GetCountOfCoins();
        GetCoinsPositions(coinsCount);
        Debug.Log(coinsCount);
        foreach (var coinPos in _coinsPositions)
        {
            float chunkLength = chunk.gameObject.transform.Find("Ground").localScale.x;
            var newCoinPosX = coinPos.x + lastChunkPos + chunkLength;
            var coinPosition = new Vector3(newCoinPosX, coinPos.y, coinPos.z);
            Instantiate(_coin, coinPosition, Quaternion.identity);
        }

        _coinsPositions.Clear();
    }

    private int GetCountOfCoins()
    {
        return Random.Range(2, _coinsVariablesPositions.Count + 1);
    }

    private void GetCoinsPositions(int coinsCount)
    {
        for (int i = 0; i < coinsCount; i++)
        {
            var id = Random.Range(0, coinsCount);

            if (!_coinsPositions.Contains(_coinsVariablesPositions[id].transform.position))
            {
                _coinsPositions.Add(_coinsVariablesPositions[id].transform.position);
            }
        }
    }

    private void CoinsPos(GameObject chunk)
    {
        if(_coinsVariablesPositions.Count > 0)
            _coinsVariablesPositions.Clear();
        
        var childCount = chunk.transform.Find("CoinsPositions").childCount;
        for (int i = 0; i < childCount; i++)
        {
            var pos = chunk.transform.Find("CoinsPositions").GetChild(i);
            _coinsVariablesPositions.Add(pos);
        }
    }
}