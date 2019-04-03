using System;
using System.Collections.Generic;
using System.Linq;
using Android.Content;
using Android.Content.Res;
using Android.Util;
using Java.IO;

namespace BeatBoxXamarin.Droid
{
    public class BeatBox : IBeatBox
    {
        private const string Tag = "BeatBox";
        private const string SoundsFolder = "sample_sounds";

        private AssetManager _assets;

        public BeatBox(Context context)
        {
            _assets = context.Assets;
            LoadSounds();
        }

        public List<Sound> Sounds { get; } = new List<Sound>();

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
                var assetPath = $"{SoundsFolder}/{filename}";
                var sound = new Sound(assetPath);
                Sounds.Add(sound);
            }
        }
    }
}
