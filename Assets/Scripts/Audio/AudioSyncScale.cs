using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace NotReaper.Audio
{
    public class AudioSyncScale : AudioSyncer
    {

        public Vector3 restScale;
        public Vector3 beatScale;

        public Image image;

        protected override void Start()
        {
            base.Start();
        }

        public void SetColor(Color color, float alpha)
        {
            color.a = alpha;
            image.color = color;
        }

        public override void OnBeat()
        {
            base.OnBeat();

            StopCoroutine(MoveToScale(beatScale));
            StartCoroutine(MoveToScale(beatScale));
           
        }

        protected override void Visualize()
        {
            if (isBeat) return;

            transform.localScale = Vector3.Lerp(transform.localScale, restScale, restSmoothTime * Time.deltaTime);
        }

        private IEnumerator MoveToScale(Vector3 target)
        {
            Vector3 current = transform.localScale;
            Vector3 initial = current;
            float timer = 0f;

            while(current != target)
            {
                current = Vector3.Lerp(initial, target, timer / timeToBeat);
                timer += Time.deltaTime;

                transform.localScale = current;
                yield return null;
            }

            isBeat = false;
        }
    }
}

