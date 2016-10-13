using System.Linq;
using FormsPlugin.Iconize;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Iconize.FormsSample
{
    public class App : Application
    {
        public App()
        {
            // The root page of your application
            var tabbedPage = new IconTabbedPage { Title = "Iconize" };

            foreach (var module in Plugin.Iconize.Iconize.Modules)
            {
                tabbedPage.Children.Add(new Page1
                {
                    BindingContext = new ModuleWrapper(module),
                    Icon = module.Keys.FirstOrDefault()
                });
            }

            MainPage = new IconNavigationPage(tabbedPage);
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
