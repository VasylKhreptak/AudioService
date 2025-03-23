﻿using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Plugins.AudioService.Data
{
    [CreateAssetMenu(fileName = "SoundConfig", menuName = "Configs/SoundConfig")]
    public class SoundConfig : SerializedScriptableObject
    {
        [SerializeField] private List<AudioClip> _clips;
        [SerializeField] private AudioSettings _settings;
        [SerializeField, Range(0, 3)] private float _pitchShift = 0f;

        public IReadOnlyList<AudioClip> Clips => _clips;
        public AudioSettings Settings => _settings;
        public float PitchShift => _pitchShift;
        public AudioClip RandomClip => _clips[Random.Range(0, _clips.Count)];
    }
}