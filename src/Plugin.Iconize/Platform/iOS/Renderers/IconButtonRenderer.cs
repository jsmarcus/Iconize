using System;
using System.ComponentModel;
using Plugin.Iconize;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(IconButton), typeof(IconButtonRenderer))]

namespace Plugin.Iconize
{
    /// <summary>
    /// Defines the <see cref="IconButton" /> renderer.
    /// </summary>
    /// <seealso cref="Xamarin.Forms.Platform.iOS.ButtonRenderer" />
    public class IconButtonRenderer : ButtonRenderer
    {
        /// <summary>
        /// Raises the <see cref="E:ElementChanged" /> event.
        /// </summary>
        /// <param name="e">
        /// The <see cref="ElementChangedEventArgs{Button}" /> instance containing the event data.
        /// </param>
        protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
        {
            base.OnElementChanged(e);

            if (Control is null || Element is null)
                return;

            UpdateText();
        }

        /// <summary>
        /// Called when [element property changed].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">
        /// The <see cref="PropertyChangedEventArgs" /> instance containing the event data.
        /// </param>
        protected override void OnElementPropertyChanged(Object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (Control is null || Element is null)
                return;

            switch (e.PropertyName)
            {
                case nameof(IconButton.FontSize):
                case nameof(IconButton.Text):
                case nameof(IconButton.TextColor):
                    UpdateText();
                    break;
            }
        }

        /// <summary>
        /// Updates the text.
        /// </summary>
        private void UpdateText()
        {
            var icon = Iconize.FindIconForKey(Element.Text);
            if (!(icon is null))
            {
                var font = Iconize.FindModuleOf(icon)?.ToUIFont((nfloat)Element.FontSize);
                if (!(font is null))
                {
                    Control.SetTitle($"{icon.Character}", UIControlState.Normal);
                    Control.Font = font;
                }
            }
        }
    }
}