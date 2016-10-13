using System;
using Android.Content;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Util;
using Java.Lang;

namespace Plugin.Iconize.Droid.Controls
{
    /// <summary>
    /// Defines the <see cref="IconButton" /> control.
    /// </summary>
    /// <seealso cref="Android.Support.V7.Widget.AppCompatButton" />
    /// <seealso cref="Plugin.Iconize.Droid.IHasOnViewAttachListener" />
    public class IconButton : AppCompatButton, IHasOnViewAttachListener
    {
        private HasOnViewAttachListenerDelegate _delegate;

        /// <summary>
        /// Initializes a new instance of the <see cref="IconButton"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public IconButton(Context context)
            : base(context)
        {
            Init();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IconButton"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="attrs">The attrs.</param>
        public IconButton(Context context, IAttributeSet attrs)
            : base(context, attrs)
        {
            Init();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IconButton"/> class.
        /// </summary>
        /// <param name="javaReference">The java reference.</param>
        /// <param name="transfer">The transfer.</param>
        public IconButton(IntPtr javaReference, JniHandleOwnership transfer)
            : base(javaReference, transfer)
        {
            Init();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IconButton"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="attrs">The attrs.</param>
        /// <param name="defStyleAttr">The definition style attribute.</param>
        public IconButton(Context context, IAttributeSet attrs, Int32 defStyleAttr)
            : base(context, attrs, defStyleAttr)
        {
            Init();
        }

        private void Init()
        {
            TransformationMethod = null;
        }

        /// <summary>
        /// Sets the text.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="type">The type.</param>
        public override void SetText(ICharSequence text, BufferType type)
        {
            base.SetText(this.Compute(Context, text, TextSize), type);
        }

        /// <summary>
        /// Sets the on view attach listener.
        /// </summary>
        /// <param name="listener">The listener.</param>
        public void SetOnViewAttachListener(IOnViewAttachListener listener)
        {
            if (_delegate == null)
                _delegate = new HasOnViewAttachListenerDelegate(this);
            _delegate.SetOnViewAttachListener(listener);
        }

        /// <summary>
        /// This is called when the view is attached to a window.
        /// </summary>
        /// <remarks>
        /// <para tool="javadoc-to-mdoc">This is called when the view is attached to a window.  At this point it
        /// has a Surface and will start drawing.  Note that this function is
        /// guaranteed to be called before <c><see cref="M:Android.Views.View.OnDraw(Android.Graphics.Canvas)" /></c>,
        /// however it may be called any time before the first onDraw -- including
        /// before or after <c><see cref="M:Android.Views.View.OnMeasure(System.Int32, System.Int32)" /></c>.</para>
        /// <para tool="javadoc-to-mdoc">
        ///   <format type="text/html">
        ///     <a href="http://developer.android.com/reference/android/view/View.html#onAttachedToWindow()" target="_blank">[Android Documentation]</a>
        ///   </format>
        /// </para>
        /// </remarks>
        /// <since version="Added in API level 1" />
        /// <altmember cref="M:Android.Views.View.OnDetachedFromWindow" />
        protected override void OnAttachedToWindow()
        {
            base.OnAttachedToWindow();
            _delegate.OnAttachedToWindow();
        }

        /// <summary>
        /// This is called when the view is detached from a window.
        /// </summary>
        /// <remarks>
        /// <para tool="javadoc-to-mdoc">This is called when the view is detached from a window.  At this point it
        /// no longer has a surface for drawing.</para>
        /// <para tool="javadoc-to-mdoc">
        ///   <format type="text/html">
        ///     <a href="http://developer.android.com/reference/android/view/View.html#onDetachedFromWindow()" target="_blank">[Android Documentation]</a>
        ///   </format>
        /// </para>
        /// </remarks>
        /// <since version="Added in API level 1" />
        /// <altmember cref="M:Android.Views.View.OnAttachedToWindow" />
        protected override void OnDetachedFromWindow()
        {
            base.OnDetachedFromWindow();
            _delegate.OnDetachedFromWindow();
        }
    }
}