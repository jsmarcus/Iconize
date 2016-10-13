using System.Collections.Generic;
using Xamarin.Forms;

namespace FormsPlugin.Iconize
{
    /// <summary>
    /// Defines the <see cref="ToolbarItemExtensions" /> extensions.
    /// </summary>
    public static class ToolbarItemExtensions
    {
        /// <summary>
        /// Gets the toolbar items.
        /// </summary>
        /// <param name="page">The page.</param>
        /// <returns></returns>
        public static IList<ToolbarItem> GetToolbarItems(this Page page)
        {
            var list = new List<ToolbarItem>(page.ToolbarItems);

            if (page is MasterDetailPage)
            {
                var masterDetailPage = (MasterDetailPage)page;
                if (masterDetailPage.IsPresented)
                {
                    if (masterDetailPage.Master != null)
                        list.AddRange(masterDetailPage.Master.GetToolbarItems());
                }
                else if (masterDetailPage.Detail != null)
                {
                    list.AddRange(masterDetailPage.Detail.GetToolbarItems());
                }
            }
            else if (page is IPageContainer<Page>)
            {
                var pageContainer = (IPageContainer<Page>)page;
                if (pageContainer.CurrentPage != null)
                    list.AddRange(pageContainer.CurrentPage.GetToolbarItems());
            }

            return list;
        }

        /// <summary>
        /// Activates the specified menu item.
        /// </summary>
        /// <param name="menuItem">The menu item.</param>
        public static void Activate(this MenuItem menuItem)
        {
            if (menuItem.Command?.CanExecute(menuItem.CommandParameter) ?? false)
                menuItem.Command?.Execute(menuItem.CommandParameter);
        }
    }
}