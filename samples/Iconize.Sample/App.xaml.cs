using System;
using System.Linq;
using Plugin.Iconize;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Xamarin.Forms.Xaml;

namespace Iconize.Sample
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Xamarin.Forms.Application" />
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class App : Xamarin.Forms.Application
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="App"/> class.
        /// </summary>
        public App()
        {
            InitializeComponent();

            Plugin.Iconize.Iconize
                .With(new Plugin.Iconize.Fonts.EntypoPlusModule())
                .With(new Plugin.Iconize.Fonts.FontAwesomeRegularModule())
                .With(new Plugin.Iconize.Fonts.FontAwesomeBrandsModule())
                .With(new Plugin.Iconize.Fonts.FontAwesomeSolidModule())
                .With(new Plugin.Iconize.Fonts.IoniconsModule())
                .With(new Plugin.Iconize.Fonts.JamIconsModule())
                .With(new Plugin.Iconize.Fonts.MaterialModule())
                .With(new Plugin.Iconize.Fonts.MeteoconsModule())
                .With(new Plugin.Iconize.Fonts.SimpleLineIconsModule())
                .With(new Plugin.Iconize.Fonts.TypiconsModule())
                .With(new Plugin.Iconize.Fonts.WeatherIconsModule());

            // The root page of your application
            var tabbedPage = new IconTabbedPage { Title = "Iconize" };
            tabbedPage.On<Xamarin.Forms.PlatformConfiguration.Android>().SetBarItemColor(Xamarin.Forms.Color.Yellow);
            tabbedPage.On<Xamarin.Forms.PlatformConfiguration.Android>().SetBarSelectedItemColor(Xamarin.Forms.Color.Black);
            tabbedPage.On<Xamarin.Forms.PlatformConfiguration.Android>().SetToolbarPlacement(ToolbarPlacement.Bottom);

            for (int i = 0; i < Math.Min(Plugin.Iconize.Iconize.Modules.Count, 5); i++)
            {
                var module = Plugin.Iconize.Iconize.Modules[i];
                var bc = new ModuleWrapper(module);
                var icon = module.Keys.FirstOrDefault();
                tabbedPage.Children.Add(new Page1
                {
                    BindingContext = bc,
                    Icon = icon
                });
            }

            //foreach (var module in Plugin.Iconize.Iconize.Modules)
            //{
            //    var bc = new ModuleWrapper(module);
            //    var icon = module.Keys.FirstOrDefault();
            //    tabbedPage.Children.Add(new Page1
            //    {
            //        BindingContext = bc,
            //        Icon = icon
            //    });
            //}

            MainPage = new IconNavigationPage(tabbedPage);
        }
    }
}