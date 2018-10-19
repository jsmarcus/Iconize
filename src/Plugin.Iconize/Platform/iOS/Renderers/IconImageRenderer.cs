using System;
using System.ComponentModel;
using Plugin.Iconize;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(IconImage), typeof(IconImageRenderer))]
namespace Plugin.Iconize
{
    /// <summary>
    /// Defines the <see cref="IconImage" /> renderer.
    /// </summary>
    /// <seealso cref="Xamarin.Forms.Platform.iOS.ImageRenderer" />
    public class IconImageRenderer : ImageRenderer
    {
        #region Properties

        private IconImage Image => Element as IconImage;

        #endregion Properties

        /// <summary>
        /// Raises the <see cref="E:ElementChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="ElementChangedEventArgs{Image}" /> instance containing the event data.</param>
        protected override void OnElementChanged(ElementChangedEventArgs<Image> e)
        {
            base.OnElementChanged(e);

            if (Control is null || Element is null)
                return;

            UpdateImage(true);
        }

        /// <summary>
        /// Called when [element property changed].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="PropertyChangedEventArgs" /> instance containing the event data.</param>
        protected override void OnElementPropertyChanged(Object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (Control is null || Element is null)
                return;

            switch (e.PropertyName)
            {
                case nameof(IconImage.Icon):
                case nameof(IconImage.IconSize):
                    UpdateImage(true);
                    break;

                case nameof(IconImage.IconColor):
                    UpdateImage(false);
                    break;
            }
        }

        /// <summary>
        /// Updates the image.
        /// </summary>
        /// <param name="shouldUpdateImage">if set to <c>true</c> [should update image].</param>
        private void UpdateImage(Boolean shouldUpdateImage)
        {
            if (shouldUpdateImage)
            {
                Control.ContentMode = (Image.IconSize == IconImage.AutoSize ? UIViewContentMode.ScaleAspectFit : UIViewContentMode.Center);

                var icon = Iconize.FindIconForKey(Image.Icon);
                if (icon is null)
                {
                    Control.Image = null;
                    return;
                }

                var iconSize = (Image.IconSize == IconImage.AutoSize ? Math.Max(Element.WidthRequest, Element.HeightRequest) : Image.IconSize);

                using (var image = icon.ToUIImage((nfloat)iconSize))
                {
                    Control.Image = image;
                }
            }

            Control.TintColor = Image.IconColor.ToUIColor();
        }
    }
}
