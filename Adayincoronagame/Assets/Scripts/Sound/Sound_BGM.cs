using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace CoronaGame.Audio
{ 
    public class Sound_BGM : MonoBehaviour
    {

        public Sound BGM;

        // Start is called before the first frame update
        void Start()
        {
            PlayBGM();
            Debug.Log("bgm is playing");
        }

        public void PlayBGM()
        {
            SoundManager.instance.PlayBGM(BGM);
        }
    }
}
