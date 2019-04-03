using System;
using System.Linq;

namespace BeatBoxXamarin
{
    public class Sound
    {
        public Sound(string assetPath)
        {
            AssetPath = assetPath;
            string[] components = assetPath.Split('/');
            var filename = components.Last();
            Name = filename.Replace(".wav", string.Empty);
        }

        public string AssetPath { get; }

        public string Name { get; }
    }
}
