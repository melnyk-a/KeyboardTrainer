using System.Windows.Input;

namespace KeyboardTrainer.KeyChars
{
    internal sealed class ControlKey : KeyChar
    {
        public ControlKey(Key virtualKey, string content) :
            base(virtualKey, content)
        {
        }
    }
}