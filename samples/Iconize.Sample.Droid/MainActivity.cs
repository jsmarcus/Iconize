using Android.App;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V4.View;
using Android.Support.V7.App;
using Android.Support.V7.Widget;

namespace Iconize.Sample.Droid
{
    [Activity(Label = "", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : AppCompatActivity
    {
        private TabLayout _tabLayout;
        private Toolbar _toolbar;
        private ViewPager _viewPager;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            _tabLayout = FindViewById<TabLayout>(Resource.Id.tabs);
            _toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            _viewPager = FindViewById<ViewPager>(Resource.Id.viewPager);

            SetSupportActionBar(_toolbar);

            _viewPager.Adapter = new FontIconsViewPagerAdapter(Plugin.Iconize.Iconize.Modules);
            _tabLayout.SetupWithViewPager(_viewPager);
        }
    }
}