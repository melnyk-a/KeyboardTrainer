using System.Windows.Input;

namespace KeyboardTrainer.KeyChars
{
    internal sealed class SymbolKey : KeyChar
    {
        private readonly char additionalSymbol;
        private readonly char mainSymbol;

        public SymbolKey(Key virtualKey, char mainSymbol, char additionalSymbol) :
            base(virtualKey, mainSymbol.ToString())
        {
            this.mainSymbol = mainSymbol;
            this.additionalSymbol = additionalSymbol;
        }

        public bool IsAdditionalSymbolActive
        {
            get => content == mainSymbol.ToString();
            set => content = value ? additionalSymbol.ToString() : mainSymbol.ToString();
        }
    }
}