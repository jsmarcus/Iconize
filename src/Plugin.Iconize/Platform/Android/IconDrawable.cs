using System;
using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Support.V4.Content;
using Android.Text;
using Android.Util;
using R = Android.Resource;
using Plugin.Iconize;

namespace Plugin.Iconize
{
    /// <summary>
    /// Defines the <see cref="IconDrawable" /> drawable.
    /// </summary>
    /// <seealso cref="Android.Graphics.Drawables.Drawable" />
    public class IconDrawable : Drawable
    {
        #region Constants

        /// <summary>
        /// The android actionbar icon size dp
        /// </summary>
        public const Int32 ANDROID_ACTIONBAR_ICON_SIZE_DP = 24;

        #endregion Constants

        #region Members

        private Int32 _alpha = 255;

        private Context _context;

        private IIcon _icon;

        private TextPaint _paint;

        private Int32 _size = -1;

        #endregion Members

        #region Properties

        /// <summary>
        /// Return the intrinsic height of the underlying drawable object.
        /// </summary>
        /// <value>
        /// To be added.
        /// </value>
        /// <remarks>
        /// <para tool="javadoc-to-mdoc">Return the intrinsic height of the underlying drawable object. Returns
        /// -1 if it has no intrinsic height, such as with a solid color.
        /// </para>
        /// <para tool="javadoc-to-mdoc">
        ///   <format type="text/html">
        ///     <a href="http://developer.android.com/reference/android/graphics/drawable/Drawable.html#getIntrinsicHeight()" target="_blank">[Android Documentation]</a>
        ///   </format>
        /// </para>
        /// </remarks>
        /// <since version="Added in API level 1" />
		public override Int32 IntrinsicHeight => Bounds.Height();

        /// <summary>
        /// Return the intrinsic width of the underlying drawable object.
        /// </summary>
        /// <value>
        /// To be added.
        /// </value>
        /// <remarks>
        /// <para tool="javadoc-to-mdoc">Return the intrinsic width of the underlying drawable object.  Returns
        /// -1 if it has no intrinsic width, such as with a solid color.
        /// </para>
        /// <para tool="javadoc-to-mdoc">
        ///   <format type="text/html">
        ///     <a href="http://developer.android.com/reference/android/graphics/drawable/Drawable.html#getIntrinsicWidth()" target="_blank">[Android Documentation]</a>
        ///   </format>
        /// </para>
        /// </remarks>
        /// <since version="Added in API level 1" />
		public override Int32 IntrinsicWidth => Bounds.Width();

        /// <summary>
        /// Indicates whether this view will change its appearance based on state.
        /// </summary>
        /// <value>
        /// To be added.
        /// </value>
        /// <remarks>
        /// <para tool="javadoc-to-mdoc">Indicates whether this view will change its appearance based on state.
        /// Clients can use this to determine whether it is necessary to calculate
        /// their state and call setState.</para>
        /// <para tool="javadoc-to-mdoc">
        ///   <format type="text/html">
        ///     <a href="http://developer.android.com/reference/android/graphics/drawable/Drawable.html#isStateful()" target="_blank">[Android Documentation]</a>
        ///   </format>
        /// </para>
        /// </remarks>
        /// <since version="Added in API level 1" />
        /// <altmember cref="M:Android.Graphics.Drawables.Drawable.SetState(System.Int32[])" />
        public override Boolean IsStateful => true;

        /// <summary>
        /// Return the opacity/transparency of this Drawable.
        /// </summary>
        /// <value>
        /// To be added.
        /// </value>
        /// <remarks>
        /// <para tool="javadoc-to-mdoc">Return the opacity/transparency of this Drawable.  The returned value is
        /// one of the abstract format constants in
        /// <c><see cref="T:Android.Graphics.PixelFormat" /></c>:
        /// <c><see cref="F:Android.Graphics.Format.Unknown" /></c>,
        /// <c><see cref="F:Android.Graphics.Format.Translucent" /></c>,
        /// <c><see cref="F:Android.Graphics.Format.Transparent" /></c>, or
        /// <c><see cref="F:Android.Graphics.Format.Opaque" /></c>.
        /// </para>
        /// <para tool="javadoc-to-mdoc">Generally a Drawable should be as conservative as possible with the
        /// value it returns.  For example, if it contains multiple child drawables
        /// and only shows one of them at a time, if only one of the children is
        /// TRANSLUCENT and the others are OPAQUE then TRANSLUCENT should be
        /// returned.  You can use the method <c><see cref="M:Android.Graphics.Drawables.Drawable.ResolveOpacity(System.Int32, System.Int32)" /></c> to perform a
        /// standard reduction of two opacities to the appropriate single output.
        /// </para>
        /// <para tool="javadoc-to-mdoc">Note that the returned value does <i>not</i> take into account a
        /// custom alpha or color filter that has been applied by the client through
        /// the <c><see cref="M:Android.Graphics.Drawables.Drawable.SetAlpha(System.Int32)" /></c> or <c><see cref="M:Android.Graphics.Drawables.Drawable.SetColorFilter(Android.Graphics.ColorFilter)" /></c> methods.</para>
        /// <para tool="javadoc-to-mdoc">
        ///   <format type="text/html">
        ///     <a href="http://developer.android.com/reference/android/graphics/drawable/Drawable.html#getOpacity()" target="_blank">[Android Documentation]</a>
        ///   </format>
        /// </para>
        /// </remarks>
        /// <since version="Added in API level 1" />
        /// <altmember cref="T:Android.Graphics.PixelFormat" />
        public override Int32 Opacity => _alpha;

        #endregion Properties

        /// <summary>
        /// Create an <see cref="IconDrawable" />.
        /// </summary>
        /// <param name="context">Your activity or application context.</param>
        /// <param name="iconKey">The icon key you want this drawable to display.</param>
        /// <exception cref="ArgumentException">If the key doesn't match any icon.</exception>
        public IconDrawable(Context context, String iconKey)
        {
            var icon = Iconize.FindIconForKey(iconKey);

            if (icon == null)
                throw new ArgumentException($"No icon with the key: {iconKey}");

            Init(context, icon);
        }

        /// <summary>
        /// Create an <see cref="IconDrawable" />.
        /// </summary>
        /// <param name="context">Your activity or application context.</param>
        /// <param name="icon">The icon you want this drawable to display.</param>
        public IconDrawable(Context context, IIcon icon)
        {
            Init(context, icon);
        }

        /// <summary>
        /// Initializes the specified context.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="icon">The icon.</param>
        /// <exception cref="Java.Lang.IllegalStateException">Unable to find the module associated  +
        ///                         with icon  + icon.Key + , have you registered the module  +
        ///                         you are trying to use with Iconize.With(...) in your Application?</exception>
        private void Init(Context context, IIcon icon)
        {
            var module = Iconize.FindModuleOf(icon);

            if (module == null)
                throw new Java.Lang.IllegalStateException($"Unable to find the module associated with icon {icon.Key}, have you registered the module you are trying to use with Iconize.With(...) in your Application?");

            _context = context;
            _icon = icon;

            _paint = new TextPaint
            {
                AntiAlias = true,
                Color = Android.Graphics.Color.Black,
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
        public IconDrawable ActionBarSize() => SizeDp(ANDROID_ACTIONBAR_ICON_SIZE_DP);

        /// <summary>
        /// Set the size of the drawable.
        /// </summary>
        /// <param name="dimenRes">The dimension resource.</param>
        /// <returns>The current IconDrawable for chaining.</returns>
        public IconDrawable SizeRes(Int32 dimenRes) => SizePx(_context.Resources.GetDimensionPixelSize(dimenRes));

        /// <summary>
        /// Set the size of the drawable.
        /// </summary>
        /// <param name="size">The size in density-independent pixels (dp).</param>
        /// <returns>The current IconDrawable for chaining.</returns>
        public IconDrawable SizeDp(Int32 size) => SizePx(ConvertDpToPx(_context, size));

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
            _paint.Color = new Color(color);
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
            _paint.Color = new Color(ContextCompat.GetColor(_context, colorRes));
            InvalidateSelf();
            return this;
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

        /// <summary>
        /// </summary>
        /// <remarks>
        /// <para tool="javadoc-to-mdoc" />
        /// <para tool="javadoc-to-mdoc">
        ///   <format type="text/html">
        ///     <a href="http://developer.android.com/reference/android/graphics/drawable/Drawable.html#clearColorFilter()" target="_blank">[Android Documentation]</a>
        ///   </format>
        /// </para>
        /// </remarks>
        /// <since version="Added in API level 1" />
        public override void ClearColorFilter()
        {
            _paint.SetColorFilter(null);
        }

        /// <summary>
        /// Draws the specified canvas.
        /// </summary>
        /// <param name="canvas">The canvas.</param>
        public override void Draw(Canvas canvas)
        {
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

        /// <summary>
        /// Sets the state.
        /// </summary>
        /// <param name="stateSet">The state set.</param>
        /// <returns></returns>
        public override Boolean SetState(Int32[] stateSet)
        {
            var oldValue = _paint.Alpha;
            var newValue = IsEnabled(stateSet) ? _alpha : _alpha / 2;
            _paint.Alpha = newValue;
            return oldValue != newValue;
        }

        /// <summary>
        /// Sets the alpha.
        /// </summary>
        /// <param name="alpha">The alpha.</param>
        public override void SetAlpha(Int32 alpha)
        {
            _alpha = alpha;
            _paint.Alpha = alpha;
        }

        /// <summary>
        /// Sets the color filter.
        /// </summary>
        /// <param name="colorFilter">The color filter.</param>
        public override void SetColorFilter(ColorFilter colorFilter)
        {
            _paint.SetColorFilter(colorFilter);
        }

        /// <summary>
        /// Converts the dp to px.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="dp">The dp.</param>
        /// <returns></returns>
        private Int32 ConvertDpToPx(Context context, Single dp) => (Int32)TypedValue.ApplyDimension(ComplexUnitType.Dip, dp, context.Resources.DisplayMetrics);

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