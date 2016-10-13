using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;
using Windows.UI;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Media;

namespace Plugin.Iconize.UWP
{
    /// <summary>
    /// Defines the <see cref="ParsingUtil" /> type.
    /// </summary>
    public static class ParsingUtil
    {
        /// <summary>
        /// Parses the specified modules.
        /// </summary>
        /// <param name="modules">The modules.</param>
        /// <param name="text">The text.</param>
        /// <param name="size">The size.</param>
        /// <returns></returns>
        public static Span Parse(IList<IIconModule> modules, String text, Double size)
        {
            var span = new Span();
            RecursivePrepareSpannableIndexes(modules, text, size, span, 0);
            return span;
        }

        /// <summary>
        /// Recursives the prepare spannable indexes.
        /// </summary>
        /// <param name="modules">The modules.</param>
        /// <param name="text">The text.</param>
        /// <param name="size">The size.</param>
        /// <param name="builder">The builder.</param>
        /// <param name="start">The start.</param>
        /// <exception cref="System.ArgumentException">Unknown expression  + stroke +  in \ + text + \</exception>
        private static void RecursivePrepareSpannableIndexes(IList<IIconModule> modules, String text, Double size, Span builder, Int32 start)
        {
            // Try to find a {...} in the string and extract expression from it
            var startIndex = text.IndexOf("{", start, StringComparison.Ordinal);
            if (startIndex > start)
            {
                builder.Inlines.Add(new Run
                {
                    Text = text.Substring(start, startIndex - start)
                });
            }
            else if (startIndex == -1)
            {
                if (start < text.Length - 1)
                {
                    builder.Inlines.Add(new Run
                    {
                        Text = text.Substring(start)
                    });
                }
                return;
            }
            var endIndex = text.IndexOf("}", startIndex, StringComparison.Ordinal);
            var expression = text.Substring(startIndex + 1, endIndex - startIndex - 1);

            // Split the expression and retrieve the icon key
            var strokes = expression.Split(' ');
            var key = strokes[0];

            // Loop through the descriptors to find a key match
            IIconModule module = null;
            IIcon icon = null;
            for (var i = 0; i < modules.Count; i++)
            {
                module = modules[i];
                icon = module.GetIcon(key);
                if (icon != null)
                    break;
            }

            // If no match, ignore and continue
            if (icon == null)
            {
                RecursivePrepareSpannableIndexes(modules, text, size, builder, endIndex + 1);
                return;
            }

            // See if any more stroke within {} should be applied
            var iconSizePt = Double.MinValue;
            var iconColor = Colors.Black;
            var iconSizeRatio = Single.MinValue;

            for (var i = 1; i < strokes.Length; i++)
            {
                var stroke = strokes[i];

                // Look for an icon size
                if (Regex.IsMatch(stroke, "([0-9]*)px"))
                {
                    iconSizePt = Convert.ToInt32(stroke.Substring(0, stroke.Length - 2));
                }
                else if (Regex.IsMatch(stroke, "([0-9]*)pt"))
                {
                    iconSizePt = Convert.ToInt32(stroke.Substring(0, stroke.Length - 2));
                }
                else if (Regex.IsMatch(stroke, "([0-9]*(\\.[0-9]*)?)%"))
                {
                    iconSizeRatio = Convert.ToSingle(stroke.Substring(0, stroke.Length - 1)) / 100f;
                }

                // Look for an icon color
                else if (Regex.IsMatch(stroke, "#([0-9A-Fa-f]{6}|[0-9A-Fa-f]{8})"))
                {
                    if (stroke.Length == 7)
                    {
                        var red = Byte.Parse(stroke.Substring(1, 2), NumberStyles.HexNumber);
                        var blue = Byte.Parse(stroke.Substring(3, 2), NumberStyles.HexNumber);
                        var green = Byte.Parse(stroke.Substring(5, 2), NumberStyles.HexNumber);
                        iconColor = Color.FromArgb(0, red, blue, green);
                    }
                    else if (stroke.Length == 9)
                    {
                        var alpha = Byte.Parse(stroke.Substring(1, 2), NumberStyles.HexNumber);
                        var red = Byte.Parse(stroke.Substring(3, 2), NumberStyles.HexNumber);
                        var blue = Byte.Parse(stroke.Substring(5, 2), NumberStyles.HexNumber);
                        var green = Byte.Parse(stroke.Substring(7, 2), NumberStyles.HexNumber);
                        iconColor = Color.FromArgb(alpha, red, blue, green);
                    }
                }
                else
                {
                    throw new ArgumentException("Unknown expression " + stroke + " in \"" + text + "\"");
                }
            }

            if (Math.Abs(iconSizePt - Double.MinValue) < Double.Epsilon)
            {
                iconSizePt = size;
            }

            if (Math.Abs(iconSizeRatio - Single.MinValue) > Single.Epsilon)
            {
                iconSizePt = iconSizePt * iconSizeRatio;
            }

            var replaceString = new Run
            {
                FontFamily = module.ToFontFamily(),
                Text = $"{icon.Character}"
            };

            if (iconColor != Colors.Black)
            {
                replaceString.Foreground = new SolidColorBrush(iconColor);
            }

            builder.Inlines.Add(replaceString);

            RecursivePrepareSpannableIndexes(modules, text, size, builder, endIndex + 1);
        }
    }
}
