using System;
using System.Windows.Input;

namespace KeyboardTrainer.EventArguments
{
    internal sealed class KeyboardKeyEventArgs : EventArgs
    {
        public KeyboardKeyEventArgs(Key key, bool capsIsToggled)
        {
            IsCapsToggled = capsIsToggled;
            Key = key;
        }

        public bool IsCapsToggled { get; }

        public Key Key { get; }
    }
}