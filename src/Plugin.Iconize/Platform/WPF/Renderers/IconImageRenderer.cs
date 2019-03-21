using System;
using System.ComponentModel;
using Plugin.Iconize;
using Xamarin.Forms;
using Xamarin.Forms.Platform.WPF;

[assembly: ExportRenderer(typeof(IconImage), typeof(IconImageRenderer))]
namespace Plugin.Iconize
{
    /// <summary>
    /// Defines the <see cref="IconImage" /> renderer.
    /// </summary>
    /// <seealso cref="Xamarin.Forms.Platform.WPF.ImageRenderer" />
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

            if (Control is null || Image is null)
                return;

            UpdateImage();
        }

        /// <summary>
        /// Called when [element property changed].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="PropertyChangedEventArgs" /> instance containing the event data.</param>
        protected override void OnElementPropertyChanged(Object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (Control is null || Image is null)
                return;

            switch (e.PropertyName)
            {
                case nameof(IconImage.Icon):
                case nameof(IconImage.IconColor):
                case nameof(IconImage.IconSize):
                    UpdateImage();
                    break;
            }
        }

        /// <summary>
        /// Updates the image.
        /// </summary>
        private void UpdateImage()
        {
            var icon = Iconize.FindIconForKey(Image.Icon);
            if (!(icon is null))
            {
                Control.Source = icon.ToImageSource(Image.IconColor);
            }
        }
    }
}