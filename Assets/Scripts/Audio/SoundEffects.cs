using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace NotReaper.Audio
{
    public class SoundEffects : MonoBehaviour
    {

        public static SoundEffects Instance { get; private set; } = null;

        private List<AudioSource> sourcePool;
        private List<AudioSource> activeSources;
        [Header("References")]
        [SerializeField] private Slider volumeSlider;
        [Space, Header("Settings")]
        [SerializeField] private int maxSimultaneousSounds = 5;
        [Space, Header("Clips")]
        [SerializeField] private AudioClip click;
        [SerializeField] private AudioClip open;
        [SerializeField] private AudioClip close;
        [SerializeField] private AudioClip save;
        [SerializeField] private AudioClip notification;

        private bool isPreviewing;

        private void Awake()
        {

            if (Instance != null)
            {
                Debug.Log("SoundEffects already exists.");
                return;
            }

            Instance = this;
            sourcePool = new();
            activeSources = new();
            for(int i = 0; i < maxSimultaneousSounds; i++)
            {
                sourcePool.Add(gameObject.AddComponent<AudioSource>());
            }        
        }

        private void Start()
        {
            NRSettings.OnLoad(() => 
            {
                float vol = NRSettings.config.soundEffectsVol;
                SetVolume(vol);
            
            });
           
        }

        private void SetVolume(float volume)
        {
            foreach (var source in sourcePool)
            {
                source.volume = volume * .5f;
                volumeSlider.SetValueWithoutNotify(volume);
                
            }
            foreach (var source in activeSources)
            {
                source.volume = volume * .5f;
                volumeSlider.SetValueWithoutNotify(volume);
            }
        }

        private IEnumerator PreviewVolume()
        {
            isPreviewing = true;
            var source = sourcePool[0];
            activeSources.Add(source);
            sourcePool.Remove(source);
            source.clip = notification;

            source.Play();
            while (source.isPlaying)
            {
                yield return null;
            }
            activeSources.Remove(source);
            sourcePool.Add(source);
            isPreviewing = false;
        }

        public void OnVolumeChanged()
        {
            float vol = volumeSlider.value;
            NRSettings.config.soundEffectsVol = vol;
            SetVolume(vol);

            if (!isPreviewing)
            {
                StartCoroutine(PreviewVolume());
            }
        }

        public void PlaySound(Sound type)
        {
            if (sourcePool.Count == 0) return;

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
                default:
                    break;
            }

            var source = sourcePool[0];
            activeSources.Add(source);
            sourcePool.Remove(source);
            source.clip = clip;
            StartCoroutine(PlayClip(source));
        }

        private IEnumerator PlayClip(AudioSource source)
        {
            source.Play();

            while (source.isPlaying)
            {
                yield return null;
            }
            activeSources.Remove(source);
            sourcePool.Add(source);
        }

        private void OnApplicationFocus(bool focus)
        {
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
        }
    }
}

