using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;

namespace Plugin.Iconize
{
    /// <summary>
    /// Defines the <see cref="PlatformExtensions" />.
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
            if (!FontCache.ContainsKey(moduleType))
            {
                FontCache.Add(moduleType, new FontFamily(new Uri("pack://application:,,,/"), $"/#{module.FontFamily}"));
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
        public static ImageSource ToImageSource(this IIcon icon, Xamarin.Forms.Color color)
        {
            var character = $"{icon.Character}";
            var module = Iconize.FindModuleOf(icon);

            var typeface = new Typeface(new FontFamily(new Uri("pack://application:,,,/"), $"/#{module.FontFamily}"), FontStyles.Normal, FontWeights.Regular, FontStretches.Normal);

            if (!typeface.TryGetGlyphTypeface(out var glyphTypeface))
                throw new InvalidOperationException("No glyphtypeface found");

            var glyphIndexes = new UInt16[character.Length];
            var advanceWidths = new Double[character.Length];
            for (int n = 0; n < character.Length; n++)
            {
                ushort glyphIndex = glyphTypeface.CharacterToGlyphMap[character[n]];
                glyphIndexes[n] = glyphIndex;
                double width = glyphTypeface.AdvanceWidths[glyphIndex] * 1.0;
                advanceWidths[n] = width;
            }

            var gr = new GlyphRun(glyphTypeface, 0, false, 1.0, glyphIndexes,
                                        new System.Windows.Point(0, 0), advanceWidths,
                                        null, null, null, null, null, null);

            var glyphRunDrawing = new GlyphRunDrawing(new SolidColorBrush(ToUIColor(color)), gr);
            return new DrawingImage(glyphRunDrawing);
        }

        /// <summary>
        /// To the color of the UI.
        /// </summary>
        /// <param name="color">The color.</param>
        /// <returns></returns>
        public static Color ToUIColor(this Xamarin.Forms.Color color) => Color.FromArgb((Byte)(color.A * Byte.MaxValue), (Byte)(color.R * Byte.MaxValue), (Byte)(color.G * Byte.MaxValue), (Byte)(color.B * Byte.MaxValue));
    }
}
