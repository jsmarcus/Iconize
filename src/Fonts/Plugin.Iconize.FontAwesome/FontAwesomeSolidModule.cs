namespace Plugin.Iconize.Fonts
{
    /// <summary>
    /// Defines the <see cref="FontAwesomeSolidModule" /> icon module.
    /// </summary>
    /// <seealso cref="Plugin.Iconize.IconModule" />
    public sealed class FontAwesomeSolidModule : IconModule
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FontAwesomeSolidModule" /> class.
        /// </summary>
        public FontAwesomeSolidModule()
            : base("Font Awesome 5 Free Solid", "FontAwesome5Free-Solid", "iconize-fontawesome-solid.ttf", FontAwesomeCollection.SolidIcons)
        {
            // Intentionally left blank
        }
    }
}