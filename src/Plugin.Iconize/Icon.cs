using System;

namespace Plugin.Iconize
{
    /// <summary>
    /// Icon represents one icon in an icon font.
    /// </summary>
    public interface IIcon
    {
        /// <summary>
        /// The key of icon, for example 'fa-ok'
        /// </summary>
        /// <returns></returns>
        String Key { get; }

        /// <summary>
        /// The character matching the key in the font, for example '\u4354'
        /// </summary>
        /// <returns></returns>
        Char Character { get; }
    }

    /// <summary>
    /// Defines the <see cref="Icon" /> type.
    /// </summary>
    /// <seealso cref="Plugin.Iconize.IIcon" />
    public class Icon : IIcon
    {
        /// <summary>
        /// The character matching the key in the font, for example '\u4354'
        /// </summary>
        public Char Character { get; }

        /// <summary>
        /// The key of icon, for example 'fa-ok'
        /// </summary>
        public String Key { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Icon" /> class.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="character">The character.</param>
        public Icon(String key, Char character)
        {
            Character = character;
            Key = key;
        }
    }
}