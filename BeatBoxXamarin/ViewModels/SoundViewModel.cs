using System;
using GalaSoft.MvvmLight.Command;

namespace BeatBoxXamarin.ViewModels
{
    public class SoundViewModel
    {
        private IBeatBox _beatBox;
        private int _numberOfClicks = 0;

        public SoundViewModel(IBeatBox beatBox)
        {
            _beatBox = beatBox;

            ClickedCommand = new RelayCommand(OnClicked);
        }

        public Sound Sound { get; set; }

        public RelayCommand ClickedCommand { get; }

        public string Title => Sound.Name;
       
        private void OnClicked()
        {
            _beatBox.Play(Sound);
            _numberOfClicks++;
        }
    }
}
