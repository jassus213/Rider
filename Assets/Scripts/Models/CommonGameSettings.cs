namespace Models
{
    public class CommonGameSettings
    {
        public float Volume => _volume;
        private float _volume;

        public bool IsFullScreen => _isFullScreen;
        private bool _isFullScreen;

        public CommonGameSettings()
        {
            _volume = 1f;
            _isFullScreen = true;
        }

        public void SetVolume(float volume)
        {
            _volume = volume;
        }

        public void SetFullScreen(bool value)
        {
            _isFullScreen = value;
        }
    }
}