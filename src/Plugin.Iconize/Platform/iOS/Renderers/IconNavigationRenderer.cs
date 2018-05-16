using System;
using Plugin.Iconize;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(IconNavigationPage), typeof(IconNavigationRenderer))]
namespace Plugin.Iconize
{
    /// <summary>
    /// Defines the <see cref="IconNavigationPage" /> renderer.
    /// </summary>
    /// <seealso cref="Xamarin.Forms.Platform.iOS.NavigationRenderer" />
    public class IconNavigationRenderer : NavigationRenderer
    {
        /// <summary>
        /// Views the will appear.
        /// </summary>
        /// <param name="animated">if set to <c>true</c> [animated].</param>
        public override void ViewWillAppear(Boolean animated)
        {
            base.ViewWillAppear(animated);

            MessagingCenter.Subscribe<Object>(this, IconToolbarItem.UpdateToolbarItemsMessage, OnUpdateToolbarItems);
            OnUpdateToolbarItems(this);
        }

        /// <summary>
        /// Views the will disappear.
        /// </summary>
        /// <param name="animated">if set to <c>true</c> [animated].</param>
        public override void ViewWillDisappear(Boolean animated)
        {
            MessagingCenter.Unsubscribe<Object>(this, IconToolbarItem.UpdateToolbarItemsMessage);

            base.ViewWillDisappear(animated);
        }

        /// <summary>
        /// Called when [update toolbar items].
        /// </summary>
        /// <param name="sender">The sender.</param>
        private void OnUpdateToolbarItems(Object sender)
        {
            (Element as NavigationPage)?.UpdateToolbarItems(this);
        }
    }
}