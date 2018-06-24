using KeyboardTrainer.EventArguments;
using System;
using System.Windows.Input;

namespace KeyboardTrainer.Views
{
    internal interface IKeyboardTrainerView
    {
        bool CaseSensitive { get; }
        int Difficulty { get; } 
        int Fails { get; set; }
        int Speed { get; set; }
        int StringLength { get; }

        event EventHandler<KeyboardKeyEventArgs> KeyboardKeyDown;
        event EventHandler<KeyboardKeyEventArgs> KeyboardKeyLoaded;
        event EventHandler<KeyboardKeyEventArgs> KeyboardKeyUp;
        event EventHandler Start;

        void Show();
        void UpdateKey(Key key, string content);
        void UpdateLeftedString(string content);
        void UpdateInputString(string content);
        void Finish();
    }
}