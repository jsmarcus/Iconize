using System;
using CoreGraphics;
using Foundation;
using UIKit;

namespace Plugin.Iconize.iOS.Controls
{
    /// <summary>
    /// Defines the <see cref="IconButton" /> control.
    /// </summary>
    /// <seealso cref="UIKit.UIButton" />
    public class IconButton : UIButton
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IconButton" /> class.
        /// </summary>
        public IconButton()
        {
            // Intentionally left blank
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IconButton" /> class.
        /// </summary>
        /// <param name="coder">The coder.</param>
        public IconButton(NSCoder coder)
            : base(coder)
        {
            // Intentionally left blank
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IconButton" /> class.
        /// </summary>
        /// <param name="frame">The frame.</param>
        public IconButton(CGRect frame)
            : base(frame)
        {
            // Intentionally left blank
        }

        /// <summary>
        /// Sets the title.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <param name="forState">For state.</param>
        public override void SetTitle(String title, UIControlState forState)
        {
            base.SetAttributedTitle(this.Compute(title, Font.PointSize), forState);
        }

        /// <summary>
        /// Titles the specified state.
        /// </summary>
        /// <param name="state">The state.</param>
        /// <returns></returns>
        public override String Title(UIControlState state)
        {
            return base.GetAttributedTitle(state).Value;
        }
    }
}