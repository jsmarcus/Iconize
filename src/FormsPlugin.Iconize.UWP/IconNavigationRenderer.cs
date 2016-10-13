using FormsPlugin.Iconize;
using FormsPlugin.Iconize.UWP;
using Xamarin.Forms.Platform.UWP;

[assembly: ExportRenderer(typeof(IconNavigationPage), typeof(IconNavigationRenderer))]
namespace FormsPlugin.Iconize.UWP
{
    /// <summary>
    /// Defines the <see cref="IconNavigationRenderer" /> renderer.
    /// </summary>
    /// <seealso cref="Xamarin.Forms.Platform.UWP.NavigationPageRenderer" />
    public class IconNavigationRenderer : NavigationPageRenderer
    {

    }
}