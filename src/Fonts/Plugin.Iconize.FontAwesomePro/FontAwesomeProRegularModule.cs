namespace Plugin.Iconize.Fonts
{
    /// <summary>
    /// Defines the <see cref="FontAwesomeProRegularModule" /> icon module.
    /// </summary>
    /// <seealso cref="Plugin.Iconize.IconModule" />
    public sealed class FontAwesomeProRegularModule : IconModule
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FontAwesomeProRegularModule" /> class.
        /// </summary>
        public FontAwesomeProRegularModule()
            : base("Font Awesome 5 Pro Regular", "FontAwesome5Pro-Regular", "iconize-fontawesome-pro-regular.ttf", FontAwesomeProCollection.RegularIcons)
        {
            // Intentionally left blank
        }
    }
}