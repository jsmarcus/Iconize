using System;
using System.ComponentModel;
using FormsPlugin.Iconize;
using FormsPlugin.Iconize.iOS;
using Plugin.Iconize.iOS;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(IconImage), typeof(IconImageRenderer))]
namespace FormsPlugin.Iconize.iOS
{
    /// <summary>
    /// Defines the <see cref="IconImageRenderer" /> renderer.
    /// </summary>
    /// <seealso cref="Xamarin.Forms.Platform.iOS.ImageRenderer" />
    public class IconImageRenderer : ImageRenderer
    {
        /// <summary>
        /// Raises the <see cref="E:ElementChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="ElementChangedEventArgs{Image}" /> instance containing the event data.</param>
        protected override void OnElementChanged(ElementChangedEventArgs<Image> e)
        {
            base.OnElementChanged(e);

            if (Control == null || Element == null)
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

            if (Control == null || Element == null)
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
            var iconImage = Element as IconImage;

            if (shouldUpdateImage)
            {
                Control.ContentMode = iconImage.IconSize > 0 ? UIViewContentMode.Center : UIViewContentMode.ScaleAspectFit;

                var icon = Plugin.Iconize.Iconize.FindIconForKey(iconImage.Icon);
                if (icon == null)
                {
                    Control.Image = null;
                    return;
                }

                var iconSize = (iconImage.IconSize > 0 ? (nfloat)iconImage.IconSize : (nfloat)Element.HeightRequest);

                using (var image = icon.ToUIImage(iconSize))
                {
                    Control.Image = image;
                }
            }

            Control.TintColor = iconImage.IconColor.ToUIColor();
        }
    }
}
