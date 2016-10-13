using System;
using System.Collections.Generic;
using System.Linq;

namespace Plugin.Iconize
{
    /// <summary>
    /// Defines the <see cref="IconModule" /> type.
    /// </summary>
    /// <seealso cref="Plugin.Iconize.IIconModule" />
    public abstract class IconModule : IIconModule
    {
        #region Members

        private readonly Dictionary<String, IIcon> _icons = new Dictionary<String, IIcon>();

        #endregion Members

        #region Properties

        /// <summary>
        /// The characters in the font.
        /// </summary>
        public ICollection<IIcon> Characters => _icons.Values;

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
        /// Gets or sets the keys.
        /// </summary>
        /// <value>
        /// The keys.
        /// </value>
        public ICollection<String> Keys => _icons.Keys;

        #endregion Properties

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
                _icons.Add(icon.Key, icon);
            }
        }

        /// <summary>
        /// Gets the icon.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public IIcon GetIcon(String key)
        {
            if (_icons.ContainsKey(key))
            {
                return _icons[key];
            }
            return null;
        }

        /// <summary>
        /// Determines whether the specified icon is in the set.
        /// </summary>
        /// <param name="icon">The icon.</param>
        /// <returns></returns>
        public Boolean HasIcon(IIcon icon)
        {
            return _icons.Values.Contains(icon);
        }
    }
}