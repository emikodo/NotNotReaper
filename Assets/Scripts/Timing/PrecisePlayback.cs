using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NotReaper.Models;
using NotReaper.Targets;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using NotReaper.IO;
using NotReaper.Audio;
using NotReaper.Audio.Noise;

namespace NotReaper.Timing {
	public struct CopyContext {
		public float[] bufferData;
		public int bufferChannels;
		public int bufferFreq;
		public int index;

        public float volume;
		public float playbackSpeed;

		//Write value
		public float outputValue;
	}

    

	public class ClipData {
		public float[] samples;
		public int frequency;
		public int channels;
		public UInt64 currentSample = 0;
		public uint ScaledCurrentSample {
			get { return (uint)(currentSample >> PrecisionShift); }
		}

		public float pan = 0.0f;

		public float duckVolume = 0.0f;

		public const int PrecisionShift = 32;

		public void SetSampleFromTime(double time) {
			UInt64 sample = (uint)(time * frequency);
			currentSample = sample << PrecisionShift;
		}

		public double CurrentTime {
			get { return (currentSample >> PrecisionShift) / (double)frequency; }
		}

		public float Length {
			get { return (samples.Length / channels) / (float)frequency; }
		}

		public void CopySampleIntoBuffer(CopyContext ctx) {
			UInt64 shiftNum = ((UInt64)1 << PrecisionShift);
			UInt64 speed = (UInt64)frequency * shiftNum / (UInt64)ctx.bufferFreq;
			if(ctx.playbackSpeed != 1.0f) {
				speed = (UInt64)(speed * ctx.playbackSpeed);
			}

			float panClamp = Mathf.Clamp(pan, -1.0f, 1.0f);

			int clipChannel = 0;
			int sourceChannel = 0;
			float maxValue = 0.0f;
			while (sourceChannel < ctx.bufferChannels) {
				float panAmount = 1.0f;
				if(sourceChannel == 0) {
					panAmount = Math.Min(1.0f - panClamp, 1.0f);
				}
				else if(sourceChannel == 1) {
					panAmount = Math.Min(1.0f + panClamp, 1.0f);
				}

				float value = 0.0f;
				long samplePos = (uint)(currentSample >> PrecisionShift) * channels + clipChannel;
				if(samplePos < samples.Length) {
					value = samples[samplePos];
				}

				float duckValue = Mathf.Clamp(1.0f - duckVolume, 0.0f, 1.0f);
				maxValue = Math.Max(value * ctx.volume * duckValue, maxValue);

				ctx.bufferData[ctx.index * ctx.bufferChannels + sourceChannel] += value * ctx.volume * panAmount * duckValue;

				sourceChannel++;
				clipChannel++;
				if (clipChannel >= channels) clipChannel = 0;
			}

			currentSample += speed;
			ctx.outputValue = Math.Abs(maxValue);
		}
	};

	[RequireComponent(typeof(AudioSource))]
	public class PrecisePlayback : MonoBehaviour {

        public AudioMixer mixer;
        public AudioMixerGroup susLvol;
        public AudioMixerGroup susRvol;
        public AudioMixerGroup mainMusicvol;
        public AudioMixerGroup hitSoundVol;

        public ClipData song;

		public ClipData songExtra;
		public ClipData preview;
		public ClipData leftSustain;

		public ClipData rightSustain;


		private ClipData kick;
		private ClipData snare;
		private ClipData percussion;
		private ClipData chainStart;
		private ClipData chainNote;
		private ClipData melee;
		private ClipData mine;
		private ClipData meleeShatter;

		private ClipData hihat_hit1;
		private ClipData hihat_hit2;

		private ClipData songend_C;
		private ClipData songend_Csharp;
		private ClipData songend_D;
		private ClipData songend_Dsharp;
		private ClipData songend_E;
		private ClipData songend_F;
		private ClipData songend_Fsharp;
		private ClipData songend_G;
		private ClipData songend_Gsharp;
		private ClipData songend_A;
		private ClipData songend_Asharp;
		private ClipData songend_B;

		public float leftSustainVolume = 1.0f;
        public Slider leftSUSslider;

		public float rightSustainVolume = 1.0f;
        public Slider rightSUSslider;

        public float speed = 1.0f;
		public float volume = 1.0f;
		public float hitSoundVolume = 1.0f;
        public Slider hitSoundSlider;

		private double dspStartTime = 0.0f;
		private double songStartTime = 0.0f;

		private int sampleRate = 1;

		//Preview
		private bool playPreview = false;
		private UInt64 currentPreviewSongSampleEnd = 0;

		//Metronome
		private bool playMetronome = false;
		private int metronomeSamplesLeft = 0;
		private float metronomeTickLength = 0.01f;
		private float nextMetronomeTick = 0;

		private bool playClickTrack = false;
		private QNT_Timestamp clickTrackEndTime;
		private float clickTrackNextTick = 0;

		private bool paused = true;
		[SerializeField] private AudioSource source;
        [SerializeField] private AudioSource hitSounds;
        [SerializeField] private AudioSource sustainL;
        [SerializeField] private AudioSource sustainR;

        [SerializeField] private Timeline timeline;

		[SerializeField] private AudioClip KickClip;
		[SerializeField] private AudioClip SnareClip;
		[SerializeField] private AudioClip PercussionClip;
		[SerializeField] private AudioClip ChainStartClip;
		[SerializeField] private AudioClip ChainNoteClip;
		[SerializeField] private AudioClip MeleeClip;
		[SerializeField] private AudioClip MineClip;
		[SerializeField] private AudioClip MeleeShatterClip;

		[SerializeField] private AudioClip HiHat_Hit1;
		[SerializeField] private AudioClip HiHat_Hit2;

		[Space]
		[Header("SongEnd")]
		[SerializeField] private AudioClip song_end_C;
		[SerializeField] private AudioClip song_end_Csharp;
		[SerializeField] private AudioClip song_end_D;
		[SerializeField] private AudioClip song_end_Dsharp;
		[SerializeField] private AudioClip song_end_E;
		[SerializeField] private AudioClip song_end_F;
		[SerializeField] private AudioClip song_end_Fsharp;
		[SerializeField] private AudioClip song_end_G;
		[SerializeField] private AudioClip song_end_Gsharp;
		[SerializeField] private AudioClip song_end_A;
		[SerializeField] private AudioClip song_end_Asharp;
		[SerializeField] private AudioClip song_end_B;

		//[NRInject] private AudioVisualizer visualizer;
		[NRInject] private AudioPeer visualizer;
		private bool audioSamplesLoaded = false;

		public Transform mainCameraTrans;
		private float mainCameraX = 0f;

		private void Start()
        {
            sampleRate = AudioSettings.outputSampleRate;
            sustainR.outputAudioMixerGroup = susRvol;
            sustainL.outputAudioMixerGroup = susLvol;
            //leftSustainVolume = leftSUSslider.value;
            //rightSustainVolume = rightSUSslider.value;
            hitSoundVolume = hitSoundSlider.value;
            
            leftSUSslider.onValueChanged.AddListener(val => {
                leftSUSslider.value = val;
                NRSettings.config.EditorSustainVol = leftSUSslider.value;
                NRSettings.SaveSettingsJson();
            });
            NRSettings.OnLoad(() => {
                leftSUSslider.value = NRSettings.config.EditorSustainVol;

                

                if (NRSettings.config.clearCacheOnStartup)
                {
                   HandleCache.ClearCache();
                }
            });
            source.Play();
			StartCoroutine(LoadAudioSamples());
		}

        
		public AudioSource GetSource()
        {
			return source;
        }
        



		private void Update() {
			//mainCameraX = mainCameraTrans.position.x;
            

        }

        IEnumerator LoadAudioSamples() {
			while (KickClip.loadState != AudioDataLoadState.Loaded) yield return null;
			while (SnareClip.loadState != AudioDataLoadState.Loaded) yield return null;
			while (PercussionClip.loadState != AudioDataLoadState.Loaded) yield return null;
			while (ChainStartClip.loadState != AudioDataLoadState.Loaded) yield return null;
			while (ChainNoteClip.loadState != AudioDataLoadState.Loaded) yield return null;
			while (MeleeClip.loadState != AudioDataLoadState.Loaded) yield return null;
			while (MineClip.loadState != AudioDataLoadState.Loaded) yield return null;
			while (MeleeShatterClip.loadState != AudioDataLoadState.Loaded) yield return null;

			while (HiHat_Hit1.loadState != AudioDataLoadState.Loaded) yield return null;
			while (HiHat_Hit2.loadState != AudioDataLoadState.Loaded) yield return null;

			while (song_end_C.loadState != AudioDataLoadState.Loaded) yield return null;
			while (song_end_Csharp.loadState != AudioDataLoadState.Loaded) yield return null;
			while (song_end_D.loadState != AudioDataLoadState.Loaded) yield return null;
			while (song_end_Dsharp.loadState != AudioDataLoadState.Loaded) yield return null;
			while (song_end_E.loadState != AudioDataLoadState.Loaded) yield return null;
			while (song_end_F.loadState != AudioDataLoadState.Loaded) yield return null;
			while (song_end_Fsharp.loadState != AudioDataLoadState.Loaded) yield return null;
			while (song_end_G.loadState != AudioDataLoadState.Loaded) yield return null;
			while (song_end_Gsharp.loadState != AudioDataLoadState.Loaded) yield return null;
			while (song_end_A.loadState != AudioDataLoadState.Loaded) yield return null;
			while (song_end_Asharp.loadState != AudioDataLoadState.Loaded) yield return null;
			while (song_end_B.loadState != AudioDataLoadState.Loaded) yield return null;

			kick = FromAudioClip(KickClip);
			snare = FromAudioClip(SnareClip);
			percussion = FromAudioClip(PercussionClip);
			chainStart = FromAudioClip(ChainStartClip);
			chainNote = FromAudioClip(ChainNoteClip);
			melee = FromAudioClip(MeleeClip);
			meleeShatter = FromAudioClip(MeleeShatterClip);
			mine = FromAudioClip(MineClip);

			hihat_hit1 = FromAudioClip(HiHat_Hit1);
			hihat_hit2 = FromAudioClip(HiHat_Hit2);

			songend_C = FromAudioClip(song_end_C);
			songend_Csharp = FromAudioClip(song_end_Csharp);
			songend_D = FromAudioClip(song_end_D);
			songend_Dsharp = FromAudioClip(song_end_Dsharp);
			songend_E = FromAudioClip(song_end_E);
			songend_F = FromAudioClip(song_end_F);
			songend_Fsharp = FromAudioClip(song_end_Fsharp);
			songend_G = FromAudioClip(song_end_G);
			songend_Gsharp = FromAudioClip(song_end_Gsharp);
			songend_A = FromAudioClip(song_end_A);
			songend_Asharp = FromAudioClip(song_end_Asharp);
			songend_B = FromAudioClip(song_end_B);

			audioSamplesLoaded = true;
		}

		public enum LoadType {
			MainSong,
			LeftSustain,
			RightSustain,
			Extra
		}

		private ClipData FromAudioClip(AudioClip clip) {
            ClipData data = new ClipData
            {
                samples = new float[clip.samples * clip.channels]
            };
            clip.GetData(data.samples, 0);

			data.frequency = clip.frequency;
			data.channels = clip.channels;

			return data;
		}

		public void LoadAudioClip(AudioClip clip, LoadType type) {
			ClipData data = FromAudioClip(clip);

			if(type == LoadType.MainSong) {
				song = data;

                preview = new ClipData
                {
                    samples = song.samples,
                    channels = song.channels,
                    frequency = song.frequency
                };
            }
			else if(type == LoadType.LeftSustain) {
				leftSustain = data;
				//leftSustainVolume = 0.0f;
               // leftSustainVolume = sustainL.volume;
                //sustainL.outputAudioMixerGroup = susLvol;
            }
			else if(type == LoadType.RightSustain) {
				rightSustain = data;
				//rightSustainVolume = 0.0f;
               // rightSustainVolume = sustainR.volume;
                //sustainR.outputAudioMixerGroup = susRvol;
            }
			else if(type == LoadType.Extra) {
				songExtra = data;
			}
            
            //sustainR.Play();
            //sustainL.Play();
            source.Play();
		}

		public double GetTime() {
			return song.CurrentTime;
		}

		public double GetTimeFromCurrentSample() {
			return song.CurrentTime;
		}

		public void StartMetronome() {
			playMetronome = true;
			nextMetronomeTick = 0;
		}

		public void StopMetronome() {
			playMetronome = false;
		}

		public void Play(QNT_Timestamp time) {
			songStartTime = timeline.TimestampToSeconds(time);
			song.SetSampleFromTime(songStartTime);

			if(songExtra != null) {
				songExtra.SetSampleFromTime(songStartTime);
			}
			
			if(leftSustain != null) { 
				leftSustain.SetSampleFromTime(songStartTime);
			}

			if(rightSustain != null) { 
				rightSustain.SetSampleFromTime(songStartTime);
			}
			paused = false;
			clearHitsounds = true;
			clearClicksounds = true;
			dspStartTime = AudioSettings.dspTime;
			source.Play();
			visualizer.StartVisualization();
		}

		public void PlayClickTrack(QNT_Timestamp endTime) {
			playClickTrack = true;
			clickTrackEndTime = endTime;
			clickTrackNextTick = 0;
		}

		public AudioClip GenerateClickTrack(QNT_Timestamp endTime) {
			int numSamples = (int)(sampleRate * timeline.TimestampToSeconds(endTime));
			clickTrackEvents.Clear();

			AudioClip clip = AudioClip.Create("click_track", numSamples, 2, sampleRate, false);
			float[] audioData = new float[numSamples * 2];
			ClickTrackPCMReaderCallback(audioData);
			clip.SetData(audioData, 0);

			return clip;
		}

		void ClickTrackPCMReaderCallback(float[] data) {
			CopyContext ctx;
			ctx.bufferData = data;
			ctx.bufferChannels = 2;
			ctx.bufferFreq = sampleRate;
			ctx.playbackSpeed = 1.0f;
			ctx.outputValue = 0.0f;
			ctx.volume = volume;

			for (int dataIndex = 0; dataIndex < data.Length / 2; dataIndex++) {
				ctx.index = dataIndex;

				QNT_Timestamp currentTick = timeline.ShiftTick(new QNT_Timestamp(0), (float)((dataIndex) / (float)sampleRate));
				TempoChange currentTempo = timeline.GetTempoForTime(currentTick);
				QNT_Duration timeSignatureDuration = new QNT_Duration(Constants.PulsesPerWholeNote / currentTempo.timeSignature.Denominator);
				GenerateClickTrackSamples(ctx, currentTick, currentTempo);
			}
		}

		public void Stop() {
			paused = true;
			StopMetronome();
			playClickTrack = false;
			visualizer.StopVisualization();
		}

		public void PlayPreview(QNT_Timestamp time, Relative_QNT previewDuration) {
			float midTime = timeline.TimestampToSeconds(time);
			float duration = (float)Conversion.FromQNT(new Relative_QNT(Math.Abs(previewDuration.tick)), timeline.GetTempoForTime(time).microsecondsPerQuarterNote);
			duration = Math.Min(duration, 0.1f);

			UInt64 sampleStart = (UInt64)((midTime - duration / 2) * song.frequency);
			UInt64 sampleEnd = (UInt64)((midTime + duration / 2) * song.frequency);
			preview.currentSample = sampleStart << ClipData.PrecisionShift;
			currentPreviewSongSampleEnd = sampleEnd << ClipData.PrecisionShift;
			playPreview = true;
			source.Play();

			if (NRSettings.config.playNoteSoundsWhileScrolling) {
				List<HitsoundEvent> previewHits = new List<HitsoundEvent>();
				AddHitsoundEvents(previewHits, time, previewDuration.tick > 0 ? timeline.ShiftTick(time, duration) : time);
				for (int i = 0; i < previewHits.Count; ++i) {
					HitsoundEvent ev = previewHits[i];
					ev.waitSamples = 0;
					previewHits[i] = ev;
				}

				newPreviewHitsoundEvents = previewHits;
			}
		}

		public void PlayHitsound(QNT_Timestamp time) {
			List<HitsoundEvent> previewHits = new List<HitsoundEvent>();
			AddHitsoundEvents(previewHits, time, time);
			for(int i = 0; i < previewHits.Count; ++i) {
				HitsoundEvent ev = previewHits[i];
				ev.waitSamples = 0;
				previewHits[i] = ev;
			}

			newPreviewHitsoundEvents = previewHits;
		}

		struct HitsoundEvent {
			public uint ID;
			public QNT_Timestamp time;
			public UInt64 waitSamples;
			public UInt64 currentSample;
			public ClipData sound;
			public float pan;
			public float volume;
			public float xPos;
		};
		List<HitsoundEvent> hitsoundEvents = new List<HitsoundEvent>();
		bool clearHitsounds = false;

		List<HitsoundEvent> newPreviewHitsoundEvents = null;
		List<HitsoundEvent> previewHitsoundEvents = new List<HitsoundEvent>();

		QNT_Timestamp hitSoundEnd = new QNT_Timestamp(0);

		void AddHitsoundEvents(List<HitsoundEvent> events, QNT_Timestamp start, QNT_Timestamp end) {
			if(!audioSamplesLoaded) {
				return;
			}
			
			if(Timeline.orderedNotes.Count == 0) {
				return;
			}
			if(start > end) {
				QNT_Timestamp temp = start;
				start = end;
				end = temp;
			}

			float startTime = timeline.TimestampToSeconds(start);

			foreach (Target t in new NoteEnumerator(start, end))
			{
				TargetData data = t.data;
				if (data.time < start)
				{
					continue;
				}
				if (data.velocity == InternalTargetVelocity.Silent)
				{
					continue;
				}
				if (data.time > end)
				{
					return;
				}

				bool added = false;
				foreach (HitsoundEvent ev in events)
				{
					if (ev.ID == data.ID)
					{
						added = true;
						break;
					}
				}

				if (!added)
				{
					HitsoundEvent ev;
					ev.ID = data.ID;
					ev.currentSample = 0;
					ev.waitSamples = (UInt64)((timeline.TimestampToSeconds(data.time) - startTime) * sampleRate) << ClipData.PrecisionShift;
					ev.sound = kick;
					ev.time = data.time;
					ev.pan = (data.x / 7.15f);
					ev.volume = 1.0f;
					ev.xPos = data.x;

					switch (data.velocity)
					{
						case InternalTargetVelocity.Kick:
							ev.sound = kick;
							break;

						case InternalTargetVelocity.Percussion:
							ev.sound = percussion;
							break;

						case InternalTargetVelocity.Snare:
							ev.sound = snare;
							break;

						case InternalTargetVelocity.Chain:
							ev.sound = chainNote;
							break;

						case InternalTargetVelocity.ChainStart:
							ev.sound = chainStart;
							break;

						case InternalTargetVelocity.Melee:
							ev.sound = t.data.behavior == TargetBehavior.Melee ? melee : meleeShatter;
							break;

						case InternalTargetVelocity.Mine:
							ev.sound = mine;
							break;

						case InternalTargetVelocity.Silent:
							ev.sound = null;
							break;

						default:
							continue;
					}

					//Only one hitsound at a time per point in time
					for (int j = events.Count - 1; j >= 0; j--)
					{
						if (events[j].sound == ev.sound)
						{
							if (events[j].waitSamples == ev.waitSamples)
							{
								events.RemoveAt(j);
							}
						}
					}
					events.Add(ev);

					//Song End Pitch
					if (data.time == Timeline.orderedNotes.Last().data.time)
					{
						if (!NRSettings.config.playEndEvent)
						{
							continue;
						}
						if (paused)
						{
							continue;
						}
						if (Timeline.desc.songEndEvent == "event:/song_end/song_end_nopitch")
						{
							continue;
						}
						ev.ID = data.ID;
						ev.currentSample = 0;
						ev.waitSamples = (UInt64)((timeline.TimestampToSeconds(data.time) - startTime) * sampleRate) << ClipData.PrecisionShift;
						ev.sound = kick;
						ev.time = data.time;
						ev.pan = (data.x / 7.15f);
						ev.volume = 1.0f;
						ev.xPos = data.x;

						switch (Timeline.desc.songEndEvent)
						{
							case "event:/song_end/song_end_C":
								ev.sound = songend_C;
								break;

							case "event:/song_end/song_end_C#":
								ev.sound = songend_Csharp;
								break;

							case "event:/song_end/song_end_D":
								ev.sound = songend_D;
								break;

							case "event:/song_end/song_end_D#":
								ev.sound = songend_Dsharp;
								break;

							case "event:/song_end/song_end_E":
								ev.sound = songend_E;
								break;

							case "event:/song_end/song_end_F":
								ev.sound = songend_F;
								break;

							case "event:/song_end/song_end_F#":
								ev.sound = songend_Fsharp;
								break;

							case "event:/song_end/song_end_G":
								ev.sound = songend_G;
								break;

							case "event:/song_end/song_end_G#":
								ev.sound = songend_Gsharp;
								break;

							case "event:/song_end/song_end_A":
								ev.sound = songend_A;
								break;

							case "event:/song_end/song_end_A#":
								ev.sound = songend_Asharp;
								break;

							case "event:/song_end/song_end_B":
								ev.sound = songend_B;
								break;

							case "event:/song_end/song_end_nopitch":
								ev.sound = null;
								break;

							default:
								continue;
						}
						for (int j = events.Count - 1; j >= 0; j--)
						{
							if (events[j].sound == ev.sound)
							{
								if (events[j].waitSamples == ev.waitSamples)
								{
									events.RemoveAt(j);
								}
							}
						}
						events.Add(ev);
					}
				}			
			}
		}

		void PlayHitsounds(CopyContext ctx, List<HitsoundEvent> events)
        {
			kick.duckVolume = 0.0f;
			snare.duckVolume = 0.0f;
			percussion.duckVolume = 0.0f;
			chainStart.duckVolume = 0.0f;
			chainNote.duckVolume = 0.0f;
			melee.duckVolume = 0.0f;
			mine.duckVolume = 0.0f;
			meleeShatter.duckVolume = 0.0f;

			songend_C.duckVolume = 0.0f;
			songend_Csharp.duckVolume = 0.0f;
			songend_D.duckVolume = 0.0f;
			songend_Dsharp.duckVolume = 0.0f;
			songend_E.duckVolume = 0.0f;
			songend_F.duckVolume = 0.0f;
			songend_Fsharp.duckVolume = 0.0f;
			songend_G.duckVolume = 0.0f;
			songend_Gsharp.duckVolume = 0.0f;
			songend_A.duckVolume = 0.0f;
			songend_Asharp.duckVolume = 0.0f;
			songend_B.duckVolume = 0.0f;

			float oldSpeed = ctx.playbackSpeed;

			UInt64 waitSpeed = (UInt64)1 << ClipData.PrecisionShift;
			if(oldSpeed != 1.0f) {
				waitSpeed = (UInt64)(waitSpeed * oldSpeed);
			}

			//Always play hitsounds at full speed
			ctx.playbackSpeed = 1.0f;

			for (int i = events.Count - 1; i >= 0; i--) {
				HitsoundEvent ev = events[i];
				bool valid = true;

				if(ev.waitSamples > 0) {
					if(waitSpeed > ev.waitSamples) {
						ev.waitSamples = 0;
					}
					else {
						ev.waitSamples -= waitSpeed;
					}
				}
				else {
					ctx.volume = hitSoundVolume * ev.volume;
					ev.sound.currentSample = ev.currentSample;
					ev.sound.pan = ev.pan;
					ev.sound.CopySampleIntoBuffer(ctx);

					ev.sound.duckVolume = Mathf.Clamp(ev.sound.duckVolume + 0.25f, 0.0f, 1.0f);

					if(ev.sound.ScaledCurrentSample > ev.sound.samples.Length) {
						events.RemoveAt(i);
						valid = false;
					}
					else {
						ev.currentSample = ev.sound.currentSample;
					}
				}
				
				//Update the pan:

				ev.pan = (ev.xPos - mainCameraX) / 7.15f;

				

				if(valid) {
					events[i] = ev;
				}
			}

			ctx.playbackSpeed = 1.0f;
		}


		struct ClickTrackEvent {
			public QNT_Timestamp time;
			public ClipData clip;
			public UInt64 currentSample;
		};

		
                List<ClickTrackEvent> clickTrackEvents = new List<ClickTrackEvent>();
		bool clearClicksounds = false;

		void TryAddClickEvent(QNT_Timestamp current, QNT_Timestamp beat, ClipData clip) {
			if(current == beat) {
				bool addedSound = false;
				foreach(ClickTrackEvent ev in clickTrackEvents) {
					if(ev.time == current) {
						addedSound = true;
						break;
					}
				}
                
                if (!addedSound) {
					ClickTrackEvent ev;
					ev.clip = clip;
					ev.currentSample = 0;
					ev.time = current;
					clickTrackEvents.Add(ev);
				}
			}
		}

		void OnAudioFilterRead(float[] bufferData, int bufferChannels) {
			CopyContext ctx;
			ctx.bufferData = bufferData;
			ctx.bufferChannels = bufferChannels;
			ctx.bufferFreq = sampleRate;
			ctx.playbackSpeed = speed;
			ctx.outputValue = 0.0f;

			if(clearHitsounds) {
				hitsoundEvents.Clear();
				hitSoundEnd = new QNT_Timestamp(0);
				clearHitsounds = false;
			}

			if(clearClicksounds) {
				clickTrackEvents.Clear();
				clearClicksounds = false;
			}

			if(newPreviewHitsoundEvents != null) {
				List<HitsoundEvent> newPreview = newPreviewHitsoundEvents;
				newPreviewHitsoundEvents = null;

				previewHitsoundEvents.Clear();
				previewHitsoundEvents = newPreview;
			}

			if(playPreview) {
				int dataIndex = 0;

				while(dataIndex < bufferData.Length / bufferChannels && (preview.currentSample < currentPreviewSongSampleEnd) && (preview.ScaledCurrentSample) < song.samples.Length) {
					ctx.index = dataIndex;
					ctx.volume = volume;
					ctx.playbackSpeed = speed;
					preview.CopySampleIntoBuffer(ctx);

					PlayHitsounds(ctx, previewHitsoundEvents);

					++dataIndex;
				}

				if(preview.currentSample >= currentPreviewSongSampleEnd || (preview.ScaledCurrentSample) >= song.samples.Length) {
					playPreview = false;
				}
			}

			if (paused || (song.ScaledCurrentSample) > song.samples.Length) {
				hitsoundEvents.Clear();

				//Continue to flush the hitsounds
				if(!playPreview && previewHitsoundEvents.Count > 0) {
					int dataIndex = 0;

					while(dataIndex < bufferData.Length / bufferChannels) {
						ctx.index = dataIndex;
						ctx.volume = hitSoundVolume;
						PlayHitsounds(ctx, previewHitsoundEvents);
						++dataIndex;
					}
				}

				return;
			}

			if(song != null) {
				QNT_Timestamp timeStart = timeline.ShiftTick(new QNT_Timestamp(0), (float)song.CurrentTime);
				QNT_Timestamp timeEnd = timeline.ShiftTick(new QNT_Timestamp(0), (float)(song.CurrentTime + (bufferData.Length / bufferChannels) / (float)song.frequency * (song.frequency / (float)sampleRate)));

				if(timeEnd > hitSoundEnd) {
					hitSoundEnd = timeStart + Constants.QuarterNoteDuration;
					AddHitsoundEvents(hitsoundEvents, timeStart, hitSoundEnd);
				}
			}

			for (int dataIndex = 0; dataIndex < bufferData.Length / bufferChannels; dataIndex++) {
				ctx.volume = volume;
				ctx.index = dataIndex;
				ctx.playbackSpeed = speed;
				song.CopySampleIntoBuffer(ctx);

				if(songExtra != null) {
					songExtra.CopySampleIntoBuffer(ctx);
				}

				//Play hitsounds (reverse iterate so we can remove)
				ctx.volume = hitSoundVolume;
				PlayHitsounds(ctx, hitsoundEvents);

				ctx.playbackSpeed = speed;
				if(leftSustain != null) {
					//ctx.volume = leftSustainVolume;
                    ctx.volume = (leftSUSslider.value * leftSustainVolume);
					leftSustain.CopySampleIntoBuffer(ctx);
				}

				if(rightSustain != null) {
					//ctx.volume = rightSustainVolume;
                    ctx.volume = (rightSUSslider.value * rightSustainVolume);
                    rightSustain.CopySampleIntoBuffer(ctx);
				}

				QNT_Timestamp currentTick = timeline.ShiftTick(new QNT_Timestamp(0), (float)GetTimeFromCurrentSample());
				TempoChange currentTempo = timeline.GetTempoForTime(currentTick);
				QNT_Duration timeSignatureDuration = new QNT_Duration(Constants.PulsesPerWholeNote / currentTempo.timeSignature.Denominator);

				if(playMetronome) {
					if(GetTimeFromCurrentSample() > nextMetronomeTick) {
						metronomeSamplesLeft = (int)(sampleRate * metronomeTickLength);
						nextMetronomeTick = 0;
					}

					if(nextMetronomeTick == 0) {
                        /*if (timeline.hasBpmDragOffset)
                        {
							nextMetronomeTick = timeline.TimestampToSeconds(timeline.ShiftTick(new QNT_Timestamp(0), (float)GetTimeFromCurrentSample()) + timeSignatureDuration);
                        }*/
                        //else
                        //{
							QNT_Timestamp nextBeat = timeline.GetClosestBeatSnapped(timeline.ShiftTick(new QNT_Timestamp(0), (float)GetTimeFromCurrentSample()) + timeSignatureDuration, currentTempo.timeSignature.Denominator);
							nextMetronomeTick = timeline.TimestampToSeconds(nextBeat);
                        //}
					}
				}

				//Metronome
				if(metronomeSamplesLeft > 0) {
					const uint MetronomeTickFreq = 817;
					const uint BigMetronomeTickFreq = 1024;

					QNT_Timestamp tempoStart = currentTempo.time;

					uint tickFreq = 0;

					UInt64 currentBeatInBar = ((currentTick.tick - tempoStart.tick) / timeSignatureDuration.tick) % currentTempo.timeSignature.Numerator;

					if(currentBeatInBar == 0) {
						tickFreq = BigMetronomeTickFreq;
					}
					else {
						tickFreq = MetronomeTickFreq;
					}

					for(int c = 0; c < bufferChannels; ++c) {
						int totalMetroSamples = (int)(sampleRate * metronomeTickLength);
						float metro = Mathf.Sin(Mathf.PI * 2 * tickFreq * ((totalMetroSamples - metronomeSamplesLeft) / (float)totalMetroSamples) * metronomeTickLength) * 0.33f;
						bufferData[dataIndex * bufferChannels + c] = Mathf.Clamp(bufferData[dataIndex * bufferChannels + c] + metro, -1.0f, 1.0f);
					}
					metronomeSamplesLeft -= 1;
				}

				
				if(playClickTrack && currentTick < clickTrackEndTime) {
					ctx.volume = volume;
					ctx.index = dataIndex;
					ctx.playbackSpeed = 1.0f;
					GenerateClickTrackSamples(ctx, currentTick, currentTempo);
				}
			}
		}

		void GenerateClickTrackSamples(CopyContext ctx, QNT_Timestamp currentTick, TempoChange currentTempo) {
			QNT_Timestamp nextBeat = timeline.GetClosestBeatSnapped(currentTick, currentTempo.timeSignature.Denominator);

			TryAddClickEvent(currentTick, nextBeat, hihat_hit1);
			TryAddClickEvent(currentTick, nextBeat + Constants.SixteenthNoteDuration, hihat_hit2);
			TryAddClickEvent(currentTick, nextBeat + Constants.EighthNoteDuration, hihat_hit2);
			TryAddClickEvent(currentTick, nextBeat + Constants.EighthNoteDuration + Constants.SixteenthNoteDuration, hihat_hit2);

			for (int i = clickTrackEvents.Count - 1; i >= 0; i--)
			{
				ClickTrackEvent ev = clickTrackEvents[i];
				ev.clip.currentSample = ev.currentSample;
				ev.clip.CopySampleIntoBuffer(ctx);
				ev.currentSample = ev.clip.currentSample;

				if (ev.clip.ScaledCurrentSample > ev.clip.samples.Length)
				{
					clickTrackEvents.RemoveAt(i);
				}
				else
				{
					clickTrackEvents[i] = ev;
				}
			}
		}
	}
}