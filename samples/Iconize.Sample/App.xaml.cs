using System.Linq;
using Plugin.Iconize;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Iconize.Sample
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            Plugin.Iconize.Iconize.With(new Plugin.Iconize.Fonts.EntypoPlusModule())
                                  .With(new Plugin.Iconize.Fonts.FontAwesomeModule())
                                  .With(new Plugin.Iconize.Fonts.IoniconsModule())
                                  .With(new Plugin.Iconize.Fonts.MaterialModule())
                                  .With(new Plugin.Iconize.Fonts.MeteoconsModule())
                                  .With(new Plugin.Iconize.Fonts.SimpleLineIconsModule())
                                  .With(new Plugin.Iconize.Fonts.TypiconsModule())
                                  .With(new Plugin.Iconize.Fonts.WeatherIconsModule());

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
