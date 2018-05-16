using System.Linq;
using Plugin.Iconize;
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
                .With(new Plugin.Iconize.Fonts.MaterialModule())
                .With(new Plugin.Iconize.Fonts.MeteoconsModule())
                .With(new Plugin.Iconize.Fonts.SimpleLineIconsModule())
                .With(new Plugin.Iconize.Fonts.TypiconsModule())
                .With(new Plugin.Iconize.Fonts.WeatherIconsModule());

            // The root page of your application
            var tabbedPage = new IconTabbedPage { Title = "Iconize" };

            foreach (var module in Plugin.Iconize.Iconize.Modules)
            {
                var bc = new ModuleWrapper(module);
                var icon = module.Keys.FirstOrDefault();
                tabbedPage.Children.Add(new Page1
                {
                    BindingContext = bc,
                    Icon = icon
                });
            }

            MainPage = new IconNavigationPage(tabbedPage);
        }
    }
}