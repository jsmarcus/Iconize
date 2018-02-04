namespace Plugin.Iconize.Fonts
{
    /// <summary>
    /// Defines the <see cref="FontAwesomeRegularModule" /> icon module.
    /// </summary>
    /// <seealso cref="Plugin.Iconize.IconModule" />
    public sealed class FontAwesomeRegularModule : IconModule
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FontAwesomeRegularModule" /> class.
        /// </summary>
        public FontAwesomeRegularModule()
            : base("FontAwesome", "FontAwesome-Regular", "iconize-fontawesome-regular.otf", FontAwesomeCollection.RegularIcons)
        {
            // Intentionally left blank
        }
    }
}