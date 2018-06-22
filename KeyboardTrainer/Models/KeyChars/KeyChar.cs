using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace KeyboardTrainer.KeyChars
{
    internal abstract class KeyChar
    {
        protected string content;
        private Key virtualKey;

        public KeyChar(Key virtualKey, string content)
        {
            this.content = content;
            this.virtualKey = virtualKey;
        }
        public string Content { get=> content; set=>content=value; }

        public Key VirtualKey => virtualKey;
        public override string ToString()
        {
            return content;
        }
    }
}