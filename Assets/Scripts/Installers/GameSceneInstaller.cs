using Zenject;

public class GameSceneInstaller : Installer<GameSceneInstaller>
{
    public override void InstallBindings()
    {
        Container.DeclareSignal<GameSignals.StartClick>().OptionalSubscriber();

        Container.BindInterfacesAndSelfTo<MainMenuPresenter>().AsSingle();
    }
}
