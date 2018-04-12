using System;
using System.ComponentModel;
using System.Threading.Tasks;
using Plugin.Iconize;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;

[assembly: ExportRenderer(typeof(IconImage), typeof(IconImageRenderer))]
namespace Plugin.Iconize
{
    /// <summary>
    /// Defines the <see cref="IconImage" /> renderer.
    /// </summary>
    /// <seealso cref="Xamarin.Forms.Platform.UWP.ImageRenderer" />
    public class IconImageRenderer : ImageRenderer
    {
        #region Properties

        private IconImage Image => Element as IconImage;

        #endregion Properties

        /// <summary>
        /// Raises the <see cref="E:ElementChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="ElementChangedEventArgs{Image}" /> instance containing the event data.</param>
        protected override async void OnElementChanged(ElementChangedEventArgs<Image> e)
        {
            base.OnElementChanged(e);

            if (Control == null || Image == null)
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

            if (Control == null || Image == null)
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
            var icon = Iconize.FindIconForKey(Image.Icon);
            if (icon != null)
            {
                var iconSize = (Image.IconSize == IconImage.AutoSize ? Math.Max(Element.WidthRequest, Element.HeightRequest) : Image.IconSize);

                Control.Source = await icon.ToImageSourceAsync((Int32)iconSize, Image.IconColor);
            }
        }
    }
}