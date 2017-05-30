using System;
using Xamarin.Forms;

namespace Plugin.Iconize
{
    /// <summary>
    /// Defines the <see cref="IconCarouselPage" /> page.
    /// </summary>
    /// <seealso cref="Xamarin.Forms.CarouselPage" />
    public class IconCarouselPage : CarouselPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IconCarouselPage" /> class.
        /// </summary>
        public IconCarouselPage()
        {
            CurrentPageChanged += OnCurrentPageChanged;
        }

        /// <summary>
        /// Called when [current page changed].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void OnCurrentPageChanged(Object sender, EventArgs e)
        {
            MessagingCenter.Send(sender, IconToolbarItem.UpdateToolbarItemsMessage);
        }
    }
}