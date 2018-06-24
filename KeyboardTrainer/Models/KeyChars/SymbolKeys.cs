using System.Windows.Input;

namespace KeyboardTrainer.KeyChars
{
    internal static class SymbolKeys
    {
        public static SymbolKey D0 { get; } = new SymbolKey(Key.D0, '0', ')');

        public static SymbolKey D1 { get; } = new SymbolKey(Key.D1, '1', '!');

        public static SymbolKey D2 { get; } = new SymbolKey(Key.D2, '2', '@');

        public static SymbolKey D3 { get; } = new SymbolKey(Key.D3, '3', '#');

        public static SymbolKey D4 { get; } = new SymbolKey(Key.D4, '4', '$');

        public static SymbolKey D5 { get; } = new SymbolKey(Key.D5, '5', '%');

        public static SymbolKey D6 { get; } = new SymbolKey(Key.D6, '6', '^');

        public static SymbolKey D7 { get; } = new SymbolKey(Key.D7, '7', '&');

        public static SymbolKey D8 { get; } = new SymbolKey(Key.D8, '8', '*');

        public static SymbolKey D9 { get; } = new SymbolKey(Key.D9, '9', '(');

        public static SymbolKey Oem1 { get; } = new SymbolKey(Key.Oem1, ';', ':');

        public static SymbolKey Oem3 { get; } = new SymbolKey(Key.Oem3, '`', '~');

        public static SymbolKey Oem5 { get; } = new SymbolKey(Key.Oem5, '\\', '|');

        public static SymbolKey Oem6 { get; } = new SymbolKey(Key.Oem6, ']', '}');

        public static SymbolKey OemCommas { get; } = new SymbolKey(Key.OemComma, ',', '<');

        public static SymbolKey OemMinus { get; } = new SymbolKey(Key.OemMinus, '-', '_');

        public static SymbolKey OemOpenBrackets { get; } = new SymbolKey(Key.OemOpenBrackets, '[', '{');

        public static SymbolKey OemPeriod { get; } = new SymbolKey(Key.OemPeriod, '.', '>');

        public static SymbolKey OemPlus { get; } = new SymbolKey(Key.OemPlus, '=', '+');

        public static SymbolKey OemQuestion { get; } = new SymbolKey(Key.OemQuestion, '/', '?');

        public static SymbolKey OemQuotes { get; } = new SymbolKey(Key.OemQuotes, '\'', '"');

        public static SymbolKey Space { get; } = new SymbolKey(Key.Space, ' ', ' ');
    }
}