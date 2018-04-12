using System;
using AppKit;
using CoreGraphics;
using CoreText;
using Foundation;

namespace Plugin.Iconize
{
    /// <summary>
    /// Defines the <see cref="PlatformExtensions" /> extensions.
    /// </summary>
    public static class PlatformExtensions
    {
        /// <summary>
        /// To the NS font.
        /// </summary>
        /// <param name="module">The module.</param>
        /// <param name="size">The size.</param>
        /// <returns></returns>
        public static NSFont ToNSFont(this IIconModule module, nfloat size) => NSFont.FromFontName(module.FontName, size);

        /// <summary>
        /// To the NS image.
        /// </summary>
        /// <param name="icon">The icon.</param>
        /// <param name="size">The size.</param>
        /// <returns></returns>
        public static NSImage ToNSImage(this IIcon icon, nfloat size) => ToNSImageWithColor(icon, size, NSColor.Black.CGColor);

        /// <summary>
        /// To the color of the ns image with.
        /// </summary>
        /// <param name="icon">The icon.</param>
        /// <param name="size">The size.</param>
        /// <param name="color">The color.</param>
        /// <returns></returns>
        public static NSImage ToNSImageWithColor(this IIcon icon, nfloat size, CGColor color)
        {
            var attributedString = new NSAttributedString($"{icon.Character}", new CTStringAttributes
            {
                Font = new CTFont(Iconize.FindModuleOf(icon).FontName, size),
                ForegroundColorFromContext = true
            });

            using (var ctx = new CGBitmapContext(IntPtr.Zero, (nint)size, (nint)size, 8, 4 * (nint)(size), CGColorSpace.CreateDeviceRGB(), CGImageAlphaInfo.PremultipliedFirst))
            {
                ctx.SetFillColor(color);

                using (var textLine = new CTLine(attributedString))
                {
                    textLine.Draw(ctx);
                }

                return new NSImage(ctx.ToImage(), new CGSize(size, size));
            }
        }
    }
}