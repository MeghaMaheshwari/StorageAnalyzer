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
using System.Windows.Shapes;

namespace StorageAnalyzer
{
    /// <summary>
    /// Interaction logic for VisualStorage.xaml
    /// </summary>
    public partial class VisualStorage : Window
    {
        public VisualStorage()
        {
            InitializeComponent();
        }

        public VisualStorage(string path)
        {            
            InitializeComponent();
            StorageOccupancy Occupancy = new StorageOccupancy(path);
            Occupancy.SetVisualAnalyzerValue();
            Contentlabel.Content = path;
            FileNum.Text = Occupancy.NumOfFiles;
            DirNum.Text = Occupancy.NumOfDirs;

        }
    }
}
