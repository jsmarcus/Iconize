namespace Plugin.Iconize.Fonts
{
    /// <summary>
    /// Defines the <see cref="FontAwesomeProLightModule" /> icon module.
    /// </summary>
    /// <seealso cref="Plugin.Iconize.IconModule" />
    public sealed class FontAwesomeProLightModule : IconModule
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FontAwesomeProLightModule" /> class.
        /// </summary>
        public FontAwesomeProLightModule()
            : base("Font Awesome 5 Pro Light", "FontAwesome5Pro-Light", "iconize-fontawesome-pro-light.ttf", FontAwesomeProCollection.LightIcons)
        {
            // Intentionally left blank
        }
    }
}