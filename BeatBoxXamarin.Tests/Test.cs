using BeatBoxXamarin.ViewModels;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;

namespace BeatBoxXamarin.Tests
{
    [TestFixture]
    public class SoundViewModelTests
    {
        private IBeatBox _beatBox;
        private Sound _sound;
        private SoundViewModel _subject;

        [SetUp]
        public void SetUp()
        {
            _beatBox = Substitute.For<IBeatBox>();
            _sound = new Sound("assetPath");
            _subject = new SoundViewModel(_beatBox);
            _subject.Sound = _sound;
        }

        [Test]
        public void ExposesSoundNameAsTitle()
        {
            _subject.Title.Should().Be(_sound.Name);
        }

        [Test]
        public void CallsBeatBoxPlayedOnButtonClicked()
        {
            _subject.ClickedCommand.Execute(null);

            _beatBox.Received().Play(_sound);
        }
    }
}
