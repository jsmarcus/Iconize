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
            : base("Font Awesome 5 Free Regular", "FontAwesome5Free-Regular", "iconize-fontawesome-regular.ttf", FontAwesomeCollection.RegularIcons)
        {
            // Intentionally left blank
        }
    }
}