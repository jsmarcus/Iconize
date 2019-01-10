using Android.Content;
using Android.Graphics.Drawables;
using Plugin.Iconize;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android.AppCompat;

[assembly: ExportRenderer(typeof(IconTabbedPage), typeof(IconTabbedPageRenderer))]

namespace Plugin.Iconize
{
    /// <summary>
    /// Defines the <see cref="IconTabbedPage" /> renderer.
    /// </summary>
    /// <seealso cref="TabbedPageRenderer" />
    public class IconTabbedPageRenderer : TabbedPageRenderer
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IconTabbedPageRenderer"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public IconTabbedPageRenderer(Context context)
            : base(context)
        {
            // Intentionally left blank
        }

        /// <inheritdoc />
        protected override Drawable GetIconDrawable(FileImageSource icon)
        {
            var iconize = Iconize.FindIconForKey(icon.File);

            if (!(iconize is null))
            {
                return new IconDrawable(Context, icon).SizeDp(20);
            }

            return base.GetIconDrawable(icon);
        }
    }
}