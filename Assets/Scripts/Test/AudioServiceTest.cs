using Plugins.AudioService.Core;
using Plugins.Timer;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;
using AudioSettings = Plugins.AudioService.Data.AudioSettings;

namespace Test
{
    public class AudioServiceTest : MonoBehaviour
    {
        [Header("Preferences")]
        [SerializeField] private AudioClip _clip;
        [SerializeField] private AudioSettings _settings;

        private IAudioService _audioService;

        [Inject]
        private void Constructor(IAudioService audioService)
        {
            _audioService = audioService;
        }

        private int _audioID;

        #region MonoBehaviour

        // private void Awake()
        // {
        //     AudioSource audioSource;
        //     
        //     audioSource.
        // }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                _audioService.Properties.Time.TrySet(_audioID, 0);
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                _audioID = _audioService.Play(_clip, _settings);
                Debug.Log("Play");
            }

            if (_audioService.Properties.Timer.TryGet(_audioID, out IReadonlyTimer timer))
                Debug.Log($"Time: {timer.Time.TotalSeconds.Value}");
        }

        #endregion

        [Button] private void AddSecond() => AddTime(1);
        [Button] private void RemoveSecond() => AddTime(-1);
        [Button] private void SetSecond() => SetTime(1);
        [Button] private void Stop() => _audioService.Stop(_audioID);
        [Button] private void StopAll() => _audioService.StopAll();
        [Button] private void StopNotLooped() => _audioService.StopAll(audio => audio.Loop == false);
        [Button] private void Pause() => _audioService.Pause(_audioID);
        [Button] private void PauseAll() => _audioService.PauseAll();
        [Button] private void PauseNotLooped() => _audioService.PauseAll(audio => audio.Loop == false);
        [Button] private void Resume() => _audioService.Resume(_audioID);
        [Button] private void ResumeAll() => _audioService.ResumeAll();
        [Button] private void ResumeNotLooped() => _audioService.ResumeAll(audio => audio.Loop == false);
        [Button] private void IsActive() => Debug.Log(_audioService.IsActive(_audioID));
        [Button] private void ActiveAudiosCount() => Debug.Log(_audioService.ActiveAudiosCount());
        [Button] private void ActiveLoopedAudiosCount() => Debug.Log(_audioService.ActiveAudiosCount(audio => audio.Loop));
        [Button] private void ApplySettings() => _audioService.ApplySettings(_audioID, _settings);

        private void SetTime(float time) => _audioService.Properties.Time.TrySet(_audioID, time);

        private void AddTime(float time)
        {
            if (_audioService.Properties.Time.TryGet(_audioID, out float currentTime))
                _audioService.Properties.Time.TrySet(_audioID, currentTime + time);
        }
    }
}