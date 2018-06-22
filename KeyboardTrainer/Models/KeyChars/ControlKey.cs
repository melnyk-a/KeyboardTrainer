using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace KeyboardTrainer.KeyChars
{
    internal sealed class ControlKey : KeyChar
    {
        public ControlKey(Key virtualKey, string content) : base(virtualKey, content)
        {

        }
    }
}