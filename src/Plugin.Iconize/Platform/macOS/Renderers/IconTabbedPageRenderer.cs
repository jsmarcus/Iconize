using System;
using System.Collections.Generic;
using Plugin.Iconize;
using Xamarin.Forms;
using Xamarin.Forms.Platform.MacOS;

[assembly: ExportRenderer(typeof(IconTabbedPage), typeof(IconTabbedPageRenderer))]

namespace Plugin.Iconize
{
    /// <summary>
    /// Defines the <see cref="IconTabbedPage" /> renderer.
    /// </summary>
    /// <seealso cref="Xamarin.Forms.Platform.MacOS.TabbedPageRenderer" />
    public class IconTabbedPageRenderer : TabbedPageRenderer
    {
        private readonly List<String> _icons = new List<String>();

        /// <summary>
        /// Raises the <see cref="E:ElementChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="VisualElementChangedEventArgs" /> instance containing the event data.</param>
        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            _icons.Clear();
            if (e.NewElement != null)
            {
                foreach (var page in ((TabbedPage)e.NewElement).Children)
                {
                    _icons.Add(page.Icon.File);
                    page.Icon = null;
                }
            }

            base.OnElementChanged(e);
        }

        /// <summary>
        /// Views the will appear.
        /// </summary>
        public override void ViewWillAppear()
        {
            base.ViewWillAppear();

            for (int i = 0; i < TabView.Items.Length; i++)
            {
                var icon = Iconize.FindIconForKey(_icons?[i]);
                if (icon is null)
                    continue;

                using (var image = icon.ToNSImage(18))
                {
                    TabView.Items[i].Image = image;
                }
            }
        }
    }
}
