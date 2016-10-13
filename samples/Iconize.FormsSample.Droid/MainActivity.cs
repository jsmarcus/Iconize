using Android.App;
using Android.Content.PM;
using Android.OS;
using FormsPlugin.Iconize.Droid;

namespace Iconize.FormsSample.Droid
{
    [Activity(Label = "Iconize.FormsSample", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            IconControls.Init(Resource.Id.toolbar, Resource.Id.tabs);
            ToolbarResource = Resource.Layout.toolbar;
            TabLayoutResource = Resource.Layout.tabs;
            LoadApplication(new App());
        }
    }
}