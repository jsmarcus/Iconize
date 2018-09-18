using Android.Content;
using Android.Support.Design.Widget;
using Plugin.Iconize;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms.Platform.Android.AppCompat;

[assembly: ExportRenderer(typeof(IconTabbedPage), typeof(IconTabbedPageRenderer))]
namespace Plugin.Iconize
{
    /// <summary>
    /// Defines the <see cref="IconTabbedPage" /> renderer.
    /// </summary>
    /// <seealso cref="Xamarin.Forms.Platform.Android.AppCompat.TabbedPageRenderer" />
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
            if (iconize != null)
            {
                tab.SetIcon(new IconDrawable(Context, icon).Color(Color.White.ToAndroid()).SizeDp(20));
                return;
            }

            base.SetTabIcon(tab, icon);
        }
    }
}