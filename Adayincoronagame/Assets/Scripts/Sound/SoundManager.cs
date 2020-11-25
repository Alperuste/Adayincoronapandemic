using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

namespace CoronaGame.Audio
{ 
    public sealed class SoundManager : MonoBehaviour
    {
        public static SoundManager instance;

        private List<Sound> SFX = new List<Sound>();
        //public Sound BGM;

        private AudioSource BGMPlayer;

        private void Awake()
        {
            if (instance == null)
                instance = this;

            BGMPlayer = gameObject.AddComponent<AudioSource>();
        }


        public void PlayBGM(Sound s)
        {
            BGMPlayer.name = s.name;
            BGMPlayer.clip = s.clip;
            BGMPlayer.volume = s.volume;
            BGMPlayer.pitch = s.pitch;
            BGMPlayer.loop = s.loop;
            BGMPlayer.Play();
        
        }

        public void PlaySFX(Sound sfxClip)
        {
            SFX.Add(sfxClip);
            sfxClip.source = gameObject.AddComponent<AudioSource>();
            sfxClip.source.clip = sfxClip.clip;
            sfxClip.source.volume = sfxClip.volume;
            sfxClip.source.pitch = sfxClip.pitch;
            sfxClip.source.loop = sfxClip.loop;
            sfxClip.source.Play();
        }


        public void EndMusic(string name)
        {
            BGMPlayer.Stop();
        
        }

        public void EndSFX(string clipName)
        {
            if(SFX.Exists(x =>x.name == clipName))
            {
                Sound sfxClip = SFX.Find(x => x.name == clipName);
                sfxClip.source.Stop();
                Destroy(sfxClip.source);
            }
        }

    }
}

