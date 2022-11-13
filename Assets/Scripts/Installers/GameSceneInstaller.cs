using UnityEngine;
using Zenject;

public class GameSceneInstaller : Installer<GameSceneInstaller>
{
    public override void InstallBindings()
    {
        Container.DeclareSignal<GameSignals.StartClick>().OptionalSubscriber();
        Container.DeclareSignal<GameSignals.ShopClick>().OptionalSubscriber();
        Container.DeclareSignal<GameSignals.BackToMenu>().OptionalSubscriber();
        Container.DeclareSignal<GameSignals.ChangeCar>().OptionalSubscriber();


        Container.BindInterfacesAndSelfTo<MainMenuPresenter>().AsSingle();
        Container.BindInterfacesAndSelfTo<ShopMenuPresenter>().AsSingle();

    }
}
