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
}
