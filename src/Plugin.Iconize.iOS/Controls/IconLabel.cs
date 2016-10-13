using System;
using CoreGraphics;
using Foundation;
using UIKit;

namespace Plugin.Iconize.iOS.Controls
{
    /// <summary>
    /// Defines the <see cref="IconLabel" /> control.
    /// </summary>
    /// <seealso cref="UIKit.UILabel" />
    public class IconLabel : UILabel
    {
        #region Properties

        /// <summary>
        /// The text displayed by this UILabel.
        /// </summary>
        /// <value>
        /// <para>(More documentation for this node is coming)</para>
        /// <para tool="nullallowed">This value can be <see langword="null" />.</para>
        /// </value>
        /// <remarks>
        /// <para>This string is nil by default.</para>
        /// <para>      In iOS 6 and later, assigning a new value to this property also replaces the value of the attributedText property with the same text, albeit without any inherent style attributes. Instead the label styles the new string using the shadowColor, textAlignment, and other style-related properties of the class.</para>
        /// </remarks>
        public override String Text
        {
            get { return base.AttributedText.Value; }
            set { base.AttributedText = this.Compute(value, Font.PointSize); }
        }

        #endregion Properties

        /// <summary>
        /// Initializes a new instance of the <see cref="IconLabel" /> class.
        /// </summary>
        public IconLabel()
        {
            // Intentionally left blank
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IconLabel" /> class.
        /// </summary>
        /// <param name="coder">The coder.</param>
        public IconLabel(NSCoder coder)
            : base(coder)
        {
            // Intentionally left blank
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IconLabel" /> class.
        /// </summary>
        /// <param name="frame">The frame.</param>
        public IconLabel(CGRect frame)
            : base(frame)
        {
            // Intentionally left blank
        }
    }
}