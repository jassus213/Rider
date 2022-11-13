using UnityEngine;
using Zenject;

public class GameSceneStartInstaller : MonoInstaller
{
    [SerializeField] private MainMenuView _menuView;

    public override void InstallBindings()
    {
        GameSceneInstaller.Install(Container);
        
        Container.BindInterfacesAndSelfTo<MainMenuView>().FromInstance(_menuView);
    }
}