using System;
using System.ComponentModel;
using Android.Widget;
using FormsPlugin.Iconize;
using FormsPlugin.Iconize.Droid;
using Plugin.Iconize.Droid.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(IconImage), typeof(IconImageRenderer))]
namespace FormsPlugin.Iconize.Droid
{
    /// <summary>
    /// Defines the <see cref="IconImageRenderer" /> renderer.
    /// </summary>
    /// <seealso cref="Xamarin.Forms.Platform.Android.ImageRenderer" />
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

            if (Control == null || Element == null)
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
            var iconImage = Element as IconImage;

            var icon = Plugin.Iconize.Iconize.FindIconForKey(iconImage.Icon);
            if (icon == null)
            {
                Control.SetImageResource(Android.Resource.Color.Transparent);
                return;
            }

            var drawable = new IconDrawable(Context, icon).Color(iconImage.IconColor.ToAndroid())
                                                          .SizeDp(iconImage.IconSize > 0 ? (Int32)iconImage.IconSize : (Int32)Element.HeightRequest);
            Control.SetScaleType(iconImage.IconSize > 0 ? ImageView.ScaleType.Center : ImageView.ScaleType.FitCenter);
            Control.SetImageDrawable(drawable);
        }
    }
}