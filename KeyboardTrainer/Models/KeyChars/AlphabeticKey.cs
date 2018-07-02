using System;
using System.Windows.Input;

namespace KeyboardTrainer.KeyChars
{
    internal sealed class AlphabeticKey : KeyChar
    {
        private readonly char lowerCase;
        private readonly char upperCase;

        public AlphabeticKey(Key virtualKey, char alphabeticSymbol) :
            base(virtualKey, Char.ToLower(alphabeticSymbol).ToString())
        {
            lowerCase = Char.ToLower(alphabeticSymbol);
            upperCase = Char.ToUpper(alphabeticSymbol);
        }

        public bool UpperCase
        {
            get => content == upperCase.ToString();
            set => content = value ? upperCase.ToString() : lowerCase.ToString();
        }
    }
}