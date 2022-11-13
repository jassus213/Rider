using UnityEngine;
using UnityEngine.UI;

public interface IShopMenuView
{
    void SetPresenter(IShopMenuPresenter presenter);

    void Show(bool show);

    GameObject GetCarModel(Button button);

}
