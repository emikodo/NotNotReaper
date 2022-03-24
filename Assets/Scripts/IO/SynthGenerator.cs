using System;
using System.Collections;
using System.Diagnostics;
using System.IO;
using System.Text;
using NAudio.Midi;
using NotReaper.Models;
using SharpCompress.Archives;
using SharpCompress.Archives.Zip;
using SharpCompress.Common.Zip;
using SharpCompress.Writers;
using UnityEngine;

namespace NotReaper.IO {

	public class SynthGenerator {

		public static IEnumerator Generate(string oggPath, float moggSongVol, string songID, string name, string artist, string duration, string coverImage, string audioFile, double bpm, string mapper, Difficulty difficulty, Action<string> onGenerationDone) {


			HandleCache.CheckSaveFolderValid();

			var workFolder = Path.Combine(Application.streamingAssetsPath, "Ogg2Audica");

			
			string audicaTemplate = Path.Combine(workFolder, "AudicaTemplate/");
			string cuesFile = Path.Combine(audicaTemplate, "expert.cues");
			string newCuesName = "expert.cues";
            switch (difficulty)
            {
				case Difficulty.Expert:
					break;
				case Difficulty.Advanced:
					newCuesName = "advanced.cues";
					break;
				case Difficulty.Standard:
					newCuesName = "moderate.cues";
					break;
				case Difficulty.Easy:
					newCuesName = "beginner.cues";
					break;
				default:
					break;
            }
			if(difficulty != Difficulty.Expert) File.Move(cuesFile, Path.Combine(audicaTemplate, newCuesName));

			Encoding encoding = Encoding.GetEncoding("UTF-8");

			//Album art
			File.Delete(Path.Combine(workFolder, "song.png"));
			if (!string.IsNullOrEmpty(coverImage))
			{
				UnityEngine.Debug.Log("Album art found");
				File.Copy(coverImage, Path.Combine(workFolder, "song.png"));
			}

			//We need to modify the BPM of the song.mid contained in the template audica to match whatever this is.
			File.Delete(Path.Combine(workFolder, "song.mid"));
			File.Copy(audioFile, Path.Combine(workFolder, "song.mid"));

			//Generates the mogg into song.mogg, which is moved to the AudicaTemplate
			File.Delete(Path.Combine(workFolder, "song.mogg"));

			Process ogg2mogg = new Process();
			ProcessStartInfo startInfo = new ProcessStartInfo();

			startInfo.FileName = Path.Combine(workFolder, "ogg2mogg.exe");

			if ((Application.platform == RuntimePlatform.LinuxEditor) || (Application.platform == RuntimePlatform.LinuxPlayer))
				startInfo.FileName = Path.Combine(workFolder, "ogg2mogg");

			if ((Application.platform == RuntimePlatform.OSXEditor) || (Application.platform == RuntimePlatform.OSXPlayer))
				startInfo.FileName = Path.Combine(workFolder, "ogg2moggOSX");

			bool processFinished = false;
			var waitItem = new WaitUntil(() => processFinished);

			string args = $"\"{oggPath}\" \"{workFolder}/song.mogg\"";
			startInfo.Arguments = args;
			startInfo.UseShellExecute = false;
			ogg2mogg.StartInfo = startInfo;
			ogg2mogg.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
			ogg2mogg.StartInfo.CreateNoWindow = true;
			ogg2mogg.EnableRaisingEvents = true;
			ogg2mogg.Exited += (obj, a) => processFinished = true;
			ogg2mogg.Start();

			//ogg2mogg.WaitForExit();
			yield return waitItem;

			//Set the song.moggsong volume
			var moggpath = Path.Combine(workFolder, "song.moggsong");
			var moggsongTemplate = Path.Combine(workFolder, "MoggsongTemplate", "song.moggsong");

			File.Delete(moggpath);
			File.Copy(moggsongTemplate, moggpath);
			File.WriteAllText(moggpath, File.ReadAllText(moggpath).Replace("-5", moggSongVol.ToString("n2")));
			
			//Make the song.desc file;
			File.Delete(Path.Combine(workFolder, "song.desc"));
			SongDesc songDesc = JsonUtility.FromJson<SongDesc>(File.ReadAllText(Path.Combine(workFolder, "songtemplate.desc")));
			songDesc.songID = songID;
			songDesc.title = name;
			songDesc.artist = artist;
			if (!string.IsNullOrEmpty(coverImage))
			{
				songDesc.albumArt = "song.png";
			}
			songDesc.bpm = (float)bpm;
			songDesc.mapper = mapper;
			File.WriteAllText(Path.Combine(workFolder, "song.desc"), Newtonsoft.Json.JsonConvert.SerializeObject(songDesc, Newtonsoft.Json.Formatting.Indented));

            /*File.Delete(Path.Combine(workFolder, "modifiers.json"));
            ModifierList modifierList = new ModifierList();
            modifierList.modifiers = ModifierHandler.instance.modifiers;
            File.WriteAllText(Path.Combine(workFolder, "modifiers.json"), JsonUtility.ToJson(modifierList, true));
            */
            File.Create(Path.Combine(workFolder, "modifiers.json"));
			//Create the actual audica file and save it to the /saves/ folder
			using(ZipArchive archive = ZipArchive.Create()) {
				archive.AddAllFromDirectory(audicaTemplate);
				archive.AddEntry("song.desc", Path.Combine(workFolder, "song.desc"));
				archive.AddEntry("song.mid", Path.Combine(workFolder, "song.mid"));
				archive.AddEntry("song.mogg", Path.Combine(workFolder, "song.mogg"));
				archive.AddEntry("song.moggsong", Path.Combine(workFolder, "song.moggsong"));
				if (!string.IsNullOrEmpty(coverImage))
				{
					archive.AddEntry("song.png", Path.Combine(workFolder, "song.png"));
				}

				archive.SaveTo(Path.Combine(Application.dataPath, @"../", "saves", songID + ".audica"), SharpCompress.Common.CompressionType.None);
			}
			if (difficulty != Difficulty.Expert) File.Move(Path.Combine(audicaTemplate, newCuesName), cuesFile);
			onGenerationDone?.Invoke(Path.Combine(Application.dataPath, @"../", "saves", songID + ".audica"));
			//return Path.Combine(Application.dataPath, @"../", "saves", songID + ".audica");
			
		/*
		
			HandleCache.CheckSaveFolderValid(); 59.6, 57.8

			System.Diagnostics.Process myProcess = new System.Diagnostics.Process();
			ProcessStartInfo startInfo = new ProcessStartInfo();
			startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
			startInfo.FileName = Path.Combine(ogg2AudicaFolder, "Ogg2Audica.exe");

			startInfo.Arguments = System.String.Format("\"{0}\" \"{1}\" \"{2}\" \"{3}\" \"{4}\" \"{5}\" \"{6}\" \"{7}\"", oggPath, songID, songName, artist, bpm, songEndEvent, mapper, offset);
			startInfo.UseShellExecute = true;
			startInfo.WorkingDirectory = ogg2AudicaFolder;

			myProcess.StartInfo = startInfo;
			
			myProcess.Start();

			myProcess.WaitForExit();

			File.Move(Path.Combine(ogg2AudicaFolder, "out.audica"), Path.Combine(Application.dataPath, "saves", songID + ".audica"));


			return Path.Combine(Application.dataPath, "saves", songID + ".audica");
			*/


		}

	}

}