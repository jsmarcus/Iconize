using System;
using CoreGraphics;
using CoreText;
using Foundation;
using UIKit;

namespace Plugin.Iconize.iOS
{
    /// <summary>
    /// Defines the <see cref="IconizeExtensions" /> extensions.
    /// </summary>
    public static class IconizeExtensions
    {
        /// <summary>
        /// Computes the specified text.
        /// </summary>
        /// <param name="target">The target.</param>
        /// <param name="text">The text.</param>
        /// <param name="size">The font size.</param>
        /// <param name="color">The color.</param>
        /// <returns></returns>
        public static NSAttributedString Compute(this UIView target, NSAttributedString text, nfloat size, UIColor color = null)
        {
            return ParsingUtil.Parse(Iconize.Modules, text, size, color);
        }

        /// <summary>
        /// Computes the specified text.
        /// </summary>
        /// <param name="target">The target.</param>
        /// <param name="text">The text.</param>
        /// <param name="size">The font size.</param>
        /// <param name="color">The color.</param>
        /// <returns></returns>
        public static NSAttributedString Compute(this UIView target, String text, nfloat size, UIColor color = null)
        {
            if (String.IsNullOrEmpty(text))
                return new NSAttributedString();

            return Compute(target, new NSAttributedString(text), size, color);
        }

        /// <summary>
        /// To the UI font.
        /// </summary>
        /// <param name="module">The module.</param>
        /// <param name="size">The size.</param>
        /// <returns></returns>
        public static UIFont ToUIFont(this IIconModule module, nfloat size)
        {
            return UIFont.FromName(module.FontName, size);
        }

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
    }
}
