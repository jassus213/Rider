public class GameStatus
{
    public bool IsGameStarted => _isGameStarted;
    private bool _isGameStarted = false;

    public void SetGameStartStatus(bool status)
    {
        _isGameStarted = status;
    }
}