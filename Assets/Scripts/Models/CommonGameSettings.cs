using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Models
{
    public class CommonGameSettings
    {
        public GameObject BodyCarModel => _bodyCarModel;
        private GameObject _bodyCarModel;

        private AudioSource _musicAudioSource;
        private AudioSource _effectsAudioSource;
        
        public CommonGameSettings()
        {
            _bodyCarModel = GameObject.FindGameObjectWithTag("FirstCar");
            _musicAudioSource = GameObject.FindGameObjectWithTag("MusicAudio").GetComponent<AudioSource>();
            _effectsAudioSource = GameObject.FindGameObjectWithTag("EffectsAudio").GetComponent<AudioSource>();

            _musicAudioSource.volume = 1f;
            _effectsAudioSource.volume = 0.3f;
            Screen.fullScreen = true;
        }

        public void SetMusicVolume(float volume)
        {
            _musicAudioSource.volume = volume;
        }

        public void SetEffectsVolume(float volume)
        {
            _effectsAudioSource.volume = volume;
        }
        public void SetScreenResolution(bool flag)
        {
            Screen.fullScreen = flag;
        }

        public void SetCarModel(GameObject carModel)
        {
            _bodyCarModel = carModel;
            Debug.Log(_bodyCarModel.tag);
        }
    }
}