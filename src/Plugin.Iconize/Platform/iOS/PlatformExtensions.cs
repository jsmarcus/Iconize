using System;
using System.Collections.Generic;
using CoreGraphics;
using CoreText;
using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

namespace Plugin.Iconize
{
    /// <summary>
    /// Defines the <see cref="PlatformExtensions" /> extensions.
    /// </summary>
    public static class PlatformExtensions
    {
        /// <summary>
        /// To the UI font.
        /// </summary>
        /// <param name="module">The module.</param>
        /// <param name="size">The size.</param>
        /// <returns></returns>
        public static UIFont ToUIFont(this IIconModule module, nfloat size) => UIFont.FromName(module.FontName, size);

        /// <summary>
        /// To the UI image.
        /// </summary>
        /// <param name="icon">The icon.</param>
        /// <param name="size">The size.</param>
        /// <returns></returns>
        public static UIImage ToUIImage(this IIcon icon, nfloat size)
        {
            var attributedString = new NSAttributedString($"{icon.Character}", new CTStringAttributes
            {
                Font = new CTFont(Iconize.FindModuleOf(icon).FontName, size),
                ForegroundColorFromContext = true
            });

            var boundSize = attributedString.GetBoundingRect(new CGSize(10000f, 10000f), NSStringDrawingOptions.UsesLineFragmentOrigin, null).Size;

            UIGraphics.BeginImageContextWithOptions(boundSize, false, 0f);
            attributedString.DrawString(new CGRect(0f, 0f, boundSize.Width, boundSize.Height));
            using (var image = UIGraphics.GetImageFromCurrentImageContext())
            {
                UIGraphics.EndImageContext();

                return image.ImageWithRenderingMode(UIImageRenderingMode.AlwaysTemplate);
            }
        }

        /// <summary>
        /// Updates the toolbar items.
        /// </summary>
        /// <param name="page">The page.</param>
        /// <param name="controller">The controller.</param>
        public static void UpdateToolbarItems(this Page page, UINavigationController controller)
        {
            try
            {
                if (page is null || controller is null)
                    return;

                if (controller.IsBeingDismissed)
                    return;

                var navController = controller.VisibleViewController;
                if (navController is null)
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
                if (toolbarItems is null)
                    return;

                List<UIBarButtonItem> primaries = null;
                List<UIBarButtonItem> secondaries = null;

                foreach (var toolbarItem in toolbarItems)
                {
                    var barButtonItem = toolbarItem.ToUIBarButtonItem(toolbarItem.Order == ToolbarItemOrder.Secondary);
                    if (toolbarItem is IconToolbarItem iconItem)
                    {
                        if (!iconItem.IsVisible)
                            continue;

                        var icon = Iconize.FindIconForKey(iconItem.Icon);
                        if (!(icon is null))
                        {
                            using (var image = icon.ToUIImage(22f))
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

                primaries?.Reverse();

                navController.NavigationItem.SetRightBarButtonItems(primaries is null ? new UIBarButtonItem[0] : primaries.ToArray(), false);
                navController.ToolbarItems = (secondaries is null ? new UIBarButtonItem[0] : secondaries.ToArray());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}