using System.Windows.Input;

namespace KeyboardTrainer.KeyChars
{
    internal static class ControlKeys
    {
        public static ControlKey Backspace { get; } = new ControlKey(Key.Back, "Backspace");

        public static ControlKey CapsLock { get; } = new ControlKey(Key.CapsLock, "Caps");

        public static ControlKey Enter { get; } = new ControlKey(Key.Return, "Enter");

        public static ControlKey LeftAlt { get; } = new ControlKey(Key.LeftAlt, "Alt");

        public static ControlKey LeftCtrl { get; } = new ControlKey(Key.LeftCtrl, "Ctrl");

        public static ControlKey LeftShift { get; } = new ControlKey(Key.LeftShift, "Shift");

        public static ControlKey LeftWin { get; } = new ControlKey(Key.LWin, "Win");

        public static ControlKey RightAlt { get; } = new ControlKey(Key.RightAlt, "Alt");

        public static ControlKey RightCtrl { get; } = new ControlKey(Key.RightCtrl, "Ctrl");

        public static ControlKey RightShift { get; } = new ControlKey(Key.RightShift, "Shift");

        public static ControlKey RightWin { get; } = new ControlKey(Key.RWin, "Win");

        public static ControlKey Tab { get; } = new ControlKey(Key.Tab, "Tab");
    }
}