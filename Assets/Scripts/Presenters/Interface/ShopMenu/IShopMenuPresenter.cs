using UnityEngine;
using UnityEngine.UI;

public interface IShopMenuPresenter
{
    public void OnBackButtonClick();

    public void GetCarChoose(GameObject car);

    public GameObject GetCarModels();
}