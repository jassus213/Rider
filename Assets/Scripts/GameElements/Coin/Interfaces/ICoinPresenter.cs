namespace GameElements.Coin
{
    public interface ICoinPresenter
    {
        void SetView(ICoinView coinView);
        void Despawn();
    }
}