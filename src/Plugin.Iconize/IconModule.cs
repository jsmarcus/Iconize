using System;
using System.Collections.Generic;

namespace Plugin.Iconize
{
    /// <summary>
    /// Defines the <see cref="IIconModule" /> interface.
    /// </summary>
    public interface IIconModule
    {
        /// <summary>
        /// The characters in the font.
        /// </summary>
        ICollection<IIcon> Characters { get; }

        /// <summary>
        /// Gets the font family.
        /// </summary>
        /// <value>
        /// The font family.
        /// </value>
        String FontFamily { get; }

        /// <summary>
        /// Gets the name of the font.
        /// </summary>
        /// <value>
        /// The name of the font.
        /// </value>
        String FontName { get; }

        /// <summary>
        /// Gets the font path.
        /// </summary>
        /// <value>
        /// The font path.
        /// </value>
        String FontPath { get; }

        /// <summary>
        /// Gets or sets the keys.
        /// </summary>
        /// <value>
        /// The keys.
        /// </value>
        ICollection<String> Keys { get; }

        /// <summary>
        /// Gets the icon.
        /// </summary>
        /// <param name="iconKey">The icon key.</param>
        /// <returns></returns>
        IIcon GetIcon(String iconKey);

        /// <summary>
        /// Determines whether the specified icon is in the set.
        /// </summary>
        /// <param name="icon">The icon.</param>
        /// <returns></returns>
        Boolean HasIcon(IIcon icon);
    }

    /// <summary>
    /// Defines the <see cref="IconModule" /> type.
    /// </summary>
    /// <seealso cref="Plugin.Iconize.IIconModule" />
    public abstract class IconModule : IIconModule
    {
        /// <summary>
        /// The characters in the font.
        /// </summary>
        public ICollection<IIcon> Characters => Icons.Values;

        /// <summary>
        /// Gets the font family.
        /// </summary>
        /// <value>
        /// The font family.
        /// </value>
        public String FontFamily { get; }

        /// <summary>
        /// Gets the name of the font.
        /// </summary>
        /// <value>
        /// The name of the font.
        /// </value>
        public String FontName { get; }

        /// <summary>
        /// Gets the font path.
        /// </summary>
        /// <value>
        /// The font path.
        /// </value>
        public String FontPath { get; }

        /// <summary>
        /// Gets the icons.
        /// </summary>
        /// <value>
        /// The icons.
        /// </value>
        private Dictionary<String, IIcon> Icons { get; } = new Dictionary<String, IIcon>();

        /// <summary>
        /// Gets or sets the keys.
        /// </summary>
        /// <value>
        /// The keys.
        /// </value>
        public ICollection<String> Keys => Icons.Keys;

        /// <summary>
        /// Initializes a new instance of the <see cref="IconModule" /> class.
        /// </summary>
        /// <param name="fontFamily">The font family.</param>
        /// <param name="fontName">Name of the font.</param>
        /// <param name="fontPath">The font path.</param>
        /// <param name="icons">The icons.</param>
        protected IconModule(String fontFamily, String fontName, String fontPath, IEnumerable<IIcon> icons)
        {
            FontFamily = fontFamily;
            FontName = fontName;
            FontPath = fontPath;

            foreach (var icon in icons)
            {
                Icons.Add(icon.Key, icon);
            }
        }

        /// <summary>
        /// Gets the icon.
        /// </summary>
        /// <param name="iconKey">The key.</param>
        /// <returns></returns>
        public IIcon GetIcon(String iconKey)
        {
            return Icons.ContainsKey(iconKey) ? Icons[iconKey] : null;
        }

        /// <summary>
        /// Determines whether the specified icon is in the set.
        /// </summary>
        /// <param name="icon">The icon.</param>
        /// <returns></returns>
        public Boolean HasIcon(IIcon icon)
        {
            return Icons.ContainsValue(icon);
        }
    }
}