using System;
using System.ComponentModel;
using Android.OS;
using Plugin.Iconize;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using ButtonRenderer = Xamarin.Forms.Platform.Android.FastRenderers.ButtonRenderer;

[assembly: ExportRenderer(typeof(IconButton), typeof(IconButtonRenderer))]
namespace Plugin.Iconize
{
    /// <summary>
    /// Defines the <see cref="IconButtonRenderer" /> renderer.
    /// </summary>
    /// <seealso cref="Xamarin.Forms.Platform.Android.FastRenderers.ButtonRenderer" />
    public class IconButtonRenderer : ButtonRenderer
    {
        #region Properties

        /// <summary>
        /// Gets the button.
        /// </summary>
        /// <value>
        /// The button.
        /// </value>
        private IconButton Button => Element as IconButton;

        #endregion Properties

        /// <summary>
        /// Called when [attached to window].
        /// </summary>
        protected override void OnAttachedToWindow()
        {
            base.OnAttachedToWindow();

            TextChanged += OnTextChanged;
        }

        /// <summary>
        /// Called when [detached from window].
        /// </summary>
        protected override void OnDetachedFromWindow()
        {
            TextChanged -= OnTextChanged;

            base.OnDetachedFromWindow();
        }

        /// <summary>
        /// Raises the <see cref="E:ElementChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="ElementChangedEventArgs{Button}" /> instance containing the event data.</param>
        protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
        {
            base.OnElementChanged(e);

            if (Button == null)
                return;

            SetAllCaps(false);
            if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop)
            {
                this.SetBackground(null);
                StateListAnimator = null;
            }
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

            if (Button == null)
                return;

            switch (e.PropertyName)
            {
                case nameof(IconButton.FontSize):
                case nameof(IconButton.TextColor):
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
            TextChanged -= OnTextChanged;

            var icon = Iconize.FindIconForKey(Button.Text);
            if (icon != null)
            {
                Text = $"{icon.Character}";
                Typeface = Iconize.FindModuleOf(icon).ToTypeface(Context);
            }

            TextChanged += OnTextChanged;
        }
    }
}