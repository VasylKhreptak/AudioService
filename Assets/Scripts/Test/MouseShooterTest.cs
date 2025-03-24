using Plugins.AudioService.Core;
using Plugins.AudioService.Data;
using Sirenix.OdinInspector;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;
using AudioSettings = Plugins.AudioService.Data.AudioSettings;

namespace Test
{
    public class MouseShooterTest : MonoBehaviour
    {
        [Header("Preferences")]
        [SerializeField] private SoundConfig _soundConfig;

        [Space]
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
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out RaycastHit hit))
                {
                    _audioID = _audioService.Play(_soundConfig, hit.point);
                }
            }
        }

        #endregion

        [Button]
        private void Stop() => _audioService.Stop(_audioID);

        [Button]
        private void StopAll() => _audioService.StopAll();

        [Button]
        private void Pause() => _audioService.Pause(_audioID);

        [Button]
        private void PauseAll() => _audioService.PauseAll();

        [Button]
        private void Resume() => _audioService.Resume(_audioID);

        [Button]
        private void ResumeAll() => _audioService.ResumeAll();

        [Button]
        private void IsActive() => Debug.Log(_audioService.IsActive(_audioID));

        [Button]
        private void ActiveAudiosCount() => Debug.Log(_audioService.ActiveAudiosCount());

        [Button]
        private void ApplySettings() => _audioService.ApplySettings(_audioID, _settings);

        [Button]
        private void SetTime(float time) => _audioService.Properties.Time.TrySet(_audioID, time);
    }
}