namespace Plugin.Iconize.Fonts
{
    /// <summary>
    /// Defines the <see cref="JamIconsModule" /> icon module.
    /// </summary>
    /// <seealso cref="Plugin.Iconize.IconModule" />
    public sealed class JamIconsModule : IconModule
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="JamIconsModule" /> class.
        /// </summary>
        public JamIconsModule()
            : base("Jam-icons", "Jam-icons", "iconize-jam-icons.ttf", JamIconsCollection.Icons)
        {
            // Intentionally left blank
        }
    }
}