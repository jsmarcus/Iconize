using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using SkiaSharp;
using Windows.ApplicationModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Xamarin.Forms;

namespace Plugin.Iconize
{
    /// <summary>
    /// Defines the <see cref="Platform" /> extensions.
    /// </summary>
    public static class PlatformExtensions
    {
        private static IDictionary<Type, FontFamily> FontCache { get; } = new Dictionary<Type, FontFamily>();

        /// <summary>
        /// To the font family.
        /// </summary>
        /// <param name="module">The module.</param>
        /// <returns></returns>
        public static FontFamily ToFontFamily(this IIconModule module)
        {
            var moduleType = module.GetType();
            if (FontCache.ContainsKey(moduleType) == false)
            {
                FontCache.Add(moduleType, new FontFamily($"ms-appx:///{moduleType.GetTypeInfo().Assembly.GetName().Name}/{module.FontPath}#{module.FontFamily}"));
            }
            return FontCache[moduleType];
        }

        /// <summary>
        /// To the image source.
        /// </summary>
        /// <param name="icon">The icon.</param>
        /// <param name="size">The size.</param>
        /// <param name="color">The color.</param>
        /// <returns></returns>
        public static async Task<Windows.UI.Xaml.Media.ImageSource> ToImageSourceAsync(this IIcon icon, Int32 size, Color color)
        {
            var character = $"{icon.Character}";
            var module = Iconize.FindModuleOf(icon);

            using (var surface = SKSurface.Create(size, size, SKImageInfo.PlatformColorType, SKAlphaType.Premul))
            {
                using (var paint = new SKPaint())
                {
                    using (var typeface = SKTypeface.FromFile(Path.Combine(Package.Current.InstalledLocation.Path, module.GetType().GetTypeInfo().Assembly.GetName().Name, module.FontPath)))
                    {
                        paint.Color = color.ToSKColor();
                        paint.IsAntialias = true;
                        paint.Typeface = typeface;

                        // Adjust TextSize property so text is 90% of size
                        var textWidth = paint.MeasureText(character);
                        paint.TextSize = 0.9f * size * paint.TextSize / textWidth;

                        // Find the text bounds
                        var textBounds = new SKRect();
                        paint.MeasureText(character, ref textBounds);

                        // Calculate offsets to center the text
                        var xText = size / 2 - textBounds.MidX;
                        var yText = size / 2 - textBounds.MidY;

                        // And draw the text
                        surface.Canvas.DrawText(character, xText, yText, paint);
                    }
                }

                var bitmap = new BitmapImage();
                await bitmap.SetSourceAsync(surface.Snapshot().Encode().AsStream().AsRandomAccessStream());
                return bitmap;
            }
        }

        /// <summary>
        /// To the color of the windows.
        /// </summary>
        /// <param name="color">The color.</param>
        /// <returns></returns>
        public static SKColor ToSKColor(this Color color) => new SKColor((Byte)(color.R * Byte.MaxValue), (Byte)(color.G * Byte.MaxValue), (Byte)(color.B * Byte.MaxValue), (Byte)(color.A * Byte.MaxValue));

        /// <summary>
        /// To the color of the UI.
        /// </summary>
        /// <param name="color">The color.</param>
        /// <returns></returns>
        public static Windows.UI.Color ToUIColor(this Color color) => Windows.UI.Color.FromArgb((Byte)(color.A * Byte.MaxValue), (Byte)(color.R * Byte.MaxValue), (Byte)(color.G * Byte.MaxValue), (Byte)(color.B * Byte.MaxValue));

        /// <summary>
        /// Updates the button icon.
        /// </summary>
        /// <param name="button">The button.</param>
        private static void UpdateButtonIcon(AppBarButton button)
        {
            if (button?.DataContext is IconToolbarItem item)
            {
                var icon = Iconize.FindIconForKey(item.Icon);
                if (icon != null)
                {
                    button.ClearValue(AppBarButton.IconProperty);
                    button.Icon = new FontIcon
                    {
                        FontFamily = Iconize.FindModuleOf(icon).ToFontFamily(),
                        Glyph = $"{icon.Character}"
                    };
                    if (item.IconColor != default(Color))
                    {
                        button.Icon.Foreground = new SolidColorBrush(item.IconColor.ToUIColor());
                    }
                    button.Visibility = item.IsVisible ? Visibility.Visible : Visibility.Collapsed;
                }
            }
        }

        /// <summary>
        /// Updates the toolbar items.
        /// </summary>
        /// <param name="page">The page.</param>
        public static void UpdateToolbarItems(this CommandBar bar)
        {
            if (bar == null)
                return;

            foreach (var button in bar.PrimaryCommands)
            {
                UpdateButtonIcon(button as AppBarButton);
            }

            foreach (var button in bar.SecondaryCommands)
            {
                UpdateButtonIcon(button as AppBarButton);
            }
        }
    }
}
