using NotReaper.Timing;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace NotReaper.Modifier
{
    public class ModifierPreviewer : MonoBehaviour
    {
        public static ModifierPreviewer Instance = null;
        public SpriteRenderer lightRend;
        public SpriteRenderer psyRend;
        public RawImage backgroundImage;
        private Color lightColor;
        private List<Modifier> modifiers = new List<Modifier>();
        [HideInInspector]
        public bool isPlaying = false;
        private float currentBrightness = 0f;
        private float currentPsySpeed = 0f;
        public TextMeshProUGUI textPopup;
        private void Start()
        {
            if (Instance is null) Instance = this;
            else
            {
                Debug.LogWarning("Trying to create second ModifierPreviewer instance.");
                return;
            }
            lightColor = lightRend.color;
            SetBrightness(1f);
        }

        public void UpdateModifierList(List<Modifier> list, float currentTime)
        {
            if (list is null || list.Count == 0) return;
            modifiers = list.ToList();
            modifiers.Sort((s1, s2) => s1.startTime.tick.CompareTo(s2.startTime.tick));
            for(int i = modifiers.Count - 1; i >= 0; i--)
            {
                if (modifiers[i].startTime.tick < currentTime) modifiers.RemoveAt(i);
                //else if (modifiers[i].modifierType != ModifierHandler.ModifierType.ArenaBrightness && modifiers[i].modifierType != ModifierHandler.ModifierType.Fader && modifiers[i].modifierType != ModifierHandler.ModifierType.Psychedelia && modifiers[i].modifierType != ModifierHandler.ModifierType.PsychedeliaUpdate) modifiers.RemoveAt(i);
            }
            isPlaying = true;
        }

        public void Stop()
        {
            StopAllCoroutines();
            isPlaying = false;
            SetBrightness(1f);
            StopPsy();
            ResetRotation();
            ResetPopup();
        }

        private void StopPsy()
        {
            psyRend.gameObject.SetActive(false);
        }

        private void HandlePsy(Modifier modifier)
        {
            if(modifier.modifierType == ModifierHandler.ModifierType.Psychedelia)
            {
                StartCoroutine(DoPsychedelia(modifier));
            }
            else
            {
                currentPsySpeed = modifier.amount;
            }
        }

        private IEnumerator DoPsychedelia(Modifier modifier)
        {
            psyRend.gameObject.SetActive(true);
            currentPsySpeed = modifier.amount;
            while (modifier.endTime > Timeline.time && modifier.startTime <= Timeline.time)
            {
                float h, s, v;
                Color.RGBToHSV(psyRend.color, out h, out s, out v);
                Color c = Color.HSVToRGB(h + 0.01f * currentPsySpeed / 1000f, s, v);
                c.a = .1f;
                psyRend.color = c;
                yield return new WaitForSecondsRealtime(Time.unscaledDeltaTime);
            }
            StopPsy();
        }

        private void Update()
        {
            if (!isPlaying) return;
            if (modifiers is null || modifiers.Count == 0) return;
            if (modifiers[0].startTime <= Timeline.time)
            {
                Modifier m = modifiers[0];
                switch (m.modifierType)
                {
                    case ModifierHandler.ModifierType.ArenaBrightness:
                    case ModifierHandler.ModifierType.Fader:
                        HandleLightingEvent(m);
                        break;
                    case ModifierHandler.ModifierType.Psychedelia:
                    case ModifierHandler.ModifierType.PsychedeliaUpdate:
                        HandlePsy(m);
                        break;
                    case ModifierHandler.ModifierType.ArenaRotation:
                        HandleRotation(m);
                        break;
                    case ModifierHandler.ModifierType.TextPopup:
                        StartCoroutine(HandlePopup(m));
                        break;
                    default:
                        break;
                }                
                modifiers.RemoveAt(0);
            }
        }

        private IEnumerator HandlePopup(Modifier modifier)
        {
            float x, y;
            float.TryParse(modifier.xoffset, out x);
            float.TryParse(modifier.yoffset, out y);
            x /= 10f;
            y /= 10f;
            textPopup.transform.position = new Vector2(x, y);
            textPopup.text = modifier.value1;
            textPopup.fontSize = float.Parse(modifier.value2);
            while (modifier.endTime > Timeline.time && modifier.startTime <= Timeline.time)
            {
                yield return new WaitForSecondsRealtime(Time.unscaledDeltaTime);
            }
            ResetPopup();
        }

        private void ResetPopup()
        {
            textPopup.transform.position = Vector2.zero;
            textPopup.text = "";
            textPopup.fontSize = 12;
        }

        private void HandleRotation(Modifier modifier)
        {
            if (modifier.option1) //continuous
            {
                StartCoroutine(DoRotationContinuous(modifier));
            }
            else if (modifier.option2) //incremental
            {
                StartCoroutine(DoRotationIncremental(modifier));
            }
            else //default
            {
                Rotate(modifier.amount);
            }
        }

        private IEnumerator DoRotationContinuous(Modifier modifier)
        {
            while (modifier.endTime > Timeline.time && modifier.startTime <= Timeline.time)
            {
                Rotate(modifier.amount / 10f);
                yield return new WaitForSecondsRealtime(Time.unscaledDeltaTime);
            }
        }

        private IEnumerator DoRotationIncremental(Modifier modifier)
        {
            float startTick = modifier.startTime.tick;
            while (modifier.endTime > Timeline.time && modifier.startTime <= Timeline.time)
            {
                float percentage = ((Timeline.time.tick - modifier.startTime.tick) * 100f) / (modifier.endTime.tick - modifier.startTime.tick);
                float currentRot = Mathf.Lerp(0f, modifier.amount, percentage / 100f);
                Rotate(currentRot / 10f);
                yield return new WaitForSecondsRealtime(Time.unscaledDeltaTime);
            }
        }

        private void Rotate(float amount)
        {
            amount /= 1000f;
            Rect original = backgroundImage.uvRect;
            Vector2 offset = original.position;
            offset.x += amount;
            backgroundImage.uvRect = new Rect(offset, original.size);
        }

        private void ResetRotation()
        {
            Rect original = backgroundImage.uvRect;
            Vector2 offset = Vector2.zero;
            backgroundImage.uvRect = new Rect(offset, original.size);
        }

        private void HandleLightingEvent(Modifier modifier)
        {
            if(modifier.modifierType == ModifierHandler.ModifierType.ArenaBrightness)
            {
                if (modifier.option1)
                {
                    StartCoroutine(DoContinuousBrightness(modifier));
                }
                else if (modifier.option2)
                {
                    StartCoroutine(DoStrobe(modifier));
                }
                else
                {
                    SetBrightness(modifier.amount / 100f);
                }
                
            }
            else
            {
                StartCoroutine(HandleFader(modifier));
            }
        }

        private IEnumerator DoContinuousBrightness(Modifier modifier)
        {
            float dir = 1;
            float newAmount = 0.01f;
            newAmount *= modifier.amount;
            while (modifier.endTime > Timeline.time && modifier.startTime <= Timeline.time)
            {
                if (currentBrightness >= 1f) dir = -1;
                else if (currentBrightness <= 0f) dir = 1;
                SetBrightnessIncremental(newAmount * dir);
                yield return new WaitForSecondsRealtime(Time.unscaledDeltaTime);
            }
        }

        private IEnumerator DoStrobe(Modifier modifier)
        {
            float dir = 1;
            if (1f / currentBrightness >= .5f) dir = 0;
            float interval = 480f / modifier.amount;
            float nextStrobe = modifier.startTime.tick;
            while (modifier.endTime > Timeline.time && modifier.startTime <= Timeline.time)
            {
                if(nextStrobe <= Timeline.time.tick)
                {
                    float amnt = 1f * dir;
                    SetBrightness(amnt);
                    if (dir == 1) dir = 0;
                    else if (dir == 0) dir = 1;
                    nextStrobe += interval;
                }
                yield return new WaitForSecondsRealtime(Time.unscaledDeltaTime);
            }
        }

        private void SetBrightnessIncremental(float brightness)
        {
            currentBrightness += brightness;
            brightness = .15f + (brightness * .7f);
            lightRend.color = new Color(lightColor.r, lightColor.g, lightColor.b, 1f - brightness);
        }

        private void SetBrightness(float brightness)
        {
            currentBrightness = brightness;
            brightness = .15f + (brightness * .7f);
            lightRend.color = new Color(lightColor.r, lightColor.g, lightColor.b, 1f - brightness);
        }

        private IEnumerator HandleFader(Modifier modifier)
        {
            float startBrightness = currentBrightness;
            while (modifier.endTime.tick > Timeline.time.tick && modifier.startTime.tick <= Timeline.time.tick)
            {
                
                float percentage = ((Timeline.time.tick - modifier.startTime.tick) * 100f) / (modifier.endTime.tick - modifier.startTime.tick);
                float currentExp = Mathf.Lerp(startBrightness, modifier.amount / 100f, percentage / 100f);
                SetBrightness(currentExp);
                yield return new WaitForSecondsRealtime(Time.unscaledDeltaTime);
            }
        }
    }
}

