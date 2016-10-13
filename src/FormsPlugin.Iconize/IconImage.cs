using System;
using Xamarin.Forms;

namespace FormsPlugin.Iconize
{
    /// <summary>
    /// Defines the <see cref="IconImage" /> control.
    /// </summary>
    /// <seealso cref="Xamarin.Forms.Image" />
    public class IconImage : Image
    {
        #region Constants

        /// <summary>
        /// When the property <see cref="IconSize" /> is set to this value, the icon size will match the Image Size.
        /// </summary>
        public const Double AutoSize = -1.0;

        #endregion Constants

        #region Bindables

        /// <summary>
        /// Property definition for the <see cref="Icon" /> Property
        /// </summary>
        public static BindableProperty IconProperty = BindableProperty.Create(nameof(Icon), typeof(String), typeof(IconImage), String.Empty);

        /// <summary>
        /// Property definition for the <see cref="IconColor" /> Property
        /// </summary>
        public static BindableProperty IconColorProperty = BindableProperty.Create(nameof(IconColor), typeof(Color), typeof(IconImage), Color.Default);

        /// <summary>
        /// Property definition for the <see cref="IconSize" /> Property
        /// </summary>
        public static BindableProperty IconSizeProperty = BindableProperty.Create(nameof(IconSize), typeof(Double), typeof(IconImage), IconImage.AutoSize);

        #endregion Bindables

        #region Properties

        /// <summary>
        /// Gets or sets the icon.
        /// </summary>
        /// <value>
        /// The icon.
        /// </value>
        public String Icon
        {
            get { return (String)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }

        /// <summary>
        /// Gets or sets the color of the icon.
        /// </summary>
        /// <value>
        /// The color of the icon.
        /// </value>
        public Color IconColor
        {
            get { return (Color)GetValue(IconColorProperty); }
            set { SetValue(IconColorProperty, value); }
        }

        /// <summary>
        /// Gets or sets the size of the icon.
        /// </summary>
        /// <value>
        /// The size of the icon.
        /// </value>
        public Double IconSize
        {
            get { return (Double)GetValue(IconSizeProperty); }
            set { SetValue(IconSizeProperty, value); }
        }

        #endregion Properties
    }
}