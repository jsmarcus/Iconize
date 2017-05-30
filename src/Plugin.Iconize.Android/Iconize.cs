using System;

namespace Plugin.Iconize
{
    /// <summary>
    /// Enables renderers for various aspects of the library.
    /// </summary>
    public static partial class Iconize
    {
        #region Properties

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

        #endregion Properties

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