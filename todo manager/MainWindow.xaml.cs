using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
using System.IO;
using System.Text.RegularExpressions;
namespace todo_manager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ReadDB();
        }
        private void Add(object sender, RoutedEventArgs e)
        {
            string ttl = title.Text.Trim();
            if (ttl.Length == 0) { MessageBox.Show("Empty title"); return; }
            string description = GetRichTextBoxText(descr);

            Container.Items.Add(CreateItem(ttl, description));
            Save();
        }
        public static string GetRichTextBoxText(RichTextBox richTextBox)
        {
            // Create a TextRange object to represent the content of the RichTextBox.
            TextRange textRange = new TextRange(richTextBox.Document.ContentStart, richTextBox.Document.ContentEnd);

            // Use the Text property of the TextRange to get the text in the RichTextBox.
            return textRange.Text;
        }
        public ListBoxItem CreateItem(string title, string description)
        {
            ListBoxItem ls = new ListBoxItem();
            StackPanel panel = new StackPanel();
            panel.Orientation = Orientation.Horizontal;
            panel.Width = 300;
            TextBlock txt = new TextBlock();
            txt.Width = 250;
            txt.Text = title;
            panel.Children.Add(txt);
            Button btn = new Button();
             CheckBox chk = new CheckBox();
            chk.Checked += (sender, e) => { ls.Background = Brushes.Green; };
            chk.Unchecked += (sender, e) => { ls.Background = Brushes.White; };
            panel.Children.Add(chk);
            ls.Content = panel;
            ls.ToolTip = description;

            return ls;
        }
        public void Create(string title, string description)
        {
            ListBoxItem ls = new ListBoxItem();
            StackPanel panel = new StackPanel();
            panel.Orientation = Orientation.Horizontal;
            panel.Width = 300;
            TextBlock txt = new TextBlock();
            txt.Text = title;
            txt.Width = 250;
            panel.Children.Add(txt);
            Button btn = new Button();
            CheckBox chk = new CheckBox();
            chk.Checked += (sender, e) => { ls.Background = Brushes.Green; };
            chk.Unchecked += (sender, e) => { ls.Background = Brushes.White; };
            panel.Children.Add(chk);
            ls.Content = panel;
            ls.ToolTip = description;

            Container.Items.Add( ls);
        }
        private void Delete(object sender, MouseButtonEventArgs e)
        {
            Container.Items.Remove(Container.SelectedItem);
            Save();
        }
        private void Save()
        {
            StringBuilder sb = new StringBuilder();
            foreach (object item   in Container.Items)
            {
                ListBoxItem i = item as ListBoxItem;
                 
                StackPanel s = i.Content as StackPanel;
              
                TextBlock t = s.Children[0] as TextBlock;   
               sb.AppendLine("(" + t.Text + "|"  + i.ToolTip + ")");
            }
            string local = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Database.txt");
            File.WriteAllText(local,sb.ToString());
        }
        private void Fill(List<Task> tasks)
        {
            foreach (Task t in tasks)
            {
                Create(t.title, t.description);
            }
        }
        private void ReadDB()
        {
            string local = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Database.txt");
            if (File.Exists(local))
            {
                string content = File.ReadAllText(local);
                
                List<Task> list = GetTasks(content);
                Fill(list);
            }
        }
        private static List<Task> GetTasks(string content)
        {
            List<Task> tasks = new List<Task>();

            // Regular expression pattern to match items inside parentheses
            string pattern = @"\(([^)]*)\)";


            MatchCollection matches = Regex.Matches(content, pattern);
           
            foreach (Match match in matches)
            {
                string m = match.ToString();
                string clean = RemoveFirstAndLastCharacter(m);
              
                string[] parts = clean.Split('|');
              
                tasks.Add(new Task(parts[0], parts[1]));

            }

            return tasks;
        }
        private static string RemoveFirstAndLastCharacter(string input)
        {
            if (string.IsNullOrEmpty(input) || input.Length <= 2)
            {
                // If the input string is null, empty, or has only one or two characters, 
                // we cannot remove the first and last characters
                return input;
            }
            else
            {
                // Remove the first and last characters using substring
                return input.Substring(1, input.Length - 2);
            }
        }
    }
    class Task
    {
        public string title;
        public string description;
        public Task(string t, string d) { title = t; description = d; }
    }
}
