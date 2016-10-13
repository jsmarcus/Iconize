using System;
using Windows.UI.Xaml.Media;

namespace FormsPlugin.Iconize.UWP
{
    /// <summary>
    /// Defines the <see cref="ColorExtensions" /> extensions.
    /// </summary>
    public static class ColorExtensions
    {
        /// <summary>
        /// To the color of the windows.
        /// </summary>
        /// <param name="color">The color.</param>
        /// <returns></returns>
        public static Windows.UI.Color ToWindowsColor(this Xamarin.Forms.Color color)
        {
            return Windows.UI.Color.FromArgb((Byte)(color.A * Byte.MaxValue), (Byte)(color.R * Byte.MaxValue), (Byte)(color.G * Byte.MaxValue), (Byte)(color.B * Byte.MaxValue));
        }

        /// <summary>
        /// To the brush.
        /// </summary>
        /// <param name="color">The color.</param>
        /// <returns></returns>
        public static Brush ToBrush(this Xamarin.Forms.Color color)
        {
            return new SolidColorBrush(color.ToWindowsColor());
        }
    }
}