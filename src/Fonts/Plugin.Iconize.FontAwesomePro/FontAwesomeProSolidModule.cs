namespace Plugin.Iconize.Fonts
{
    /// <summary>
    /// Defines the <see cref="FontAwesomeProSolidModule" /> icon module.
    /// </summary>
    /// <seealso cref="Plugin.Iconize.IconModule" />
    public sealed class FontAwesomeProSolidModule : IconModule
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FontAwesomeProSolidModule" /> class.
        /// </summary>
        public FontAwesomeProSolidModule()
            : base("Font Awesome 5 Pro Solid", "FontAwesome5Pro-Solid", "iconize-fontawesome-pro-solid.ttf", FontAwesomeProCollection.SolidIcons)
        {
            // Intentionally left blank
        }
    }
}