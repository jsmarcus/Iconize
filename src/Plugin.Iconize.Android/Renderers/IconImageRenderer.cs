using System;
using System.ComponentModel;
using Plugin.Iconize;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using ImageRenderer = Xamarin.Forms.Platform.Android.FastRenderers.ImageRenderer;

[assembly: ExportRenderer(typeof(IconImage), typeof(IconImageRenderer))]
namespace Plugin.Iconize
{
    /// <summary>
    /// Defines the <see cref="IconImageRenderer" /> renderer.
    /// </summary>
    /// <seealso cref="Xamarin.Forms.Platform.Android.FastRenderers.ImageRenderer" />
    public class IconImageRenderer : ImageRenderer
    {
        #region Properties

        /// <summary>
        /// Gets the image.
        /// </summary>
        /// <value>
        /// The image.
        /// </value>
        private IconImage Image { get; set; }

        #endregion Properties

        /// <summary>
        /// Raises the <see cref="E:ElementChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="ElementChangedEventArgs{Image}" /> instance containing the event data.</param>
        protected override void OnElementChanged(ElementChangedEventArgs<Image> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement == null)
                return;

            Image = e.NewElement as IconImage;

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

            if (Image == null)
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
            if (icon == null)
            {
                SetImageResource(Android.Resource.Color.Transparent);
                return;
            }

            var iconSize = (Image.IconSize == IconImage.AutoSize ? Math.Max(Image.WidthRequest, Image.HeightRequest) : Image.IconSize);

            var drawable = new IconDrawable(Context, icon).Color(Image.IconColor.ToAndroid())
                                                          .SizeDp((Int32)iconSize);
            SetScaleType(Image.IconSize > 0 ? ScaleType.Center : ScaleType.FitCenter);
            SetImageDrawable(drawable);
        }
    }
}