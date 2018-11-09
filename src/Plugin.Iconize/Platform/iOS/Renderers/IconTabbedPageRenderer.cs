using System;
using System.Threading.Tasks;
using Plugin.Iconize;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(IconTabbedPage), typeof(IconTabbedPageRenderer))]
namespace Plugin.Iconize
{
    /// <summary>
    /// Defines the <see cref="IconTabbedPage" /> renderer.
    /// </summary>
    /// <seealso cref="Xamarin.Forms.Platform.iOS.TabbedRenderer" />
    public class IconTabbedPageRenderer : TabbedRenderer
    {
        /// <inheritdoc />
        protected override Task<Tuple<UIImage, UIImage>> GetIcon(Page page)
        {
            if (!(page.Icon is null) && !(page.Icon.File is null))
            {
                var icon = Iconize.FindIconForKey(page.Icon.File);

                if (!(icon is null))
                {
                    return Task.FromResult(Tuple.Create(icon.ToUIImage(25f), (UIImage)null));
                }
            }

            return base.GetIcon(page);
        }
    }
}