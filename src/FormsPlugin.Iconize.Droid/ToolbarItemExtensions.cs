using System;
using Android.Content;
using Android.Graphics.Drawables;
using Android.Support.V7.Widget;
using Android.Views;
using Plugin.Iconize.Droid;
using Plugin.Iconize.Droid.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

namespace FormsPlugin.Iconize.Droid
{
    /// <summary>
    /// Defines the <see cref="ToolbarItemExtensions" /> extensions.
    /// </summary>
    public static class ToolbarItemExtensions
    {
        /// <summary>
        /// Gets the toolbar item drawable.
        /// </summary>
        /// <param name="toolbarItem">The toolbar item.</param>
        /// <param name="context">The context.</param>
        /// <returns></returns>
        private static Drawable GetToolbarItemDrawable(this ToolbarItem toolbarItem, Context context)
        {
            if (String.IsNullOrWhiteSpace(toolbarItem.Icon))
                return null;

            var iconItem = toolbarItem as IconToolbarItem;
            if (iconItem == null)
                return context.Resources.GetDrawable(toolbarItem.Icon);

            var drawable = new IconDrawable(context, iconItem.Icon);
            if (drawable == null)
                return null;

            if (iconItem.IconColor != Color.Default)
                drawable = drawable.Color(iconItem.IconColor.ToAndroid());

            return drawable.ActionBarSize();
        }

        /// <summary>
        /// Updates the toolbar items.
        /// </summary>
        /// <param name="page">The page.</param>
        /// <param name="view">The view.</param>
        public static void UpdateToolbarItems(this Page page, Android.Views.View view)
        {
            var toolbar = view.FindViewById<Toolbar>(IconControls.ToolbarId);
            if (toolbar == null)
                return;

            toolbar.Menu.Clear();

            var toolbarItems = page.GetToolbarItems();
            if (toolbarItems == null)
                return;

            foreach (var toolbarItem in toolbarItems)
            {
                if (((toolbarItem as IconToolbarItem)?.IsVisible ?? true) == false)
                    continue;

                var menuItem = toolbar.Menu.Add(toolbarItem.Text);
                menuItem.SetOnMenuItemClickListener(new MenuClickListener(toolbarItem.Activate));

                var icon = toolbarItem.GetToolbarItemDrawable(toolbar.Context);
                if (icon != null)
                    menuItem.SetIcon(icon);

                if (toolbarItem.Order != ToolbarItemOrder.Secondary)
                    menuItem.SetShowAsAction(ShowAsAction.Always);
            }
        }
    }
}