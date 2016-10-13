using System;

namespace FormsPlugin.Iconize.Droid
{
    /// <summary>
    /// Enables renderers for various aspects of the library.
    /// </summary>
    public static class IconControls
    {
        /// <summary>
        /// Gets the tab layout identifier.
        /// </summary>
        /// <value>
        /// The tab layout identifier.
        /// </value>
        public static Int32 TabLayoutId { get; private set; }

        /// <summary>
        /// Gets the toolbar identifier.
        /// </summary>
        /// <value>
        /// The toolbar identifier.
        /// </value>
        public static Int32 ToolbarId { get; private set; }

        /// <summary>
        /// Initializes the control library.
        /// </summary>
        public static void Init(Int32 toolbarId = 0, Int32 tabLayoutId = 0)
        {
            TabLayoutId = tabLayoutId;
            ToolbarId = toolbarId;
        }
    }
}