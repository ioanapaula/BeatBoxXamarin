using Android.App;
using Android.OS;
using Android.Support.V7.App;

namespace BeatBoxXamarin.Droid
{
    [Activity(Label = "BeatBoxXamarin", MainLauncher = true, Icon = "@mipmap/icon", Theme = "@style/AppTheme")]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }
    }
}