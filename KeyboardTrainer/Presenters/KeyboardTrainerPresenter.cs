using KeyboardTrainer.EventArguments;
using KeyboardTrainer.KeyChars;
using KeyboardTrainer.Models;
using KeyboardTrainer.Models.KeyChars;
using KeyboardTrainer.Views;
using System;
using System.Windows.Input;
using System.Windows.Threading;

namespace KeyboardTrainer.Presenters
{
    internal sealed class KeyboardTrainerPresenter : IPresenter
    {
        private readonly KeyCharsProvider keyCharsProvider;
        private readonly SourceString sourceString;
        private readonly SpeedCalculator speedCalculator;
        private readonly DispatcherTimer timer = new DispatcherTimer();
        private readonly IKeyboardTrainerView view;

        public KeyboardTrainerPresenter(
            IKeyboardTrainerView view, 
            KeyCharsProvider keyCharsProvider, 
            SourceString sourceString, 
            SpeedCalculator speedCalculator
            )
        {
            this.keyCharsProvider = keyCharsProvider;
            this.sourceString = sourceString;
            this.speedCalculator = speedCalculator;
            this.view = view;

            SetUpTimer();
            SubscribeToEvent();
        }

        private void ChangeAlphabeticKeyRegister(bool isUpper)
        {
            foreach (KeyChar keyChar in keyCharsProvider.KeyChars)
            {
                if (keyChar is AlphabeticKey alphabeticKey)
                {
                    alphabeticKey.UpperCase = isUpper;
                    view.UpdateKey(keyChar.VirtualKey, keyChar.Content);
                }
            }
        }

        private void ChangeSymbolKeys(bool isAdditionalKeyActive)
        {
            foreach (KeyChar keyChar in keyCharsProvider.KeyChars)
            {
                if (keyChar is SymbolKey symbolKey)
                {
                    symbolKey.IsAdditionalSymbolActive = isAdditionalKeyActive;
                    view.UpdateKey(keyChar.VirtualKey, keyChar.Content);
                }
            }
        }

        private void CheckInput(KeyChar key)
        {
            if (Convert.ToChar(key.Content) == sourceString.Next)
            {
                sourceString.Move();
                view.UpdateInputString(sourceString.PassedSubstring);
                view.UpdateLeftedString(sourceString.LeftedSubString);
                if (!sourceString.HasNext)
                {
                    view.UpdateLeftedString(null);
                    view.Finish();
                    timer.Stop();
                }
            }
            else
            {
                view.Fails = ++view.Fails;
            }
            speedCalculator.ActionDone();
        }

        private void SetUpTimer()
        {
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += (sender, e) =>
            {
                view.Speed = Convert.ToInt32(speedCalculator.Speed);
                speedCalculator.SecondPassed();
            };
        }

        private void SubscribeToEvent()
        {
            view.KeyboardKeyLoaded += View_KeyLoaded;
            view.KeyboardKeyDown += View_KeyboardKeyDown;
            view.KeyboardKeyUp += View_KeyboardKeyUp;
            view.Start += View_Start;
        }

        private void View_Start(object sender, EventArgs e)
        {
            sourceString.Create(view.StringLength, view.Difficulty, view.CaseSensitive);
            view.UpdateInputString(null);
            view.UpdateLeftedString(sourceString.LeftedSubString);
            view.Fails = 0;
            view.Speed = 0;
            timer.Start();
            speedCalculator.StartCounting();
        }

        private void View_KeyboardKeyDown(object sender, KeyboardKeyEventArgs e)
        {
            if (e.Key == Key.CapsLock)
            {
                ChangeAlphabeticKeyRegister(e.IsCapsToggled);
            }
            else if (e.Key == Key.LeftShift || e.Key == Key.RightShift)
            {
                ChangeAlphabeticKeyRegister(!e.IsCapsToggled);
                ChangeSymbolKeys(true);
            }
        }

        private void View_KeyboardKeyUp(object sender, KeyboardKeyEventArgs e)
        {
            KeyChar pressedKey = keyCharsProvider.Find(e.Key);

            if (e.Key == Key.CapsLock)
            {
                ChangeAlphabeticKeyRegister(e.IsCapsToggled);
            }
            else if (e.Key == Key.LeftShift || e.Key == Key.RightShift)
            {
                ChangeAlphabeticKeyRegister(e.IsCapsToggled);
                ChangeSymbolKeys(false);
            }
            else if (pressedKey is SymbolKey || pressedKey is AlphabeticKey)
            {
                CheckInput(pressedKey);
            }
        }

        private void View_KeyLoaded(object sender, KeyboardKeyEventArgs e)
        {
            KeyChar keyChar = keyCharsProvider.Find(e.Key);
            if (keyChar is AlphabeticKey alphabeticKey)
            {
                alphabeticKey.UpperCase = e.IsCapsToggled;
            }
            view.UpdateKey(e.Key, keyChar.Content);
        }

        public void Run()
        {
            view.Show();
        }
    }
}