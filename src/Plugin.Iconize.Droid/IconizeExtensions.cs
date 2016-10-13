using System;
using System.Collections.Generic;
using Android.Content;
using Android.Graphics;
using Android.Views;
using Android.Widget;
using Java.Lang;

namespace Plugin.Iconize.Droid
{
    /// <summary>
    /// Defines the <see cref="IconizeExtensions" /> extensions.
    /// </summary>
    public static class IconizeExtensions
    {
        private static readonly Dictionary<Type, Typeface> _fontCache = new Dictionary<Type, Typeface>();

        /// <summary>
        /// Replace "{}" tags in the given text views with actual icons, requesting the IconFontDescriptors
        /// one after the others.
        /// <strong>This is a one time call.</strong> If you call <see cref="TextView.SetText(string, TextView.BufferType)" /> after this,
        /// you'll need to call it again.
        /// </summary>
        /// <param name="textViews">The text views.</param>
        public static void AddIcons(params TextView[] textViews)
        {
            foreach (var textView in textViews)
            {
                if (textView != null)
                {
                    textView.SetText(textView.Compute(textView.Context, textView.TextFormatted, textView.TextSize), TextView.BufferType.Spannable);
                }
            }
        }

        /// <summary>
        /// Computes the specified context.
        /// </summary>
        /// <param name="target">The target.</param>
        /// <param name="context">The context.</param>
        /// <param name="text">The text.</param>
        /// <param name="size">The font size.</param>
        /// <returns></returns>
        public static ICharSequence Compute(this View target, Context context, ICharSequence text, Single size)
        {
            if (text == null || text.Length() == 0)
                return text;

            return ParsingUtil.Parse(context, Iconize.Modules, text, size, target);
        }

        /// <summary>
        /// Computes the specified context.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="context">The context.</param>
        /// <param name="size">The font size.</param>
        /// <returns></returns>
        public static ICharSequence Compute(this ICharSequence text, Context context, Single size)
        {
            if (text == null || text.Length() == 0)
                return text;

            return ParsingUtil.Parse(context, Iconize.Modules, text, size, null);
        }

        /// <summary>
        /// To the typeface.
        /// </summary>
        /// <param name="module">The module.</param>
        /// <param name="context">The context.</param>
        /// <returns></returns>
        public static Typeface ToTypeface(this IIconModule module, Context context)
        {
            var moduleType = module.GetType();
            if (_fontCache.ContainsKey(moduleType) == false)
            {
                _fontCache.Add(moduleType, Typeface.CreateFromAsset(context.Assets, module.FontPath));
            }
            return _fontCache[moduleType];
        }
    }
}