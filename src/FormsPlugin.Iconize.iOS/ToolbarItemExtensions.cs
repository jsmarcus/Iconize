using System;
using System.Collections.Generic;
using Plugin.Iconize.iOS;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

namespace FormsPlugin.Iconize.iOS
{
    /// <summary>
    /// Defines the <see cref="ToolbarItemExtensions" /> extensions.
    /// </summary>
    public static class ToolbarItemExtensions
    {
        /// <summary>
        /// Updates the toolbar items.
        /// </summary>
        /// <param name="page">The page.</param>
        /// <param name="controller">The controller.</param>
        public static void UpdateToolbarItems(this Page page, UINavigationController controller)
        {
            try
            {
                if (page == null || controller == null)
                    return;

                if (controller.IsBeingDismissed == true)
                    return;

                var navController = controller.VisibleViewController;
                if (navController == null)
                    return;

                if (navController.NavigationItem?.RightBarButtonItems != null)
                {
                    for (var i = 0; i < navController.NavigationItem.RightBarButtonItems.Length; ++i)
                        navController.NavigationItem.RightBarButtonItems[i].Dispose();
                }

                if (navController.ToolbarItems != null)
                {
                    for (var i = 0; i < navController.ToolbarItems.Length; ++i)
                        navController.ToolbarItems[i].Dispose();
                }

                var toolbarItems = page.GetToolbarItems();
                if (toolbarItems == null)
                    return;

                List<UIBarButtonItem> primaries = null;
                List<UIBarButtonItem> secondaries = null;

                foreach (var toolbarItem in toolbarItems)
                {
                    var barButtonItem = toolbarItem.ToUIBarButtonItem(toolbarItem.Order == ToolbarItemOrder.Secondary);
                    if (toolbarItem is IconToolbarItem)
                    {
                        var iconItem = (IconToolbarItem)toolbarItem;
                        if (iconItem.IsVisible == false)
                            continue;

                        var icon = Plugin.Iconize.Iconize.FindIconForKey(iconItem.Icon);
                        if (icon != null)
                        {
                            using (var image = icon.ToUIImage(22))
                            {
                                barButtonItem.Image = image;
                                if (iconItem.IconColor != Color.Default)
                                    barButtonItem.TintColor = iconItem.IconColor.ToUIColor();
                            }
                        }
                    }

                    if (toolbarItem.Order == ToolbarItemOrder.Secondary)
                        (secondaries = secondaries ?? new List<UIBarButtonItem>()).Add(barButtonItem);
                    else
                        (primaries = primaries ?? new List<UIBarButtonItem>()).Add(barButtonItem);
                }

                if (primaries != null)
                    primaries.Reverse();

                navController.NavigationItem.SetRightBarButtonItems(primaries == null ? new UIBarButtonItem[0] : primaries.ToArray(), false);
                navController.ToolbarItems = (secondaries == null ? new UIBarButtonItem[0] : secondaries.ToArray());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}