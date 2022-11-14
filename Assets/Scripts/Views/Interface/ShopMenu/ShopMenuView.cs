using System;
using System.Collections.Generic;
using Models;
using UnityEngine;
using UnityEngine.UI;

public class ShopMenuView : MonoBehaviour, IShopMenuView
{
    [SerializeField] private Button _backButton;
    [SerializeField] private Button _firstCarButton;
    [SerializeField] private Button _secondCarButton;

    [SerializeField] private List<GameObject> _cars;
    [SerializeField] private List<Button> _buttons;

    public Dictionary<Button, GameObject> CarsDictionary => _carsDictionary;
    private Dictionary<Button, GameObject> _carsDictionary;

    private void Awake()
    {
        _carsDictionary = new Dictionary<Button, GameObject>();
        
        for (int i = 0; i < _cars.Count; i++)
        {
            _carsDictionary.Add(_buttons[i], _cars[i]);
        }

        
    }

    private CommonGameSettings _commonGameSettings;

    private IShopMenuPresenter _presenter;


    public void SetPresenter(IShopMenuPresenter presenter)
    {
        _presenter = presenter;

        Debug.Log("Presenter");


        _backButton.onClick.AddListener(_presenter.OnBackButtonClick);
        _firstCarButton.onClick.AddListener(() => GetCarModel(_firstCarButton));
        _secondCarButton.onClick.AddListener(() => GetCarModel(_secondCarButton));
    }


    public void Show(bool show)
    {
        gameObject.SetActive(show);
    }

    private void GetCarModel(Button button)
    {
        _carsDictionary.TryGetValue(button, out GameObject car);
        _presenter.GetCarChoose(car);
    }
}