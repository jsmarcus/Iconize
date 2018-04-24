
using System.Linq;
using Foundation;
using UIKit;

namespace Iconize.Sample.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication uiApplication, NSDictionary launchOptions)
        {
            global::Xamarin.Forms.Forms.Init();

            foreach (var familyName in UIFont.FamilyNames.OrderBy(x => x))
            {
                System.Console.WriteLine($"Family: {familyName}");
                foreach (var name in UIFont.FontNamesForFamilyName(familyName).OrderBy(y => y))
                {
                    System.Console.WriteLine(name);
                }
            }

            LoadApplication(new App());

            return base.FinishedLaunching(uiApplication, launchOptions);
        }
    }
}
