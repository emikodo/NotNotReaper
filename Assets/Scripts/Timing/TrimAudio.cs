using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using NAudio.Wave;
using NVorbis;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace NotReaper.Timing {

    public class TrimAudio {
        //So I take the offset + 1920 ticks, and convert that to MS based on bpm

        //Tick to MS = ["tick"] / 480 * tempo / 1000000
        //ms to tick = MS * (1920 / (60000 / BPM * 4))

        //positive offset = add silence
        //negative offset = trim the song

        Process ffmpeg = new Process();

        public TrimAudio() {
            string ffmpegPath = Path.Combine(Application.streamingAssetsPath, "FFMPEG", "ffmpeg.exe");

            if ((Application.platform == RuntimePlatform.LinuxEditor) || (Application.platform == RuntimePlatform.LinuxPlayer))
                ffmpegPath = Path.Combine(Application.streamingAssetsPath, "FFMPEG", "ffmpeg");

            if ((Application.platform == RuntimePlatform.OSXEditor) || (Application.platform == RuntimePlatform.OSXPlayer))
                ffmpegPath = Path.Combine(Application.streamingAssetsPath, "FFMPEG", "ffmpegOSX");

            ffmpeg.StartInfo.FileName = ffmpegPath;
            ffmpeg.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            ffmpeg.EnableRaisingEvents = true;
            ffmpeg.StartInfo.CreateNoWindow = true;
            ffmpeg.StartInfo.UseShellExecute = false;
            ffmpeg.StartInfo.RedirectStandardOutput = true;
        }

        public IEnumerator SetAudioLength(string path, string output, int offset, double bpm, bool skipRetime = false) {

            double offsetMs = TicksToMs(offset, bpm);
            double magicOctoberOffsetFix = 25.0f;
            double ms = Math.Abs(GetOffsetMs(offsetMs, bpm)) - magicOctoberOffsetFix;

            string args;
            
            if (skipRetime) {
                args = String.Format("-y -i \"{0}\" -map 0:a \"{1}\"", path, output);
            }

            else {
                args = String.Format("-y -i \"{0}\" -af \"adelay={1}|{1}\" -map 0:a \"{2}\"", path, ms, output);
                
            }
            
            Debug.Log($"Running ffmpeg with args {args}");
            bool ffmpegFinished = false;
            var waitItem = new WaitUntil(() => ffmpegFinished);
            ffmpeg.StartInfo.Arguments = args;
            ffmpeg.Exited += (obj, a) => ffmpegFinished = true;
            ffmpeg.Start();

            //Debug.Log(ffmpeg.StandardOutput.ReadToEnd());
            //ffmpeg.WaitForExit();
            yield return waitItem;
        }

        private double TicksToMs(double offset, double tempo) {
            double beatLength = 60000 / tempo;
            return (offset / 480.0) * beatLength;
        }

        private double GetOffsetMs(double offset, double bpm) {
            double beatLength = 60000 / bpm;
            return GetOffset(offset, beatLength);
        }

        private double GetOffset(double offset, double beatlength) {
            var cappedOffset = offset % beatlength;
            var padding = beatlength * 3;
            var shift = cappedOffset - beatlength;
            return padding - shift;
        }

        public static string GetffmpgPath() {
            Process p = new Process();
            ProcessStartInfo info = new ProcessStartInfo("bash") {
                // Shell script required since bash doesn't use the same PATH environment variable if run in unity.
                Arguments = "-c" + " \"" + Application.streamingAssetsPath + "/FFMPEG/ffmpegPath.sh\"",
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true,
                WindowStyle = ProcessWindowStyle.Minimized
            };

            p.StartInfo = info;
            p.Start();
            p.WaitForExit();

            var output = p.StandardOutput.ReadToEnd();

            if (output.Length == 0) {
                Debug.Log("ffmpeg is not installed.");
                return null;
            }
            else {
                return output.TrimEnd();
            }
        }
    }
}