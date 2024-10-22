/*FILE: a02
 PROJECT : PROG2121 A-02
 PROGRAMMER : Joseph Colby Carson 8213035
 FIRST VERSION : 2023 / 09 / 26
 DESCRIPTION: a program that is a clone of notepad .*/
using System.IO;
using Microsoft.Win32;
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
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace a02
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly Random random = new Random();
        private string currentFile = null;
        private string originalText = null;
        private int keyCount = 0;
        private bool snooper = false;

        // Name    : MainWindow
        // Purpose : Initialises MainWindow also loads, textBox if you opened a file using the program. 
        // Inputs  : None
        // Returns : None
        public MainWindow()
        {
            InitializeComponent();
            originalText = textBox.Text;
        }
        // Name    : NewFile
        // Purpose : This allows the user to make a new tab, it asks to save any unsaved work
        // Inputs  : Object sender, RoutedEventArgs e
        // Returns : None
        private void NewFile(object sender, RoutedEventArgs e)
        {

            if (SavePrompt())
            {
                textBox.Text = string.Empty;
                currentFile = null;
                originalText = string.Empty;
                ChangeTitle();
            }
        }
        // Name    : OpenClick
        // Purpose : This allows the user to open a text file
        // Inputs  : Object sender, RoutedEventArgs e
        // Returns : None
        private void OpenClick(object sender, RoutedEventArgs e)
        {

            if (SavePrompt())
            {
                OpenFileDialog of = new OpenFileDialog();
                if (of.ShowDialog() == true)
                {
                    currentFile = of.FileName;
                    originalText = File.ReadAllText(currentFile);
                    textBox.Text = originalText;
                    ChangeTitle();
                }
            }
        }
        // Name    : SavePrompt
        // Purpose : This loads a prompt for saving incase you have not saved current file
        // Inputs  : Object sender, RoutedEventArgs e
        // Returns : None
        private bool SavePrompt()
        {
            if (originalText != textBox.Text)
            {
                MessageBoxResult result = MessageBox.Show("Do you want to save this document?", "Unsaved Work", MessageBoxButton.YesNoCancel);
                if (result == MessageBoxResult.Yes)
                {
                    SaveClick(this, null);
                }
                else if (result == MessageBoxResult.Cancel)
                {
                    return false;
                }
            }
            return true;
        }
        // Name    : SaveClick
        // Purpose : this saves the program to current file, if no file it allows user to choose file location
        // Inputs  : Object sender, RoutedEventArgs e
        // Returns : None
        private void SaveClick(object sender, RoutedEventArgs e)
        {
            if (currentFile != null)
            {
                File.WriteAllText(currentFile, textBox.Text);
                currentFile = System.IO.Path.GetFileName(currentFile);
                originalText = textBox.Text;
            }
            else
            {
                SaveAsClick(sender, e);
            }
        }
        // Name    : SaveAsclick
        // Purpose : This allows the user to select a location to save a file to
        // Inputs  : Object sender, RoutedEventArgs e
        // Returns : None
        private void SaveAsClick(object sender, RoutedEventArgs e)
        {
            SaveFileDialog of = new SaveFileDialog
            {
                Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*"
            };
            if (of.ShowDialog() == true)
            {
                currentFile = of.FileName;
                File.WriteAllText(currentFile, textBox.Text);
                originalText = textBox.Text;
                ChangeTitle();
            }
        }
        // Name    : ChangeTitle
        // Purpose : Check is the filename is null it makes the filename Untitled else it makes it the currentFile name
        // Inputs  : Object sender, RoutedEventArgs e
        // Returns : None
        private void ChangeTitle()
        {
            string fileName = currentFile != null ? System.IO.Path.GetFileName(currentFile) : "Untitled";
            this.Title = "Notepad A02 - " + fileName;
        }
        // Name    : ExitClick
        // Purpose :  This closes the program
        // Inputs  : Object sender, RoutedEventArgs e
        // Returns : None
        private void ExitClick(object sender, RoutedEventArgs e)
        {
            if (SavePrompt())
            {
                Close();
            }
        }
        // Name    : AboutClick
        // Purpose : This Shows an about message box for the program
        // Inputs  : Object sender, RoutedEventArgs e
        // Returns : None
        private void AboutClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("About this App\nConestogaSET NotePad 1.0\n© 2023 ConestogaSET. All rights reserved\nThere is a hidden EasterEgg in this APP", "About", MessageBoxButton.OK, MessageBoxImage.Question);
        }
        // Name    : KeyPress
        // Purpose : This detects keypresses or changes in the text box and updates status value
        // Inputs  : Object sender, RoutedEventArgs e
        // Returns : None
        private void KeyPress(object sender, RoutedEventArgs e)
        {
            if (snooper) MoreFun();
            keyCount = textBox.Text.Length;
            string count = "Characters: " + keyCount;
            CharacterCount.Text = count;
        }
        // Name    : DarkMode
        // Purpose : This switches the color values to dark mode
        // Inputs  : Object sender, RoutedEventArgs e
        // Returns : None
        private void DarkMode(object sender, RoutedEventArgs e)
        {
            menu.Background = Brushes.Black;
            menu.Foreground = Brushes.WhiteSmoke;
            textBox.Background = Brushes.Black;
            textBox.Foreground = Brushes.LightGray;
            statusBar.Background = Brushes.Black;
            statusBar.Foreground = Brushes.WhiteSmoke;
            checkBox.Background = Brushes.Black;
            checkBox.Foreground = Brushes.LightGray;

            //Its faster than putting this into a loop as it takes more clks to run a loop
            menu1.Foreground = Brushes.Black;
            menu2.Foreground = Brushes.Black;
            menu3.Foreground = Brushes.Black;
            menu4.Foreground = Brushes.Black;
            menu5.Foreground = Brushes.Black;
            menu6.Foreground = Brushes.Black;
            menu7.Foreground = Brushes.Black;
            menu8.Foreground = Brushes.Black;
            menu9.Foreground = Brushes.Black;
            menu10.Foreground = Brushes.Black;



        }
        // Name    : LightMode
        // Purpose : This switches the color values to Light mode
        // Inputs  : Object sender, RoutedEventArgs e
        // Returns : None
        private void LightMode(object sender, RoutedEventArgs e)
        {
            menu.Background = Brushes.WhiteSmoke;
            menu.Foreground = Brushes.Black;
            textBox.Background = Brushes.White;
            textBox.Foreground = Brushes.Black;
            statusBar.Background = Brushes.WhiteSmoke;
            statusBar.Foreground = Brushes.Black;
            checkBox.Background = Brushes.White;
            checkBox.Foreground = Brushes.Black;
        }
        // Name    : SnooperClick
        // Purpose : This is an easter egg no hints Encrypted!!T̴̯̼͓̝̝̖͖̜̪̺͔̤̂̓́̒̊̀̀̑̔͂͆̔̚͝͝ͅh̵̩̜̻͗̾̈́̈́͊ȋ̶̢̧̛̺̳͇̗̻̺̫͉̙͒̈͒͂͗͑̏͜͜͝ͅs̷̨̡̲̼̩͚͚̗͙͒̑͂͊̕̚͜Encrypted!!
        // Inputs  : Object sender, RoutedEventArgs e
        // Returns : None
        private void SnooperClick(object sender, RoutedEventArgs e)
        {
            SavePrompt();
            snooper = true;
            //Reference https://ascii.co.uk/art/turtle
            textBox.Text = "                _,.---.---.---.--.._ \r\n            _.-' `--.`---.`---'-. _,`--.._\r\n           /`--._ .'.     `.     `,`-.`-._\\\r\n          ||   \\  `.`---.__`__..-`. ,'`-._/\r\n     _   , `\\ `-._\\   \\    `.    `_.-`-._,``-.\r\n  ,`    ` - _ \\/ `-.`--.\\    _\\_.-'\\__.-`-.`-._`.\r\n (_.o> ,--. `._/'--.-`,--`  \\_.-'         \\`-._ \\\r\n  `---'    `._ `---._/__,----`             `-. `-\\\r\n            /_, ,  _..-'                        `-._\\\r\n            \\_, \\/ ._(\r\n             \\_, \\/ ._\\\r\n              `._,\\/ ._\\\r\n                `._// ./`-._\r\n                  `-._-_-_.-'\r\nThis Is Clearly A Turtle";
        }
        // Name    : MoreFun()
        // Purpose : This is an easter egg no hints Encrypted!!T̴̯̼͓̝̝̖͖̜̪̺͔̤̂̓́̒̊̀̀̑̔͂͆̔̚͝͝ͅh̵̩̜̻͗̾̈́̈́͊ȋ̶̢̧̛̺̳͇̗̻̺̫͉̙͒̈͒͂͗͑̏͜͜͝ͅs̷̨̡̲̼̩͚͚̗͙͒̑͂͊̕̚͜Encrypted!!
        // Inputs  : None
        // Returns : None
        private void MoreFun()
        {
            string[] colors = { "Red", "Blue", "Green", "Purple", "Yellow", "Orange", "Pink", "Indigo" };
            int randomIndex = random.Next(colors.Length);
            string randomColorName = colors[randomIndex];

            switch (randomColorName)
            {
                case "Red":
                    textBox.Background = Brushes.Red;
                    return;
                case "Blue":
                    textBox.Background = Brushes.Blue;
                    return;
                case "Green":
                    textBox.Background = Brushes.LimeGreen;
                    return;
                case "Purple":
                    textBox.Background = Brushes.Purple;
                    return;
                case "Yellow":
                    textBox.Background = Brushes.Yellow;
                    return;
                case "Orange":
                    textBox.Background = Brushes.Orange;
                    return;
                case "Pink":
                    textBox.Background = Brushes.Pink;
                    return;
                case "Indigo":
                    textBox.Background = Brushes.Indigo;
                    return;
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!SavePrompt())
            {
                e.Cancel = true;
            }
        }
    }
}
