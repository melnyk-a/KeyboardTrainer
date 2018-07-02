using System;
using System.Windows.Input;

namespace KeyboardTrainer.KeyChars
{
    internal sealed class AlphabeticKey : KeyChar
    {
        private readonly char lowerCase;
        private readonly char upperCase;

        public AlphabeticKey(Key virtualKey, char alphabeticSymbol) :
            base(virtualKey, char.ToLower(alphabeticSymbol).ToString())
        {
            lowerCase = char.ToLower(alphabeticSymbol);
            upperCase = char.ToUpper(alphabeticSymbol);
        }

        public bool UpperCase
        {
            get => content == upperCase.ToString();
            set => content = value ? upperCase.ToString() : lowerCase.ToString();
        }
    }
}