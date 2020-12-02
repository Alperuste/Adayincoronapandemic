using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoronaGame.Audio
{

    [System.Serializable]
    public class Sound
    {
        [HideInInspector]

        public AudioSource source;

        public string name;

        public AudioClip clip;

        [Range(0f, 1f)]
        public float volume = 1f;

        [Range(-3, 03)]
        public float pitch = 1f;

        public bool loop;

    }

}