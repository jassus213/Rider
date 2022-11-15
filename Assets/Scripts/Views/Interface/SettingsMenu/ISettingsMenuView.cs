public interface ISettingsMenuView
{
    void SetPresenter(ISettingsMenuPresenter presenter);

    void Show(bool show);

}