using System;
using System.ComponentModel;
using System.Threading.Tasks;
using FormsPlugin.Iconize;
using FormsPlugin.Iconize.UWP;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;

[assembly: ExportRenderer(typeof(IconImage), typeof(IconImageRenderer))]
namespace FormsPlugin.Iconize.UWP
{
    /// <summary>
    /// Defines the <see cref="IconImageRenderer" /> renderer.
    /// </summary>
    /// <seealso cref="Xamarin.Forms.Platform.UWP.ImageRenderer" />
    public class IconImageRenderer : ImageRenderer
    {
        /// <summary>
        /// Raises the <see cref="E:ElementChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="ElementChangedEventArgs{Image}" /> instance containing the event data.</param>
        protected override async void OnElementChanged(ElementChangedEventArgs<Image> e)
        {
            base.OnElementChanged(e);

            if (Control == null || Element == null)
                return;

            await UpdateImageAsync();
        }

        /// <summary>
        /// Called when [element property changed].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="PropertyChangedEventArgs" /> instance containing the event data.</param>
        protected override async void OnElementPropertyChanged(Object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (Control == null || Element == null)
                return;

            switch (e.PropertyName)
            {
                case nameof(IconImage.Icon):
                case nameof(IconImage.IconColor):
                case nameof(IconImage.IconSize):
                    await UpdateImageAsync();
                    break;
            }
        }

        /// <summary>
        /// Updates the image.
        /// </summary>
        private async Task UpdateImageAsync()
        {
            //var iconImage = Element as IconImage;
            //Control.Source = await Plugin.Iconize.Iconize.FindIconForKey(iconImage.Icon).ToImageSourceAsync(Element.HeightRequest, iconImage.IconColor.ToWindowsColor());
        }
    }
}