using System;
using System.Collections.Generic;
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
    /// Defines the <see cref="IconTabbedPageRenderer" /> renderer.
    /// </summary>
    /// <seealso cref="Xamarin.Forms.Platform.Android.AppCompat.TabbedPageRenderer" />
    public class IconTabbedPageRenderer : TabbedPageRenderer
    {
        private readonly List<String> _icons = new List<String>();

	    /// <summary>
	    /// 
	    /// </summary>
	    /// <param name="context"></param>
	    public IconTabbedPageRenderer(Context context):base(context)
	    {
	    }

		
        /// <summary>
        /// Called when [attached to window].
        /// </summary>
        protected override void OnAttachedToWindow()
        {
            UpdateTabbedIcons(Context);

            base.OnAttachedToWindow();
        }

        /// <summary>
        /// Raises the <see cref="E:ElementChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="ElementChangedEventArgs{TabbedPage}" /> instance containing the event data.</param>
        protected override void OnElementChanged(ElementChangedEventArgs<TabbedPage> e)
        {
            _icons.Clear();
            if (e.NewElement != null)
            {
                foreach (var page in e.NewElement.Children)
                {
                    if (page.Icon != null)
                    {
                        _icons.Add(page.Icon.File);
                        page.Icon = null;
                    }
                }
            }

            base.OnElementChanged(e);
        }

        /// <summary>
        /// Updates the tabbed icons.
        /// </summary>
        private void UpdateTabbedIcons(Context context)
        {
            var tabLayout = FindViewById<TabLayout>(Iconize.TabLayoutId);
            if (tabLayout == null || tabLayout.TabCount == 0)
                return;

            for (var i = 0; i < tabLayout.TabCount; i++)
            {
                var tab = tabLayout.GetTabAt(i);

                if (_icons != null && i < _icons.Count)
                {
                    var iconKey = _icons[i];

                    var icon = Iconize.FindIconForKey(iconKey);
                    if (icon == null)
                        continue;

                    var drawable = new IconDrawable(context, icon).Color(Color.White.ToAndroid()).SizeDp(20);

                    tab.SetIcon(drawable);
                }
            }
        }
    }
}