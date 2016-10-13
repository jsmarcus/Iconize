using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace Plugin.Iconize.UWP
{
    /// <summary>
    /// Defines the <see cref="IconizeExtensions" /> extensions.
    /// </summary>
    public static class IconizeExtensions
    {
        private static readonly Dictionary<Type, FontFamily> _fontCache = new Dictionary<Type, FontFamily>();

        /// <summary>
        /// To the font family.
        /// </summary>
        /// <param name="module">The module.</param>
        /// <returns></returns>
        public static FontFamily ToFontFamily(this IIconModule module)
        {
            var moduleType = module.GetType();
            if (_fontCache.ContainsKey(moduleType) == false)
            {
                _fontCache.Add(moduleType, new FontFamily($"ms-appx:///{module.GetType().GetTypeInfo().Assembly.GetName().Name}/{module.FontPath}#{module.FontFamily}"));
            }
            return _fontCache[moduleType];
        }

        /// <summary>
        /// To the image source.
        /// </summary>
        /// <param name="icon">The icon.</param>
        /// <param name="size">The size.</param>
        /// <param name="color">The color.</param>
        /// <returns></returns>
        public static ImageSource ToImageSource(this IIcon icon, Int32 size, Color color)
        {
            //var text = new TextBlock
            //{
            //    FontFamily = Iconize.FindModuleOf(icon).ToFontFamily(),
            //    FontSize = size,
            //    Foreground = new SolidColorBrush(color),
            //    Text = $"{icon.Character}"
            //};
            //    var grid = new Grid();
            //grid.Children.Add(text);

            //var bitmap = BitmapFactory.New(size, size);
            //bitmap.Render(text, null);
            //return bitmap;
            return null;
        }
    }
}
