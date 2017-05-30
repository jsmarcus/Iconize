using System;
using System.Collections.Generic;
using Plugin.Iconize;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(IconTabbedPage), typeof(IconTabbedPageRenderer))]
namespace Plugin.Iconize
{
    /// <summary>
    /// Defines the <see cref="IconTabbedPageRenderer" /> renderer.
    /// </summary>
    /// <seealso cref="Xamarin.Forms.Platform.iOS.TabbedRenderer" />
    public class IconTabbedPageRenderer : TabbedRenderer
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
        /// Called prior to the <see cref="P:UIKit.UIViewController.View" /> being added to the view hierarchy.
        /// </summary>
        /// <param name="animated">If the appearance will be animated.</param>
        /// <remarks>
        /// <para>This method is called prior to the <see cref="T:UIKit.UIView" /> that is this <see cref="T:UIKit.UIViewController" />’s <see cref="P:UIKit.UIViewController.View" /> property being added to the display <see cref="T:UIKit.UIView" /> hierarchy. </para>
        /// <para>Application developers who override this method must call <c>base.ViewWillAppear()</c> in their overridden method.</para>
        /// </remarks>
        public override void ViewWillAppear(Boolean animated)
        {
            base.ViewWillAppear(animated);

            foreach (var tab in TabBar.Items)
            {
                var icon = Iconize.FindIconForKey(_icons?[(Int32)tab.Tag]);
                if (icon == null)
                    continue;

                using (var image = icon.ToUIImage(25f))
                {
                    tab.Image = image;
                    tab.SelectedImage = image;
                }
            }
        }
    }
}