using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Models
{
    public class CommonGameSettings
    {
        public float Volume => _volume;
        private float _volume;

        public bool IsFullScreen => _isFullScreen;
        private bool _isFullScreen;

        public GameObject BodyCarModel => _bodyCarModel;
        private GameObject _bodyCarModel;
        
        public CommonGameSettings()
        {
            _volume = 1f;
            _isFullScreen = true;
            _bodyCarModel = null;
        }

        public void SetVolume(float volume)
        {
            _volume = volume;
        }

        public void SetCarModel(GameObject carModel)
        {
            _bodyCarModel = carModel;
            Debug.Log(carModel.tag);
        }

        public void SetFullScreen(bool value)
        {
            _isFullScreen = value;
        }
    }
}