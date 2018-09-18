using System;
using System.Reflection;
using System.Threading.Tasks;
using Plugin.Iconize;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;

[assembly: ExportRenderer(typeof(IconNavigationPage), typeof(IconNavigationPageRenderer))]
namespace Plugin.Iconize
{
    /// <summary>
    /// Defines the <see cref="IconNavigationPage" /> renderer.
    /// </summary>
    /// <seealso cref="Xamarin.Forms.Platform.UWP.NavigationPageRenderer" />
    public class IconNavigationPageRenderer : NavigationPageRenderer
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IconNavigationPageRenderer"/> class.
        /// </summary>
        public IconNavigationPageRenderer()
        {
            MessagingCenter.Subscribe<Object>(this, IconToolbarItem.UpdateToolbarItemsMessage, OnUpdateToolbarItems);
            ElementChanged += OnElementChanged;
        }

        /// <summary>
        /// Called when [element changed].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="VisualElementChangedEventArgs"/> instance containing the event data.</param>
        private void OnElementChanged(Object sender, VisualElementChangedEventArgs e)
        {
            ContainerElement.Loaded += OnContainerLoaded;
            ContainerElement.Unloaded += OnContainerUnloaded;
        }

        /// <summary>
        /// Called when [container unloaded].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void OnContainerUnloaded(Object sender, RoutedEventArgs e)
        {
            ContainerElement.Unloaded -= OnContainerUnloaded;
            ContainerElement.Loaded -= OnContainerLoaded;
        }

        /// <summary>
        /// Called when [container loaded].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void OnContainerLoaded(Object sender, RoutedEventArgs e)
        {
            MessagingCenter.Send(sender, IconToolbarItem.UpdateToolbarItemsMessage);
        }

        /// <summary>
        /// Called when [update toolbar items].
        /// </summary>
        private async void UpdateToolbarItems()
        {
            var platform = Element.Platform;
            FieldInfo fInfo = typeof(Platform).GetField("_container", BindingFlags.NonPublic | BindingFlags.Instance);
            Canvas canvas = fInfo.GetValue(platform) as Canvas;
            if (canvas?.Children?[0] is MasterDetailControl masterDetailControl)
            {
                var mInfo = typeof(MasterDetailControl).GetTypeInfo().GetDeclaredMethod("Xamarin.Forms.Platform.UWP.IToolbarProvider.GetCommandBarAsync");
                var commandBar = await (mInfo.Invoke(masterDetailControl, new Object[] { }) as Task<CommandBar>);
                commandBar.UpdateToolbarItems();
            }
        }

        /// <summary>
        /// Called when [update toolbar items].
        /// </summary>
        /// <param name="sender">The sender.</param>
        private async void OnUpdateToolbarItems(Object sender)
        {
            if (Element == null)
                return;

            // a workaround for MasterDetailPage
            if (Element.Parent is MasterDetailPage)
            {
                var ms = Element.Parent as MasterDetailPage;
                ms.IsPresentedChanged += (s, e) => UpdateToolbarItems();
                UpdateToolbarItems();
            }

            var method = typeof(NavigationPageRenderer).GetTypeInfo().GetDeclaredMethod("Xamarin.Forms.Platform.UWP.IToolbarProvider.GetCommandBarAsync");
            var bar = await (method.Invoke(this, new Object[] { }) as Task<CommandBar>);
            bar.UpdateToolbarItems();
        }
    }
}
