using System;
using Android.Graphics;
using Android.OS;
using Android.Text.Style;
using Java.Lang;

namespace Plugin.Iconize.Droid
{
    /// <summary>
    /// Defines the <see cref="CustomTypefaceSpan" /> span.
    /// </summary>
    /// <seealso cref="Android.Text.Style.ReplacementSpan" />
    public class CustomTypefaceSpan : ReplacementSpan
    {
        private static readonly Int32 ROTATION_DURATION = 2000;
        private static readonly Rect TEXT_BOUNDS = new Rect();
        private static readonly Paint LOCAL_PAINT = new Paint();
        private static readonly Single BASELINE_RATIO = 1 / 7f;

        private readonly System.String _icon;
        private readonly Typeface _type;
        private readonly Single _iconSizePx;
        private readonly Single _iconSizeRatio;
        private readonly Int32 _iconColor;
        private readonly System.Boolean _rotate;
        private readonly System.Boolean _baselineAligned;
        private readonly Int64 _rotationStartTime;

        /// <summary>
        /// Gets a value indicating whether this instance is animated.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is animated; otherwise, <c>false</c>.
        /// </value>
        public System.Boolean IsAnimated => _rotate;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomTypefaceSpan" /> class.
        /// </summary>
        /// <param name="icon">The icon.</param>
        /// <param name="type">The type.</param>
        /// <param name="iconSizePx">The icon size px.</param>
        /// <param name="iconSizeRatio">The icon size ratio.</param>
        /// <param name="iconColor">Color of the icon.</param>
        /// <param name="rotate">if set to <c>true</c> [rotate].</param>
        /// <param name="baselineAligned">if set to <c>true</c> [baseline aligned].</param>
        public CustomTypefaceSpan(IIcon icon, Typeface type, Single iconSizePx, Single iconSizeRatio, Int32 iconColor, System.Boolean rotate, System.Boolean baselineAligned)
        {
            _rotate = rotate;
            _baselineAligned = baselineAligned;
            _icon = icon.Character.ToString();
            _type = type;
            _iconSizePx = iconSizePx;
            _iconSizeRatio = iconSizeRatio;
            _iconColor = iconColor;
            _rotationStartTime = SystemClock.CurrentThreadTimeMillis();
        }

        private void ApplyCustomTypeFace(Paint paint, Typeface tf)
        {
            paint.FakeBoldText = false;
            paint.TextSkewX = 0f;
            paint.SetTypeface(tf);
            if (_rotate)
                paint.ClearShadowLayer();
            if (_iconSizeRatio > 0)
                paint.TextSize = (paint.TextSize * _iconSizeRatio);
            else if (_iconSizePx > 0)
                paint.TextSize = _iconSizePx;
            if (_iconColor < Int32.MaxValue)
                paint.Color = new Color(_iconColor);
            paint.Flags = paint.Flags | PaintFlags.SubpixelText;
        }

        /// <summary>
        /// </summary>
        /// <param name="canvas">To be added.</param>
        /// <param name="text">To be added.</param>
        /// <param name="start">To be added.</param>
        /// <param name="end">To be added.</param>
        /// <param name="x">To be added.</param>
        /// <param name="top">To be added.</param>
        /// <param name="y">To be added.</param>
        /// <param name="bottom">To be added.</param>
        /// <param name="paint">To be added.</param>
        /// <remarks>
        /// <para tool="javadoc-to-mdoc" />
        /// <para tool="javadoc-to-mdoc">
        ///   <format type="text/html">
        ///     <a href="http://developer.android.com/reference/android/text/style/ReplacementSpan.html#draw(android.graphics.Canvas, java.lang.CharSequence, int, int, float, int, int, int, android.graphics.Paint)" target="_blank">[Android Documentation]</a>
        ///   </format>
        /// </para>
        /// </remarks>
        /// <since version="Added in API level 1" />
        public override void Draw(Canvas canvas, ICharSequence text, Int32 start, Int32 end, Single x, Int32 top, Int32 y, Int32 bottom, Paint paint)
        {
            ApplyCustomTypeFace(paint, _type);
            paint.GetTextBounds(_icon, 0, 1, TEXT_BOUNDS);
            canvas.Save();
            var baselineRatio = _baselineAligned ? 0f : BASELINE_RATIO;
            if (_rotate)
            {
                var rotation = (SystemClock.CurrentThreadTimeMillis() - _rotationStartTime) / (Single)ROTATION_DURATION * 360f;
                var centerX = x + TEXT_BOUNDS.Width() / 2f;
                var centerY = y - TEXT_BOUNDS.Height() / 2f + TEXT_BOUNDS.Height() * baselineRatio;
                canvas.Rotate(rotation, centerX, centerY);
            }

            canvas.DrawText(_icon, x - TEXT_BOUNDS.Left, y - TEXT_BOUNDS.Bottom + TEXT_BOUNDS.Height() * baselineRatio, paint);
            canvas.Restore();
        }

        /// <summary>
        /// Gets the size.
        /// </summary>
        /// <param name="paint">The paint.</param>
        /// <param name="text">The text.</param>
        /// <param name="start">The start.</param>
        /// <param name="end">The end.</param>
        /// <param name="fm">The fm.</param>
        /// <returns></returns>
        public override Int32 GetSize(Paint paint, ICharSequence text, Int32 start, Int32 end, Paint.FontMetricsInt fm)
        {
            LOCAL_PAINT.Set(paint);
            ApplyCustomTypeFace(LOCAL_PAINT, _type);
            LOCAL_PAINT.GetTextBounds(_icon, 0, 1, TEXT_BOUNDS);
            if (fm != null)
            {
                var baselineRatio = _baselineAligned ? 0 : BASELINE_RATIO;
                fm.Descent = (Int32)(TEXT_BOUNDS.Height() * baselineRatio);
                fm.Ascent = -(TEXT_BOUNDS.Height() - fm.Descent);
                fm.Top = fm.Ascent;
                fm.Bottom = fm.Descent;
            }
            return TEXT_BOUNDS.Width();
        }
    }
}