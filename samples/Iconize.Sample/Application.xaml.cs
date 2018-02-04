using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Iconize;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Iconize.Sample
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Application : Xamarin.Forms.Application
	{
		public Application ()
		{
			InitializeComponent ();
			Plugin.Iconize.Iconize.With(new Plugin.Iconize.Fonts.FontAwesomeRegularModule())
				.With(new Plugin.Iconize.Fonts.FontAwesomeBrandsModule())
				.With(new Plugin.Iconize.Fonts.FontAwesomeSolidModule())
				.With(new Plugin.Iconize.Fonts.EntypoPlusModule())
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