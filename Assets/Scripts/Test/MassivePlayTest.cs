using System;
using Plugins.AudioService.Core;
using Sirenix.OdinInspector;
using UniRx;
using UnityEngine;
using Zenject;
using AudioSettings = Plugins.AudioService.Data.AudioSettings;

namespace Test
{
    public class MassivePlayTest : MonoBehaviour
    {
        [Header("Preferences")]
        [SerializeField] private AudioClip _clip;
        [SerializeField] private AudioSettings _settings;
        [SerializeField] private float _interval = 0.05f;

        private IAudioService _audioService;

        [Inject]
        private void Constructor(IAudioService audioService)
        {
            _audioService = audioService;
        }

        private IDisposable _subscription;

        [Button]
        private void StartPlaying()
        {
            StopPlaying();

            _subscription = Observable
                .Interval(TimeSpan.FromSeconds(_interval))
                .DoOnSubscribe(Play)
                .Subscribe(_ => Play());
        }

        [Button]
        private void StopPlaying() => _subscription?.Dispose();

        private void Play() => _audioService.Play(_clip, _settings);
    }
}