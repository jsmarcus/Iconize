using System;
using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Support.V4.Content;
using Android.Support.V4.Graphics.Drawable;
using Android.Text;
using Android.Util;
using R = Android.Resource;

namespace Plugin.Iconize
{
    /// <summary>
    /// Defines the <see cref="IconDrawable" /> drawable.
    /// </summary>
    /// <seealso cref="Android.Graphics.Drawables.Drawable" />
    public class IconDrawable : Drawable, ITintAwareDrawable
    {
        /// <summary>
        /// The android actionbar icon size dp
        /// </summary>
        public const Int32 ANDROID_ACTIONBAR_ICON_SIZE_DP = 24;

        private readonly Context _context;
        private readonly IIcon _icon;
        private readonly TextPaint _paint;

        private Int32 _alpha = 255;
        private Color _color = Android.Graphics.Color.Black;
        private Int32 _size = -1;
        private ColorStateList _tintList;

        /// <inheritdoc />
        public override Int32 IntrinsicHeight => Bounds.Height();

        /// <inheritdoc />
        public override Int32 IntrinsicWidth => Bounds.Width();

        /// <inheritdoc />
        public override Boolean IsStateful => true;

        /// <inheritdoc />
        public override Int32 Opacity => _alpha;

        /// <summary>
        /// Create an <see cref="IconDrawable" />.
        /// </summary>
        /// <param name="context">Your activity or application context.</param>
        /// <param name="iconKey">The icon key you want this drawable to display.</param>
        /// <exception cref="ArgumentException">If the key doesn't match any icon.</exception>
        public IconDrawable(Context context, String iconKey)
            : this(context, Iconize.FindIconForKey(iconKey))
        {
            // Intentionally left blank
        }

        /// <summary>
        /// Create an <see cref="IconDrawable" />.
        /// </summary>
        /// <param name="context">Your activity or application context.</param>
        /// <param name="icon">The icon you want this drawable to display.</param>
        public IconDrawable(Context context, IIcon icon)
        {
            var module = Iconize.FindModuleOf(icon);

            if (module is null)
                throw new Java.Lang.IllegalStateException($"Unable to find the module associated with icon {icon.Key}, have you registered the module you are trying to use with Iconize.With(...) in your Application?");

            _context = context;
            _icon = icon;

            _paint = new TextPaint
            {
                AntiAlias = true,
                TextAlign = Paint.Align.Center,
                UnderlineText = false
            };
            _paint.SetStyle(Paint.Style.Fill);
            _paint.SetTypeface(module.ToTypeface(context));
        }

        /// <summary>
        /// Set the size of this icon to the standard Android ActionBar.
        /// </summary>
        /// <returns>The current IconDrawable for chaining.</returns>
        public IconDrawable ActionBarSize()
        {
            return SizeDp(ANDROID_ACTIONBAR_ICON_SIZE_DP);
        }

        /// <summary>
        /// Set the size of the drawable.
        /// </summary>
        /// <param name="dimenRes">The dimension resource.</param>
        /// <returns>The current IconDrawable for chaining.</returns>
        public IconDrawable SizeRes(Int32 dimenRes)
        {
            return SizePx(_context.Resources.GetDimensionPixelSize(dimenRes));
        }

        /// <summary>
        /// Set the size of the drawable.
        /// </summary>
        /// <param name="size">The size in density-independent pixels (dp).</param>
        /// <returns>The current IconDrawable for chaining.</returns>
        public IconDrawable SizeDp(Int32 size)
        {
            return SizePx(ConvertDpToPx(_context, size));
        }

        /// <summary>
        /// Set the size of the drawable.
        /// </summary>
        /// <param name="size">The size in pixels (px).</param>
        /// <returns>The current IconDrawable for chaining.</returns>
        public IconDrawable SizePx(Int32 size)
        {
            _size = size;

            _paint.TextSize = _size;
            var textBounds = new Rect();
            var textValue = _icon.Character.ToString();
            _paint.GetTextBounds(textValue, 0, 1, textBounds);

            SetBounds(0, 0, textBounds.Width(), textBounds.Height());
            InvalidateSelf();
            return this;
        }

        /// <summary>
        /// Set the color of the drawable.
        /// </summary>
        /// <param name="color">The color, usually from android.graphics.Color or 0xFF012345.</param>
        /// <returns>The current IconDrawable for chaining.</returns>
        public IconDrawable Color(Int32 color)
        {
            _color = new Color(color);
            InvalidateSelf();
            return this;
        }

        /// <summary>
        /// Set the color of the drawable.
        /// </summary>
        /// <param name="colorRes">The color resource, from your R file.</param>
        /// <returns>The current IconDrawable for chaining.</returns>
        public IconDrawable ColorRes(Int32 colorRes)
        {
            return Color(ContextCompat.GetColor(_context, colorRes));
        }

        /// <summary>
        /// Set the alpha of this drawable.
        /// </summary>
        /// <param name="alpha">The alpha, between 0 (transparent) and 255 (opaque).</param>
        /// <returns>The current IconDrawable for chaining.</returns>
        public new IconDrawable Alpha(Int32 alpha)
        {
            SetAlpha(alpha);
            InvalidateSelf();
            return this;
        }

        /// <inheritdoc />
        public override void ClearColorFilter()
        {
            _paint.SetColorFilter(null);
        }

        /// <inheritdoc />
        public override void Draw(Canvas canvas)
        {
            var state = GetState();

            // Set color
            if (!(_tintList is null))
            {
                var color = _tintList.GetColorForState(state, _paint.Color);
                _paint.Color = new Color(color);
            }
            else
            {
                _paint.Color = _color;
            }

            // Set alpha
            _paint.Alpha = IsEnabled(state) ? _alpha : (_alpha / 2);

            var bounds = Bounds;
            var height = bounds.Height();
            _paint.TextSize = _size;
            var textBounds = new Rect();
            var textValue = _icon.Character.ToString();
            _paint.GetTextBounds(textValue, 0, 1, textBounds);
            var textHeight = textBounds.Height();
            var textBottom = bounds.Top + ((height - textHeight) / 2f) + textHeight - textBounds.Bottom;
            canvas.DrawText(textValue, bounds.ExactCenterX(), textBottom, _paint);
        }

        /// <inheritdoc />
        public override Boolean SetState(Int32[] stateSet)
        {
            _paint.Alpha = IsEnabled(stateSet) ? _alpha : _alpha / 2;
            return base.SetState(stateSet);
        }

        /// <inheritdoc />
        public override void SetAlpha(Int32 alpha)
        {
            _alpha = alpha;
            _paint.Alpha = alpha;
        }

        /// <inheritdoc />
        public override void SetColorFilter(ColorFilter colorFilter)
        {
            _paint.SetColorFilter(colorFilter);
        }

        /// <inheritdoc />
        public override void SetTint(Int32 tintColor)
        {
            _color = new Color(tintColor);
        }

        /// <inheritdoc />
        public override void SetTintList(ColorStateList tint)
        {
            _tintList = tint;
        }

        /// <summary>
        /// Converts the dp to px.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="dp">The dp.</param>
        /// <returns></returns>
        private Int32 ConvertDpToPx(Context context, Single dp)
        {
            return (Int32)TypedValue.ApplyDimension(ComplexUnitType.Dip, dp, context.Resources.DisplayMetrics);
        }

        /// <summary>
        /// Sets paint style.
        /// </summary>
        /// <param name="style">The style to be applied.</param>
        public void SetStyle(Paint.Style style)
        {
            _paint.SetStyle(style);
        }

        /// <summary>
        /// Determines whether the specified state set is enabled.
        /// </summary>
        /// <param name="stateSet">The state set.</param>
        /// <returns></returns>
        private Boolean IsEnabled(Int32[] stateSet)
        {
            foreach (var state in stateSet)
            {
                if (state == R.Attribute.StateEnabled)
                {
                    return true;
                }
            }

            return false;
        }
    }
}