namespace Plugin.Iconize.Fonts
{
    /// <summary>
    /// Defines the <see cref="FontAwesomeBrandsModule" /> icon module.
    /// </summary>
    /// <seealso cref="Plugin.Iconize.IconModule" />
    public sealed class FontAwesomeBrandsModule : IconModule
    {
		/// <summary>
		/// Initializes a new instance of the <see cref="FontAwesomeBrandsModule" /> class.
		/// </summary>
		public FontAwesomeBrandsModule()
            : base("FontAwesome", "FontAwesome-Brands", "iconize-fontawesome-brands.otf", FontAwesomeCollection.BrandIcons)
        {
            // Intentionally left blank
        }
    }
}