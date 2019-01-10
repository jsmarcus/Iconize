using System;
using System.ComponentModel;
using Plugin.Iconize;
using Xamarin.Forms;
using Xamarin.Forms.Platform.MacOS;

[assembly: ExportRenderer(typeof(IconLabel), typeof(IconLabelRenderer))]

namespace Plugin.Iconize
{
    /// <summary>
    /// Defines the <see cref="IconLabel" /> renderer.
    /// </summary>
    /// <seealso cref="Xamarin.Forms.Platform.MacOS.LabelRenderer" />
    public class IconLabelRenderer : LabelRenderer
    {
        /// <summary>
        /// Raises the <see cref="E:ElementChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="ElementChangedEventArgs{Label}" /> instance containing the event data.</param>
        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
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
        /// <param name="e">The <see cref="PropertyChangedEventArgs" /> instance containing the event data.</param>
        protected override void OnElementPropertyChanged(Object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (Control is null || Element is null)
                return;

            switch (e.PropertyName)
            {
                case nameof(IconLabel.FontSize):
                case nameof(IconLabel.Text):
                case nameof(IconLabel.TextColor):
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
                Control.StringValue = $"{icon.Character}";
                Control.Font = Iconize.FindModuleOf(icon).ToNSFont((nfloat)Element.FontSize);
            }
        }
    }
}
