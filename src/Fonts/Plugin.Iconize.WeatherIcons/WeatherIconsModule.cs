namespace Plugin.Iconize.Fonts
{
    /// <summary>
    /// Defines the <see cref="WeatherIconsModule" /> icon module.
    /// </summary>
    /// <seealso cref="Plugin.Iconize.IconModule" />
    public sealed class WeatherIconsModule : IconModule
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WeatherIconsModule" /> class.
        /// </summary>
        public WeatherIconsModule()
            : base("Weather Icons", "WeatherIcons-Regular", "iconize-weathericons.ttf", WeatherIconsCollection.Icons)
        {
            // Intentionally left blank
        }
    }
}