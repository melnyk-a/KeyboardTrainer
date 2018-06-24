using System;
using System.Text;

namespace KeyboardTrainer.Models
{
    internal sealed class StringCreator
    {
        private const int evarengeWordLength = 7;
        private const string validChars = "abcdefghijklmnopqrstuvwxyz1234567890`~-_=+[];',./\\|{}:\"<>?";
        private readonly Random random = new Random();

        private string CreateRandomChars(int range)
        {
            StringBuilder stringBuilder = new StringBuilder();
            do
            {
                char randomChar = validChars[random.Next(0, validChars.Length)];
                if (!stringBuilder.Contain(randomChar))
                {
                    stringBuilder.Append(randomChar);
                }
            } while (stringBuilder.Length != range);

            return stringBuilder.ToString();
        }

        public string CreateString(int length, int range, bool isCaseSensitive)
        {
            StringBuilder stringBuilder = new StringBuilder();
            string validChars = CreateRandomChars(range);
            int wordLength = random.Next(1, evarengeWordLength);
            int wordIndex = 0;

            for (int i = 0; i < length; i++)
            {
                if (wordIndex == wordLength)
                {
                    wordLength = random.Next(1, 8);
                    wordIndex = 0;
                    stringBuilder.Append(' ');
                }
                else if (i != length - 1)
                {
                    char randomChar = validChars[random.Next(0, validChars.Length)];
                    stringBuilder.Append(randomChar);
                    ++wordIndex;
                }
            }

            if (isCaseSensitive)
            {
                for (int i = 0; i < stringBuilder.Length; ++i)
                {
                    if (char.IsLetter(stringBuilder[i]))
                    {
                        bool needToUpper = random.Next(100) < 50 ? true : false;
                        if (needToUpper)
                        {
                            stringBuilder[i] = char.ToUpper(stringBuilder[i]);
                        }
                    }
                }
            }
            return stringBuilder.ToString();
        }
    }
}