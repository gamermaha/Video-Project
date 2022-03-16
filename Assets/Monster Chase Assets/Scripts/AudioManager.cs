using System;
using UnityEngine;

namespace Monster_Chase_Assets.Scripts
{
    public class AudioManager : MonoBehaviour
    {
        public AudioSource jumpAudio;
        public AudioSource walkAudio;
        public AudioSource fireAudio;
        public AudioSource gameOver;
        public AudioSource buttonClick;
        
        public static AudioManager instance;
        public void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(this);
            }
            else
            {
                Destroy(this);
            }
        }
    }
}
