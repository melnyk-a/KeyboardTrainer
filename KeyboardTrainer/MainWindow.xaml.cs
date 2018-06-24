using KeyboardTrainer.EventArguments;
using KeyboardTrainer.Views;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace KeyboardTrainer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    internal partial class MainWindow : Window, IKeyboardTrainerView
    {
        private readonly Dictionary<Key, TextBlock> keys = new Dictionary<Key, TextBlock>();

        public MainWindow()
        {
            InitializeComponent();
        }

        public bool CaseSensitive => caseSensitive.IsChecked == true ? true : false;

        public int Difficulty
        {
            get
            {
                int.TryParse(difficulty.Text, out int result);
                return result;
            }
        }

        public int Fails
        {
            get
            {
                int.TryParse(fails.Text, out int failsResult);
                return failsResult;
            }
            set => fails.Text = value.ToString();
        }

        public int Speed
        {
            get
            {
                int.TryParse(speed.Text, out int speedResult);
                return speedResult;
            }
            set => speed.Text = value.ToString();
        }

        public int StringLength
        {
            get => Convert.ToInt32(Lefted.ActualWidth / Lefted.FontSize);
        }

        public event EventHandler<KeyboardKeyEventArgs> KeyboardKeyDown;
        public event EventHandler<KeyboardKeyEventArgs> KeyboardKeyLoaded;
        public event EventHandler<KeyboardKeyEventArgs> KeyboardKeyUp;
        public event EventHandler Start;

        private void ActivateControls(bool isActive)
        {
            startButton.IsEnabled = isActive;
            stopButton.IsEnabled = !isActive;
            caseSensitive.IsEnabled = isActive;
            difficultySlider.IsEnabled = isActive;
        }

        public void Finish()
        {
            ActivateControls(true);
        }

        private void ShowKeyDown(Key key)
        {
            bool isExist = keys.TryGetValue(key, out TextBlock textBlock);
            if (isExist)
            {
                Border border = keys[key].Parent as Border;
                border.BorderThickness = new Thickness(6);
                keys[key].Padding = new Thickness(0);
                border.BorderBrush = new SolidColorBrush(Colors.LimeGreen);
            }
        }

        private void ShowKeyUp(Key key)
        {
            bool isExist = keys.TryGetValue(key, out TextBlock textBlock);
            if (isExist)
            {
                Border border = keys[key].Parent as Border;
                border.BorderThickness = new Thickness(1);
                keys[key].Padding = new Thickness(5);
                border.BorderBrush = new SolidColorBrush(Colors.Black);
            }
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            difficulty.Text = Convert.ToInt32(e.NewValue).ToString();
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            Start?.Invoke(this, EventArgs.Empty);
            ActivateControls(false);
        }

        private void StopButton_Click(object sender, RoutedEventArgs e)
        {
            ActivateControls(true);
        }

        private void TextBlock_Loaded(object sender, RoutedEventArgs e)
        {
            TextBlock textBlock = sender as TextBlock;
            Key key = (Key)textBlock.Tag;
            keys.Add(key, textBlock);
            KeyboardKeyLoaded?.Invoke(this, new KeyboardKeyEventArgs(key, Keyboard.IsKeyToggled(Key.CapsLock)));
        }

        public void UpdateKey(Key key, string content)
        {
            TextBlock textBlock = keys[key];
            textBlock.Text = content;
        }

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (!startButton.IsEnabled)
            {
                if (e.Key == Key.LeftAlt || e.Key == Key.RightAlt)
                {
                    e.Handled = true;
                }
                KeyboardKeyDown?.Invoke(this, new KeyboardKeyEventArgs(e.Key, Keyboard.IsKeyToggled(Key.CapsLock)));
                ShowKeyDown(e.Key);
            }
        }

        private void Window_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            if (!startButton.IsEnabled)
            {
                KeyboardKeyUp?.Invoke(
                    this, 
                    new KeyboardKeyEventArgs(e.Key, Keyboard.IsKeyToggled(Key.CapsLock))
                    );
                ShowKeyUp(e.Key);
            }
        }

        public void UpdateInputString(string content)
        {
            Input.Text = content;
        }

        public void UpdateLeftedString(string content)
        {
            Lefted.Text = content;
        }
    }
}