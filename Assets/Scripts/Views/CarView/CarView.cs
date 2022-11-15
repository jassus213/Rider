using System;
using UnityEngine;

public class CarView : MonoBehaviour, ICarView
{
    [SerializeField] private GameObject _carModel;
    [SerializeField] private GameObject[] _wheelModel;
    
    private ICarPresenter _carPresenter;

    public void SetPresenter(ICarPresenter presenter)
    {
        _carPresenter = presenter;
    }

    public void Show(bool show)
    {
        this.gameObject.SetActive(show);
    }

    public void ChangeModel(GameObject carModel, GameObject wheelsModel = null)
    {
        _carModel.GetComponent<SpriteRenderer>().sprite = carModel.GetComponent<SpriteRenderer>().sprite;

        if (wheelsModel == null)
            return;
        foreach (var wheel in _wheelModel)
        {
            wheel.GetComponent<SpriteRenderer>().sprite = wheelsModel.GetComponent<SpriteRenderer>().sprite;
        }
    }

    public GameObject GetCar()
    {
        return _carModel;
    }
}