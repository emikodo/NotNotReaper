using NotReaper.Timing;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NotReaper.Audio
{
    public class AudioVisualizer : MonoBehaviour
    {

        public static float SpectrumValue { get; private set; }

        public delegate void OnVisualizationStart();
        public static event OnVisualizationStart onVisualizationStart;

        public delegate void OnVisualizationEnd();
        public static event OnVisualizationEnd onVisualizationEnd;

        private float[] spectrum;

        public float multiplicator = 1000f;

        public float normalizer = 1000f;

        private AudioSource source;

        private void Start()
        {
            spectrum = new float[128];
            source = NRDependencyInjector.Get<PrecisePlayback>().GetSource();
          
        }

        public void StartVisualization()
        {
            StartCoroutine(UpdateSpectrum());
            onVisualizationStart?.Invoke();
        }

        public void StopVisualization()
        {
            onVisualizationEnd?.Invoke();
            StopAllCoroutines();
        }

        private IEnumerator UpdateSpectrum()
        {
            while (true)
            {
                AudioListener.GetSpectrumData(spectrum, 0, FFTWindow.Hamming);
                if (spectrum != null && spectrum.Length > 0)
                {
                    SpectrumValue = spectrum[0] * multiplicator;
                }
                yield return null;
            }
            
        }
    }
}

