using System.Collections.Generic;

namespace Plugin.Iconize.Fonts
{
    /// <summary>
    /// Defines the <see cref="MeteoconsCollection" /> icon collection.
    /// </summary>
    public static class MeteoconsCollection
    {
        /// <summary>
        /// Gets the icons.
        /// </summary>
        /// <value>
        /// The icons.
        /// </value>
        public static IList<IIcon> Icons { get; } = new List<IIcon>();

        /// <summary>
        /// Initializes the <see cref="MeteoconsCollection" /> class.
        /// </summary>
        static MeteoconsCollection()
        {
            Icons.Add("mc-sunrise-o", 'A');
            Icons.Add("mc-sun-o", 'B');
            Icons.Add("mc-moon-o", 'C');
            Icons.Add("mc-eclipse-o", 'D');
            Icons.Add("mc-cloudy-o", 'E');
            Icons.Add("mc-wind-o", 'F');
            Icons.Add("mc-snow-o", 'G');
            Icons.Add("mc-sun-cloud-o", 'H');
            Icons.Add("mc-moon-cloud-o", 'I');
            Icons.Add("mc-sunrise-sea-o", 'J');
            Icons.Add("mc-moonrise-sea-o", 'K');
            Icons.Add("mc-cloud-sea-o", 'L');
            Icons.Add("mc-sea-o", 'M');
            Icons.Add("mc-cloud-o", 'N');
            Icons.Add("mc-cloud-thunder-o", 'O');
            Icons.Add("mc-cloud-thunder2-o", 'P');
            Icons.Add("mc-cloud-drop-o", 'Q');
            Icons.Add("mc-cloud-rain-o", 'R');
            Icons.Add("mc-cloud-wind-o", 'S');
            Icons.Add("mc-cloud-wind-rain-o", 'T');
            Icons.Add("mc-cloud-snow-o", 'U');
            Icons.Add("mc-cloud-snow2-o", 'V');
            Icons.Add("mc-cloud-snow3-o", 'W');
            Icons.Add("mc-cloud-rain2-o", 'X');
            Icons.Add("mc-cloud-double-o", 'Y');
            Icons.Add("mc-cloud-double-thunder-o", 'Z');
            Icons.Add("mc-cloud-double-thunder2-o", '0');
            Icons.Add("mc-sun", '1');
            Icons.Add("mc-moon", '2');
            Icons.Add("mc-sun-cloud", '3');
            Icons.Add("mc-moon-cloud", '4');
            Icons.Add("mc-cloud", '5');
            Icons.Add("mc-cloud-thunder", '6');
            Icons.Add("mc-cloud-drop", '7');
            Icons.Add("mc-cloud-rain", '8');
            Icons.Add("mc-cloud-wind", '9');
            Icons.Add("mc-cloud-wind-rain", '!');
            Icons.Add("mc-cloud-snow", '"');
            Icons.Add("mc-cloud-snow2", '#');
            Icons.Add("mc-cloud-rain2", '$');
            Icons.Add("mc-cloud-double", '%');
            Icons.Add("mc-cloud-double-thunder", '&');
            Icons.Add("mc-thermometer", '\'');
            Icons.Add("mc-compass", '(');
            Icons.Add("mc-not-applicable", ')');
            Icons.Add("mc-celsius", '*');
            Icons.Add("mc-fahrenheit", '+');
        }
    }
}