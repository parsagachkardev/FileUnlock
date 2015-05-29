using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using Microsoft.Win32;

namespace FileUnlock
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            TitleTextBlock.Text = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name +" v"+ System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }

        public void Unlock(String s)
        {
            File.Move(s, s + "Unlocked");
        }
        private void Grid_Drop(object sender, DragEventArgs e)
        {
            
                (((String[])e.Data.GetData(DataFormats.FileDrop)).ToList()).ForEach(Unlock);
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "*.*|*.*";
            ofd.ShowDialog();
            if (ofd.FileNames != null)
            {
                ofd.FileNames.ToList().ForEach(Unlock);
            }

        }

        private void Hyperlink_OnRequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;

        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                DragMove();
            }

        }
    }
}
