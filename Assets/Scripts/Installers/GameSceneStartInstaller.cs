using UnityEngine;
using Zenject;

public class GameSceneStartInstaller : MonoInstaller
{
    [SerializeField] private MainMenuView _menuView;
    [SerializeField] private ShopMenuView _shopView;
    [SerializeField] private SettingsMenuView _settingsView;
    [SerializeField] private CarView _carView;
    [SerializeField] private WorldView _worldView;


    public override void InstallBindings()
    {
        GameSceneInstaller.Install(Container);
        
        Container.BindInterfacesAndSelfTo<MainMenuView>().FromInstance(_menuView);
        Container.BindInterfacesAndSelfTo<ShopMenuView>().FromInstance(_shopView);
        Container.BindInterfacesAndSelfTo<SettingsMenuView>().FromInstance(_settingsView);
        Container.BindInterfacesAndSelfTo<CarView>().FromInstance(_carView);
        Container.BindInterfacesAndSelfTo<WorldView>().FromInstance(_worldView);
    }
}