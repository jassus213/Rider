using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

public class GameSceneStartInstaller : MonoInstaller
{
    [SerializeField] private MainMenuView _menuView;
    [SerializeField] private ShopMenuView _shopView;


    [SerializeField] private SettingsMenuView _settingsView;
    [SerializeField] private CarView _carView;
    [SerializeField] private ChunkDestroyerView _chunkDestroyerView;
    [SerializeField] private ChunkCreatorFactory _chunkCreatorFactory;
    [SerializeField] private CoinsFactory _coinsFactory;


    public override void InstallBindings()
    {
        GameSceneInstaller.Install(Container);

        Container.BindInterfacesAndSelfTo<MainMenuView>().FromInstance(_menuView);
        Container.BindInterfacesAndSelfTo<ShopMenuView>().FromInstance(_shopView);
        Container.BindInterfacesAndSelfTo<SettingsMenuView>().FromInstance(_settingsView);
        Container.BindInterfacesAndSelfTo<CarView>().FromInstance(_carView);
        Container.BindInterfacesAndSelfTo<ChunkDestroyerView>().FromInstance(_chunkDestroyerView);
        Container.BindInterfacesAndSelfTo<ChunkCreatorFactory>().FromInstance(_chunkCreatorFactory);
        Container.BindInterfacesAndSelfTo<CoinsFactory>().FromInstance(_coinsFactory);
    }
}