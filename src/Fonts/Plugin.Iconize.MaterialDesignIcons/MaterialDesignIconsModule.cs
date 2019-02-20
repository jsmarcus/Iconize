namespace Plugin.Iconize.Fonts
{
    /// <summary>
    /// Defines the <see cref="MaterialDesignIconsModule" /> icon module.
    /// </summary>
    /// <seealso cref="Plugin.Iconize.IconModule" />
    public sealed class MaterialDesignIconsModule : IconModule
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MaterialDesignIconsModule" /> class.
        /// </summary>
        public MaterialDesignIconsModule()
            : base("Material Design Icons", "Material-Design-Icons", "iconize-materialdesignicons.ttf", MaterialDesignIconsCollection.Icons)
        {
            // Intentionally left blank
        }
    }
}