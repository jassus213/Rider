using UnityEngine;
using Zenject;

public class GameSceneStartInstaller : MonoInstaller
{
    [SerializeField] private MainMenuView _menuView;
    [SerializeField] private ShopMenuView _shopView;

    public override void InstallBindings()
    {
        GameSceneInstaller.Install(Container);
        
        Container.BindInterfacesAndSelfTo<MainMenuView>().FromInstance(_menuView);
        Container.BindInterfacesAndSelfTo<ShopMenuView>().FromInstance(_shopView);
    }
}