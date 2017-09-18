using System;
using System.ComponentModel;
using Plugin.Iconize;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
#if USE_FASTRENDERERS
using LabelRenderer = Xamarin.Forms.Platform.Android.FastRenderers.LabelRenderer;
#else
using LabelRenderer = Xamarin.Forms.Platform.Android.LabelRenderer;
#endif

[assembly: ExportRenderer(typeof(IconLabel), typeof(IconLabelRenderer))]
namespace Plugin.Iconize
{
    /// <summary>
    /// Defines the <see cref="IconLabelRenderer" /> renderer.
    /// </summary>
#if USE_FASTRENDERERS
    /// <seealso cref="Xamarin.Forms.Platform.Android.FastRenderers.LabelRenderer" />
#else
    /// <seealso cref="Xamarin.Forms.Platform.Android.LabelRenderer" />
#endif
    public class IconLabelRenderer : LabelRenderer
    {
        #region Properties

        /// <summary>
        /// Gets the label.
        /// </summary>
        /// <value>
        /// The label.
        /// </value>
        private IconLabel Label => Element as IconLabel;

        #endregion Properties

        /// <summary>
        /// Called when [attached to window].
        /// </summary>
        protected override void OnAttachedToWindow()
        {
            base.OnAttachedToWindow();
#if USE_FASTRENDERERS
            TextChanged += OnTextChanged;
#else
            Control.TextChanged += OnTextChanged;
#endif
        }

        /// <summary>
        /// Called when [detached from window].
        /// </summary>
        protected override void OnDetachedFromWindow()
        {
#if USE_FASTRENDERERS
            TextChanged -= OnTextChanged;
#else
            Control.TextChanged -= OnTextChanged;
#endif
            base.OnDetachedFromWindow();
        }

        /// <summary>
        /// Raises the <see cref="E:ElementChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="ElementChangedEventArgs{Label}" /> instance containing the event data.</param>
        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);

            if (Label == null)
                return;

            UpdateText();
        }

        /// <summary>
        /// Called when [element property changed].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="PropertyChangedEventArgs" /> instance containing the event data.</param>
        protected override void OnElementPropertyChanged(Object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (Label == null)
                return;

            switch (e.PropertyName)
            {
                case nameof(IconLabel.FontSize):
                case nameof(IconLabel.TextColor):
                    UpdateText();
                    break;
            }
        }

        /// <summary>
        /// Called when [text changed].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="Android.Text.TextChangedEventArgs" /> instance containing the event data.</param>
        private void OnTextChanged(Object sender, Android.Text.TextChangedEventArgs e)
        {
            UpdateText();
        }

        /// <summary>
        /// Updates the text.
        /// </summary>
        private void UpdateText()
        {
#if USE_FASTRENDERERS
            TextChanged -= OnTextChanged;
#else
            Control.TextChanged -= OnTextChanged;
#endif

            var icon = Iconize.FindIconForKey(Label.Text);
            if (icon != null)
            {
#if USE_FASTRENDERERS
                Text = $"{icon.Character}";
                Typeface = Iconize.FindModuleOf(icon).ToTypeface(Context);
#else
                Control.Text = $"{icon.Character}";
                Control.Typeface = Iconize.FindModuleOf(icon).ToTypeface(Context);
#endif
            }
#if USE_FASTRENDERERS
            TextChanged += OnTextChanged;
#else
            Control.TextChanged += OnTextChanged;
#endif
        }
    }
}