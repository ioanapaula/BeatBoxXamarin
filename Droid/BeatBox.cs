using System;
using System.Collections.Generic;
using System.Linq;
using Android.Content;
using Android.Content.Res;
using Android.Media;
using Android.Util;
using Android.Widget;
using Java.IO;
using static Android.App.Usage.UsageEvents;

namespace BeatBoxXamarin.Droid
{
    public class BeatBox : IBeatBox
    {
        private const string Tag = "BeatBox";
        private const string SoundsFolder = "sample_sounds";
        private const int MaxSounds = 5;

        private AssetManager _assets;
        private SoundPool _soundPool;

        public BeatBox(Context context)
        {
            _assets = context.Assets;

            var audioAttributes = new AudioAttributes.Builder()
                .SetUsage(AudioUsageKind.Media)
                .Build();

            _soundPool = new SoundPool.Builder()
                .SetMaxStreams(MaxSounds)
                .SetAudioAttributes(audioAttributes)
                .Build();

            LoadSounds();
        }

        public List<Sound> Sounds { get; } = new List<Sound>();

        public float PlaybackSpeed { get; set; } = 1.0f;

        public void Load(Sound sound) 
        {
            var fileDescriptor = _assets.OpenFd(sound.AssetPath);
            var soundId = _soundPool.Load(fileDescriptor, 1);
            sound.Id = soundId;
        } 

        public void Play(Sound sound)
        {
            var soundId = sound.Id;

            if (sound.Id.HasValue)
            { 
                _soundPool.Play(soundId.Value, 1.0f, 1.0f, 1, 0, PlaybackSpeed);
            }
        }

        public void Release()
        {
            _soundPool.Release();
        }

        private void LoadSounds()
        {
            string[] soundNames;

            try
            {
                soundNames = _assets.List(SoundsFolder);
                Log.Info(Tag, $"Found {soundNames.Length} sounds");
            }
            catch (IOException ioe)
            {
                Log.Error(Tag, "Could not list assets", ioe);
                return;
            }

            foreach (string filename in soundNames)
            {
                try
                {
                    var assetPath = $"{SoundsFolder}/{filename}";
                    var sound = new Sound(assetPath);
                    Load(sound);
                    Sounds.Add(sound);
                }
                catch (IOException ioe)
                {
                    Log.Error(Tag, $"Could not load sound {filename}", ioe);
                }
            }
        }
    }
}
