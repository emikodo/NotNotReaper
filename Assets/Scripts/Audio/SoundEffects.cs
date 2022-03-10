using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace NotReaper.Audio
{
    [RequireComponent(typeof(AudioSource))]
    public class SoundEffects : MonoBehaviour
    {

        public static SoundEffects Instance { get; private set; } = null;

        [Space, Header("Clips")]
        [SerializeField] private AudioClip click;
        [SerializeField] private AudioClip open;
        [SerializeField] private AudioClip close;
        [SerializeField] private AudioClip save;
        [SerializeField] private AudioClip notification;
        [SerializeField] private AudioClip startup;

        private AudioSource source;
        private bool isPreviewing;

        private void Awake()
        {

            if (Instance != null)
            {
                Debug.Log("SoundEffects already exists.");
                return;
            }
            source = GetComponent<AudioSource>();
            Instance = this;      
        }

        private void Start()
        {
            NRSettings.OnLoad(() => 
            {
                float vol = NRSettings.config.soundEffectsVol;
                SetVolume(vol);
            
            });
           
        }

        public void SetVolume(float volume)
        {
            source.volume = volume * .5f;
        }

        private IEnumerator DoPreviewVolume()
        {
            isPreviewing = true;
            source.clip = notification;

            source.PlayOneShot(notification);
            while (source.isPlaying)
            {
                yield return null;
            }
            isPreviewing = false;
        }

        public void PreviewVolume(float volume)
        {
            SetVolume(volume);
            if (!isPreviewing)
            {
                StartCoroutine(DoPreviewVolume());
            }
        }

        public void PlaySound(Sound type)
        {
            AudioClip clip = null;
            switch (type)
            {
                case Sound.Click:
                    clip = click;
                    break;
                case Sound.Open:
                    clip = open;
                    break;
                case Sound.Close:
                    clip = close;
                    break;
                case Sound.Save:
                    clip = save;
                    break;
                case Sound.Notification:
                    clip = notification;
                    break;
                case Sound.Startup:
                    clip = startup;
                    break;
                default:
                    break;
            }
            source.PlayOneShot(clip);
        }

        private void OnApplicationFocus(bool focus)
        {
            if (NRSettings.config == null) return;
            if (focus)
            {
                SetVolume(NRSettings.config.soundEffectsVol);
            }
            else
            {
                SetVolume(0f);
            }
        }

        public enum Sound
        {
            Click,
            Open,
            Close,
            Save,
            Notification,
            Startup,
        }
    }
}

