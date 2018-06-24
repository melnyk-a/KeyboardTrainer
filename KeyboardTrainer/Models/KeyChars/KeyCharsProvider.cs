using KeyboardTrainer.KeyChars;
using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace KeyboardTrainer.Models.KeyChars
{
    internal sealed class KeyCharsProvider
    {
        private readonly List<KeyChar> keyChars = new List<KeyChar>();

        public KeyCharsProvider()
        {
            FillWithPropertiesOfType(typeof(AlphabeticKeys));
            FillWithPropertiesOfType(typeof(SymbolKeys));
            FillWithPropertiesOfType(typeof(ControlKeys));
        }

        public IEnumerable<KeyChar> KeyChars => keyChars;

        private void FillWithPropertiesOfType(Type type)
        {
            foreach (var property in type.GetProperties())
            {
                keyChars.Add(property.GetValue(null) as KeyChar);
            }
        }
       
        public KeyChar Find(Key key)
        {
            KeyChar finded = null;
            finded = keyChars.Find(keyChar => keyChar.VirtualKey == key);
            return finded;
        }
    }
}