using System;
using System.ComponentModel;
using Android.Content;
using Android.OS;
using Plugin.Iconize;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
#if USE_FASTRENDERERS
using ButtonRenderer = Xamarin.Forms.Platform.Android.FastRenderers.ButtonRenderer;
#else
using ButtonRenderer = Xamarin.Forms.Platform.Android.AppCompat.ButtonRenderer;
#endif

[assembly: ExportRenderer(typeof(IconButton), typeof(IconButtonRenderer))]

namespace Plugin.Iconize
{
    /// <summary>
    /// Defines the <see cref="IconButton" /> renderer.
    /// </summary>
#if USE_FASTRENDERERS
    /// <seealso cref="Xamarin.Forms.Platform.Android.FastRenderers.ButtonRenderer" />
#else
    /// <seealso cref="Xamarin.Forms.Platform.Android.AppCompat.ButtonRenderer" />
#endif
    public class IconButtonRenderer : ButtonRenderer
    {
        /// <summary>
        /// Gets the button.
        /// </summary>
        /// <value>
        /// The button.
        /// </value>
        private IconButton Button => Element as IconButton;

        /// <summary>
        /// Initializes a new instance of the <see cref="IconButtonRenderer"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public IconButtonRenderer(Context context)
            : base(context)
        {
            // Intentionally left blank
        }

        /// <inheritdoc />
        protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
        {
            base.OnElementChanged(e);

            if (Button is null)
                return;

#if USE_FASTRENDERERS
            SetAllCaps(false);
#else
            Control.SetAllCaps(false);
#endif

            if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop)
            {
                this.SetBackground(null);
                StateListAnimator = null;
            }

            UpdateText();
        }

        /// <inheritdoc />
        protected override void OnElementPropertyChanged(Object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (Button is null)
                return;

            switch (e.PropertyName)
            {
                case nameof(IconButton.Text):
                case nameof(IconButton.FontSize):
                case nameof(IconButton.TextColor):
                    UpdateText();
                    break;
            }
        }

        /// <inheritdoc />
        protected override void OnAttachedToWindow()
        {
            base.OnAttachedToWindow();

#if USE_FASTRENDERERS
            TextChanged += OnTextChanged;
#else
            if (!(Control is null))
            {
                Control.TextChanged += OnTextChanged;
            }
#endif
        }

        /// <inheritdoc />
        protected override void OnDetachedFromWindow()
        {
#if USE_FASTRENDERERS
            TextChanged -= OnTextChanged;
#else
            if (!(Control is null))
            {
                Control.TextChanged -= OnTextChanged;
            }
#endif

            base.OnDetachedFromWindow();
        }

        private void OnTextChanged(Object sender, Android.Text.TextChangedEventArgs e)
        {
            UpdateText();
        }

        private void UpdateText()
        {
#if USE_FASTRENDERERS
            TextChanged -= OnTextChanged;

            var icon = Iconize.FindIconForKey(Button.Text);
            if (!(icon is null))
            {
                Text = $"{icon.Character}";
                Typeface = Iconize.FindModuleOf(icon).ToTypeface(Context);
            }

            TextChanged += OnTextChanged;
#else
            if (!(Control is null))
            {
                Control.TextChanged -= OnTextChanged;

                var icon = Iconize.FindIconForKey(Button.Text);
                if (!(icon is null))
                {
                    Control.Text = $"{icon.Character}";
                    Control.Typeface = Iconize.FindModuleOf(icon).ToTypeface(Context);
                }

                Control.TextChanged += OnTextChanged;
            }
#endif
        }
    }
}