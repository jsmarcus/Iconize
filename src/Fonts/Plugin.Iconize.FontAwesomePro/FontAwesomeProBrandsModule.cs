namespace Plugin.Iconize.Fonts
{
	/// <summary>
    /// Defines the <see cref="FontAwesomeProBrandsModule" /> icon module.
    /// </summary>
    /// <seealso cref="Plugin.Iconize.IconModule" />
    public sealed class FontAwesomeProBrandsModule : IconModule
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FontAwesomeProBrandsModule" /> class.
        /// </summary>
        public FontAwesomeProBrandsModule()
            : base("Font Awesome 5 Pro Brands", "FontAwesome5ProBrands-Regular", "iconize-fontawesome-pro-brands.ttf", FontAwesomeProCollection.BrandIcons)
        {
            // Intentionally left blank
        }
    }
}