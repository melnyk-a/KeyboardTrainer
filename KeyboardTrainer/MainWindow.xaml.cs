using KeyboardTrainer.KeyChars;
using KeyboardTrainer.Models;
using KeyboardTrainer.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace KeyboardTrainer
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IKeyboardTrainerView
    {
        private readonly Dictionary<TextBlock, KeyChar> collection = new Dictionary<TextBlock, KeyChar>();
        DispatcherTimer timer = new DispatcherTimer();
        private int keyPerSeconds;

        DateTime first = new DateTime();
        DateTime second = new DateTime();
        public MainWindow()
        {
            InitializeComponent();

            Lefted.Text = SourceString.Source;

            first = DateTime.Now;
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += (sender, e) =>
              {
                  second = DateTime.Now;
                  speed.Text = (Math.Round(60*keyPerSeconds/second.Subtract(first).TotalSeconds)).ToString();
   
    
              };
            timer.Start();
        }



        private void TextBlock_Loaded(object sender, RoutedEventArgs e)
        {
            TextBlock textBlock = sender as TextBlock;
            KeyChar tag = textBlock.Tag as KeyChar;
            textBlock.Text = tag.ToString();
            collection.Add(textBlock, tag);

        }

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            KeyChar key;
            if (e.Key == Key.CapsLock)
            {
                foreach (var item in collection)
                {
                    key = item.Value;
                    if (key is AlphabeticKey alphabeticKey)
                    {
                        alphabeticKey.UpperCase = e.IsToggled;
                        item.Key.Text = alphabeticKey.ToString();
                    }

                }

            }
            if (e.Key == Key.LeftShift || e.Key == Key.RightShift)
            {
                foreach (var item in collection)
                {
                    key = item.Value;
                    if (key is AlphabeticKey alphabeticKey)
                    {
                        alphabeticKey.UpperCase = !e.KeyboardDevice.IsKeyToggled(Key.CapsLock);
                        item.Key.Text = alphabeticKey.ToString();
                    }
                    else if (key is SymbolKey symbolKey)
                    {
                        symbolKey.IsAdditionalSymbolActive = true;
                        item.Key.Text = symbolKey.ToString();
                    }
                }
            }


            foreach (var item in collection)
            {
                Key keyToCompare = e.Key == Key.System ? e.SystemKey : e.Key;
                key = item.Value;
                if (keyToCompare == key.VirtualKey)
                {
                    Border border = item.Key.Parent as Border;
                    border.BorderThickness = new Thickness(6);
                    item.Key.Padding = new Thickness(0);
                    border.BorderBrush = new SolidColorBrush(Colors.LimeGreen);

                    
                    ++keyPerSeconds;

                    char.TryParse(key.Content, out char result);
                    if(result==SourceString.Next)
                    {
                        stringBuilder.Append(item.Value.ToString());
                        Input.Text = stringBuilder.ToString();
                        if (SourceString.HasNext)
                        {
                            SourceString.Move();
                            Lefted.Text = SourceString.Source;
                        }
                        else
                        {
                            Lefted.Text = null;
                        }
                       
                    }
                    else
                    {

                        int.TryParse(fails.Text, out int failsResult);
                        ++failsResult;
                        fails.Text = failsResult.ToString();
                    }
                   
                }
                if(keyToCompare==Key.LeftAlt|| keyToCompare == Key.RightAlt)
                {
                    e.Handled = true;
                }
                
            }

            
            //Input.Inlines.Add(new Run("a") { Background = Brushes.LightPink });
            
        }

        

        private StringBuilder stringBuilder = new StringBuilder();
        private void Window_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.LeftShift || e.Key == Key.RightShift)
            {

                foreach (var item in collection)
                {
                    KeyChar key = item.Value;
                    if (key is AlphabeticKey alphabeticKey)
                    {
                        alphabeticKey.UpperCase = e.KeyboardDevice.IsKeyToggled(Key.CapsLock);
                        item.Key.Text = alphabeticKey.ToString();
                    }
                    else if (key is SymbolKey symbolKey)
                    {
                        symbolKey.IsAdditionalSymbolActive = false;
                        item.Key.Text = symbolKey.ToString();
                    }
                }
            }

            foreach (var item in collection)
            {
                Key keyToCompare = e.Key == Key.System ? e.SystemKey : e.Key;
                if (keyToCompare == item.Value.VirtualKey)
                {
                    Border border = item.Key.Parent as Border;
                    border.BorderThickness = new Thickness(1);
                    item.Key.Padding = new Thickness(5);
                    border.BorderBrush = new SolidColorBrush(Colors.Black);
                }

            }
        }


    }
}
