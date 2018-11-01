using Android.Content;
using Android.Support.Design.Widget;
using Android.Support.V4.Graphics.Drawable;
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
        protected override void SetTabIcon(TabLayout.Tab tab, FileImageSource icon)
        {
            var iconize = Iconize.FindIconForKey(icon.File);
            if (!(iconize is null))
            {
                var drawable = new IconDrawable(Context, icon).SizeDp(20);
                DrawableCompat.SetTintList(drawable, GetItemIconTintColorState());
                tab.SetIcon(drawable);
                return;
            }

            base.SetTabIcon(tab, icon);
        }
    }
}