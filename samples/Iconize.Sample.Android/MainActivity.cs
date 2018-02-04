using System;
using Android.App;
using Android.Content.PM;
using Android.OS;
using Plugin.Iconize;

namespace Iconize.Sample.Droid
{
    [Activity(Label = "Iconize Sample", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
			
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
			ToolbarResource = Resource.Layout.toolbar;
	        TabLayoutResource = Resource.Layout.tabs;
			Plugin.Iconize.Iconize.Init(Resource.Id.toolbar, Resource.Id.tabs);
	        ListAssetFiles("");
            LoadApplication(new Application());
        }


	   
	    private bool ListAssetFiles(String path)
	    {

		    String[] list;
		    try
		    {
			    list = Assets.List(path);
			    if (list.Length > 0)
			    {
				    // This is a folder
				    foreach (string file in list)
				    {
					    if (!ListAssetFiles(path + "/" + file))
						    return false;
					    else
					    {
						    // This is a file
						    // TODO: add file name to an array list
					    }
				    }
			    }
		    }
		    catch (Exception e)
		    {
			    return false;
		    }

		    return true;
	    }
	}
}