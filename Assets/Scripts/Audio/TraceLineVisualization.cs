using NotReaper.Audio.Noise;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NotReaper.Audio
{
    public class TraceLineVisualization : AudioSyncer
    {
        [SerializeField] private TrailRenderer trail;
        [SerializeField] private Transform pointA;
        [SerializeField] private Transform pointB;
        [SerializeField] private Transform pointC;
        [SerializeField] private Transform pointD;
        [Space, Header("Trail Settings")]
        [SerializeField] private float moveSpeedRest;
        [SerializeField] private float moveSpeedBeat;
        [SerializeField] private float speedIncreaseTime;
        [SerializeField] private float speedDecreaseTime;

        private Transform currentPoint;
        private State state;
        private float currentMoveSpeed;

        protected override void Start()
        {
            base.Start();
            trail.transform.position = pointA.transform.position;
            currentPoint = pointB;
            currentMoveSpeed = moveSpeedRest;
            state = State.A;

            NRSettings.OnLoad(SetTrailColor);
        }
        private void SetTrailColor()
        {
            Gradient gradient = new Gradient();
            GradientColorKey[] colorKeys = new GradientColorKey[2];
            GradientAlphaKey[] alphaKeys = new GradientAlphaKey[3];
            colorKeys[0] = new GradientColorKey(NRSettings.config.leftColor, 0f);
            colorKeys[1] = new GradientColorKey(NRSettings.config.rightColor, 1f);
            alphaKeys[0] = new GradientAlphaKey(1f, 0f);
            alphaKeys[1] = new GradientAlphaKey(1f, .8f);
            alphaKeys[2] = new GradientAlphaKey(0f, 1f);
            gradient.SetKeys(colorKeys, alphaKeys);
            trail.colorGradient = gradient;
        }
        private IEnumerator Move()
        {
            isBeat = false;
            yield return null;
        }

        public override void OnBeat()
        {
            base.OnBeat();
            currentMoveSpeed = moveSpeedBeat;
            //currentMoveSpeed = moveSpeedBeat;
            isBeat = false;
            //StopCoroutine(Move());
            //StartCoroutine(Move());

        }

        private void UpdatePosition()
        {
            trail.transform.position = Vector3.MoveTowards(trail.transform.position, currentPoint.position, currentMoveSpeed * Time.deltaTime);
            if (trail.transform.position == currentPoint.position)
            {
                NextState();
            }
        }

        protected override void Visualize()
        {
            currentMoveSpeed -= speedDecreaseTime * Time.deltaTime;
            currentMoveSpeed = Mathf.Clamp(currentMoveSpeed, moveSpeedRest, moveSpeedBeat);
            UpdatePosition();
        }

        private void NextState()
        {
            state = (State)(((int)state + 1) % 4);
            NextPoint();
        }

        private void NextPoint()
        {
            currentPoint = state == State.A ? pointA : state == State.B ? pointB : state == State.C ? pointC : pointD;
        }

        private enum State
        {
            A = 0,
            B = 1,
            C = 2,
            D = 3
        }
    }
}

