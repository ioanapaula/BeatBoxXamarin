using Android.App;
using Android.OS;
using Android.Support.V4.App;
using Android.Support.V7.App;
using BeatBoxXamarin.Droid.Fragments;

namespace BeatBoxXamarin.Droid
{
    [Activity(Label = "BeatBoxXamarin", MainLauncher = true, Icon = "@mipmap/icon", Theme = "@style/AppTheme")]
    public class BeatBoxActivity : SingleFragmentActivity
    {
        protected override Android.Support.V4.App.Fragment CreateFragment()
        {
           return BeatBoxFragment.NewInstance();
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }
    }
}