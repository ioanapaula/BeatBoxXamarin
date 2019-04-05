using System;
using System.Collections.Generic;
using System.IO;
using Android.Widget;

namespace BeatBoxXamarin
{
    public interface IBeatBox
    {
        List<Sound> Sounds { get; }

        float PlaybackSpeed { get; set; }

        void Load(Sound sound);

        void Play(Sound sound);
    }
}