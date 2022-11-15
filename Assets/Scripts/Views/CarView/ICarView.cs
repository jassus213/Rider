using UnityEngine;

public interface ICarView
{
    void SetPresenter(ICarPresenter presenter);
    
    void Show(bool show);

    void ChangeModel(GameObject carModel, GameObject wheelsModel = null);

    GameObject GetCar();
}