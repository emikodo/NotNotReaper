using System;
using System.Collections.Generic;
using UnityEngine;
using NAudio.Midi;
using NotReaper.Targets;
using NotReaper.Timing;
using NotReaper.UI;
using NotReaper.Modifier;
using Newtonsoft.Json;

namespace NotReaper.Models {
	public struct TempoChange {
		public QNT_Timestamp time;
		public UInt64 microsecondsPerQuarterNote;
		public TimeSignature timeSignature;
		public bool ExplicitSignature;
		public float secondsFromStart;
	}

	// Song info that goes into track.data.json
	[Serializable]
	public class SongDesc
	{

		public string songID = "";
		public string title = "";
		public string artist = "";
		public string duration = "";
		public string albumArt = "";
		public string audioFile = "";
		List<Difficulty> supportedDifficulties = new List<Difficulty>();
		public float bpm = 120.0f;
		public string mapper = "";

		[JsonIgnore]
		public string cachedMainSong
		{
			get
			{
				return $"{this.songID}";
			}
		}

		// Unimplemented
		public List<TempoChange> tempoList;
		public double previewStartSeconds = 0.0d;
	}

	public class DiffsList {
		public CueFile expert = new CueFile();
		public CueFile advanced = new CueFile();
		public CueFile moderate = new CueFile();
		public CueFile beginner = new CueFile();

	}

	[Serializable]
	public class NRCueData {

		//1 - Initial version
		public uint Version = 1;
		
		public List<Cue> pathBuilderNoteCues = new List<Cue>();
		public List<LegacyPathbuilderData> pathBuilderNoteData = new List<LegacyPathbuilderData>();
		public List<PathbuilderData> newPathbuilderData = new List<PathbuilderData>();
		public List<Cue> newPathbuilderCues = new List<Cue>();
        public List<RepeaterSection> repeaterSections = new List<RepeaterSection>();
        public List<ModifierHandler> modifiers = new List<ModifierHandler>(); //TODO: is this needed?
	}

	[Serializable]
	public class CueFile {
		public List<Cue> cues = null;
		public NRCueData NRCueData = null;
	}
    

    public class ErrorLogEntry
    {
        public QNT_Timestamp time; 
        public readonly string errorDesc;

        public List<Target> affectedTargets = new List<Target>();

        public ErrorLogEntry(QNT_Timestamp time, string v)
        {
            this.time = time;
            this.errorDesc = v;
        }
    }

	public class AudicaFile {
		public SongDesc desc = new SongDesc();
		public AudioClip song;
		public DiffsList diffs = new DiffsList();
        public ModifierList modifiers = new ModifierList();
		public AudioClip song_extras;
		public AudioClip song_sustain_l;
		public AudioClip song_sustain_r;
		public MoggSong mainMoggSong;
		public MidiFile song_mid;
		public string filepath;
		public bool usesLeftSustain = false;
		public bool usesRightSustain = false;

	}

    [Serializable]
    public class ModifierList
    {
        public List<Modifier.ModifierDTO> modifiers = new List<Modifier.ModifierDTO>();
    }

	public static class CuesDifficulty {
		public static string expert = "expert";
		public static string advanced = "advanced";
		public static string standard = "standard";
		public static string easy = "easy";
	}


	public enum Difficulty { Expert = 0, Advanced = 1, Standard = 2, Easy = 3 }
	public enum TargetHandType { Either = 0, Right = 1, Left = 2, None = 3 }
	public enum TargetBehavior { Standard = 0, Vertical = 1, Horizontal = 2, Sustain = 3, ChainStart = 4, ChainNode = 5, Melee = 6, Mine = 7, None = 8, Legacy_Pathbuilder = 101}
	public enum InternalTargetVelocity { Kick = 20, Snare = 127, Percussion = 60, ChainStart = 1, Chain = 2, Melee = 3, Mine = 4, Silent = 999 }
	public enum EditorTool { DragSelect, ChainBuilder, ModifierCreator, SpacingSnapper, Pathbuilder, None } //Standard, Vertical, Horizontal, Sustain, ChainStart, ChainNode, Melee, Mine, 
	public enum EditorMode { Compose, Metadata, Settings, Timing };
	public enum TargetHitsound { Standard = 0, Snare = 1, Percussion = 2, ChainStart = 3, ChainNode = 4, Melee = 5, Silent = 6, Mine = 7, Metronome = 8 }
	public enum SnappingMode { None, Grid, Melee, DetailGrid }

	static class TargetBehaviorExtensions
    {
		public static bool IsMeleeOrMine(this TargetBehavior behavior)
        {
			return behavior == TargetBehavior.Mine || behavior == TargetBehavior.Melee;
        }
    }

	[Serializable]
	public class Cue {
		public int tick;
		public int tickLength;
		public int pitch;
		public InternalTargetVelocity velocity = InternalTargetVelocity.Kick;
		public GridOffset gridOffset = new GridOffset { x = 0, y = 0 };
		public float zOffset = 0;
		public TargetHandType handType = TargetHandType.Right;
		public TargetBehavior behavior = TargetBehavior.Standard;

		[Serializable]
		public struct GridOffset {
			public double x;
			public double y;
		}
	}



}