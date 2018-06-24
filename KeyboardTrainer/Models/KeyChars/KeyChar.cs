using System.Windows.Input;

namespace KeyboardTrainer.KeyChars
{
    internal abstract class KeyChar
    {
        protected string content;
        private readonly Key virtualKey;

        public KeyChar(Key virtualKey, string content)
        {
            this.content = content;
            this.virtualKey = virtualKey;
        }

        public string Content
        {
            get => content;
            set => content = value;
        }

        public Key VirtualKey => virtualKey;
    }
}