namespace CDADMTEST
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Random string generator.
    /// </summary>
    internal class RandomStringGenerator
    {
        /// <summary>
        /// The _characters.
        /// </summary>
        private readonly List<char> _characters;

        /// <summary>
        /// The random.
        /// </summary>
        private readonly Random _random = new Random();

        /// <summary>
        /// Initializes a new instance of the <see cref="RandomStringGenerator"/> class.
        /// </summary>
        public RandomStringGenerator()
        {
            _characters = new List<char>();

            // Fill character list with A-Z.
            for (int i = 65; i <= 90; i++)
            {
                _characters.Add((char)i);
            }

            // Fill character list with a-z.
            for (int i = 97; i <= 122; i++)
            {
                _characters.Add((char)i);
            }

            // Fill character list with 0-9.
            for (int i = 48; i <= 57; i++)
            {
                _characters.Add((char)i);
            }
        }

        /// <summary>
        /// Generate random string.
        /// </summary>
        /// <param name="lenght">
        /// Number of symbols.
        /// </param>
        /// <returns>
        /// Random string.
        /// </returns>
        public string Generate(int lenght)
        {
            StringBuilder buffer = new StringBuilder(lenght);
            for (int i = 0; i < lenght; i++)
            {
                int randomNumber = _random.Next(0, _characters.Count);
                char randomChar = _characters[randomNumber];
                buffer.Append(randomChar);
            }

            return buffer.ToString();
        }
    }
}