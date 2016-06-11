using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;



namespace StorageAnalyzer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            string Current = System.IO.Directory.GetCurrentDirectory();
            InitializeComponent();
        }

       
        private void button1_MouseEnter(object sender, MouseEventArgs e)
        {
            Mouse.OverrideCursor = Cursors.Hand;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            using (var dialog = new System.Windows.Forms.FolderBrowserDialog())
            {
                if (dialog.ShowDialog(this.GetIWin32Window()) == System.Windows.Forms.DialogResult.OK)
                {
                    TextBoxOne.Text = dialog.SelectedPath;
                    VisualStorage NewWindow = new VisualStorage(dialog.SelectedPath);
                    NewWindow.Show();                    
                }
            }
            
           /* ProcessStartInfo startInfo = new ProcessStartInfo(@"d:\WinDirStat\windirstat.exe");
            startInfo.CreateNoWindow = false;
            startInfo.UseShellExecute = false;
            startInfo.FileName = "windirstat.exe";
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            Process.Start(startInfo);*/
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }      
        
    }
}
