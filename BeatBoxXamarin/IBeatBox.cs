using System;
using System.Collections.Generic;
using System.IO;

namespace BeatBoxXamarin
{
    public interface IBeatBox
    {
        List<Sound> Sounds { get; }

        void Load(Sound sound);

        void Play(Sound sound);
    }
}