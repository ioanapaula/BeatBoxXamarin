using System;

namespace BeatBoxXamarin.ViewModels
{
    public class SoundViewModel
    {
        private IBeatBox _beatBox;

        public SoundViewModel(IBeatBox beatBox)
        {
            _beatBox = beatBox;
        }

        public Sound Sound { get; set; }

        public string Title => Sound.Name;
    }
}
