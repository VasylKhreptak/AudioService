using Plugins.AudioService.Core;
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

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _audioID = _audioService.Play(_clip, _settings);
            }
        }

        #endregion

        [Button] private void Stop() => _audioService.Stop(_audioID);
        [Button] void StopAll() => _audioService.StopAll();
        [Button] void StopNotLooped() => _audioService.Stop(audio => audio.Loop == false);
        [Button] void Pause() => _audioService.Pause(_audioID);
        [Button] void PauseAll() => _audioService.PauseAll();
        [Button] void PauseNotLooped() => _audioService.Pause(audio => audio.Loop == false);
        [Button] void Resume() => _audioService.Resume(_audioID);
        [Button] void ResumeAll() => _audioService.ResumeAll();
        [Button] void ResumeNotLooped() => _audioService.Resume(audio => audio.Loop == false);
        [Button] void IsActive() => Debug.Log(_audioService.IsActive(_audioID));
        [Button] void ActiveAudiosCount() => Debug.Log(_audioService.ActiveAudiosCount());
        [Button] void ActiveLoopedAudiosCount() => Debug.Log(_audioService.ActiveAudiosCount(audio => audio.Loop));
        [Button] void ApplySettings() => _audioService.ApplySettings(_audioID, _settings);
    }
}