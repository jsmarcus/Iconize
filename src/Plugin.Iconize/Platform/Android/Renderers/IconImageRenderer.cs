using System;
using System.ComponentModel;
using Android.Content;
using Plugin.Iconize;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
#if USE_FASTRENDERERS
using ImageRenderer = Xamarin.Forms.Platform.Android.FastRenderers.ImageRenderer;
#else
using ScaleType = Android.Widget.ImageView.ScaleType;
using ImageRenderer = Xamarin.Forms.Platform.Android.ImageRenderer;
#endif

[assembly: ExportRenderer(typeof(IconImage), typeof(IconImageRenderer))]

namespace Plugin.Iconize
{
    /// <summary>
    /// Defines the <see cref="IconImage" /> renderer.
    /// </summary>
#if USE_FASTRENDERERS
    /// <seealso cref="Xamarin.Forms.Platform.Android.FastRenderers.ImageRenderer" />
#else
    /// <seealso cref="Xamarin.Forms.Platform.Android.ImageRenderer" />
#endif
    public class IconImageRenderer : ImageRenderer
    {
        /// <summary>
        /// Gets the image.
        /// </summary>
        /// <value>
        /// The image.
        /// </value>
        private IconImage Image { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="IconImageRenderer"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public IconImageRenderer(Context context)
            : base(context)
        {
            // Intentionally left blank
        }

        /// <inheritdoc />
        protected override void OnElementChanged(ElementChangedEventArgs<Image> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement is null)
                return;

            Image = e.NewElement as IconImage;

            UpdateImage();
        }

        /// <inheritdoc />
        protected override void OnElementPropertyChanged(Object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (Image is null)
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

        private void UpdateImage()
        {
            var icon = Iconize.FindIconForKey(Image.Icon);
            if (icon is null)
            {
#if USE_FASTRENDERERS
                SetImageResource(Android.Resource.Color.Transparent);
#else
                Control.SetImageResource(Android.Resource.Color.Transparent);
#endif
                return;
            }

            var iconSize = (Image.IconSize == IconImage.AutoSize ? Math.Max(Image.WidthRequest, Image.HeightRequest) : Image.IconSize);

            var drawable = new IconDrawable(Context, icon).Color(Image.IconColor.ToAndroid())
                                                          .SizeDp((Int32)iconSize);
#if USE_FASTRENDERERS
            SetScaleType(Image.IconSize > 0 ? ScaleType.Center : ScaleType.FitCenter);
            SetImageDrawable(drawable);
#else
            Control.SetScaleType(Image.IconSize > 0 ? ScaleType.Center : ScaleType.FitCenter);
            Control.SetImageDrawable(drawable);
#endif
        }
    }
}