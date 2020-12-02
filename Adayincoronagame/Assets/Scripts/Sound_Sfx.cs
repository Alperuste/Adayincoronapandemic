using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace CoronaGame.Audio
{
    public class Sound_Sfx : MonoBehaviour
    {
        public Sound SFX;

        private void Start()
        {

        }

        public void PlaySFX()
        {
            SoundManager.instance.PlaySFX(SFX);
        }
    }
}