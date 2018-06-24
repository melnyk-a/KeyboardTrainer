using System.Text;

namespace KeyboardTrainer.Models
{
    internal static class StringBuilderExtensions
    {
        public static bool Contain(this StringBuilder stringBuilder, char character)
        {
            bool isContain = false;
            for (int i = 0; i < stringBuilder.Length; ++i)
            {
                if (stringBuilder[i] == character)
                {
                    isContain = true;
                    break;
                }
            }
            return isContain;
        }
    }
}