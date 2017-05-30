using System;
using Plugin.Iconize;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;

[assembly: ExportRenderer(typeof(IconTabbedPage), typeof(IconTabbedPageRenderer))]
namespace Plugin.Iconize
{
    /// <summary>
    /// Defines the <see cref="IconTabbedPage" /> renderer.
    /// </summary>
    /// <seealso cref="Xamarin.Forms.Platform.UWP.TabbedPageRenderer" />
    public class IconTabbedPageRenderer : TabbedPageRenderer
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IconTabbedPageRenderer"/> class.
        /// </summary>
        public IconTabbedPageRenderer()
        {
            MessagingCenter.Subscribe<Object>(this, IconToolbarItem.UpdateToolbarItemsMessage, OnUpdateToolbarItems);
        }

        /// <summary>
        /// Called when [update toolbar items].
        /// </summary>
        /// <param name="sender">The sender.</param>
        private async void OnUpdateToolbarItems(Object sender)
        {
            var bar = await GetCommandBarAsync();
            bar.UpdateToolbarItems();
        }
    }
}
