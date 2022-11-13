using UnityEngine;

public class ShopMenuView : MonoBehaviour
{
    private IMainMenuPresenter _presenter;


    public void SetPresenter(IMainMenuPresenter presenter)
    {
        _presenter = presenter;
        
    }
}
