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
            Contentlabel.Content = "CurrentPath : " + path;
            FileNum.Text = Occupancy.NumOfFiles;
            DirNum.Text = Occupancy.NumOfDirs;            

            int RowVal = 1;
            foreach (DirInfo dirinf in Occupancy.FileInf.Values)
            {
                /*RowDefinition gridRow = new RowDefinition();
                gridRow.Height = new GridLength(20);
                DynamicGrid.RowDefinitions.Add(gridRow);*/
               RowVal = GetColumnText(dirinf, RowVal, DynamicGrid);
                
            }
        }

        TextBlock GetColumnHeader(string Name, int size)
        {
            TextBlock txtBlock = new TextBlock();
            txtBlock.Text = Name;
            txtBlock.FontSize = size;
            txtBlock.FontWeight = FontWeights.Bold;
            txtBlock.Foreground = new SolidColorBrush(Colors.Black);
            txtBlock.VerticalAlignment = VerticalAlignment.Top;
            txtBlock.HorizontalAlignment = HorizontalAlignment.Center;
            return txtBlock;
        }

        int GetColumnText(DirInfo Content, int RowValue, Grid DynamicGrid)
        {
            foreach (FileInform FilContent in Content._files)
            {
                RowDefinition gridRow = new RowDefinition();
                gridRow.Height = new GridLength(20);
                DynamicGrid.RowDefinitions.Add(gridRow);
                TextBlock NameText = new TextBlock();
                NameText.Text = FilContent._filename;
                NameText.FontSize = 10;
                NameText.TextAlignment = TextAlignment.Center;
                Grid.SetRow(NameText, RowValue);
                Grid.SetColumn(NameText, 0);
                DynamicGrid.Children.Add(NameText);
                TextBlock ExtText = new TextBlock();
                ExtText.Text = FilContent._extension;
                ExtText.FontSize = 10;
                ExtText.TextAlignment = TextAlignment.Center;
                Grid.SetRow(ExtText, RowValue);
                Grid.SetColumn(ExtText, 1);
                DynamicGrid.Children.Add(ExtText);
                TextBlock SizeText = new TextBlock();
                SizeText.Text = FilContent._size;
                SizeText.FontSize = 10;
                SizeText.TextAlignment = TextAlignment.Center;
                Grid.SetRow(SizeText, RowValue);
                Grid.SetColumn(SizeText, 2);
                DynamicGrid.Children.Add(SizeText);
                TextBlock ChangedText = new TextBlock();
                ChangedText.Text = FilContent._lastchanged;
                ChangedText.FontSize = 10;
                ChangedText.TextAlignment = TextAlignment.Center;
                Grid.SetRow(ChangedText, RowValue);
                Grid.SetColumn(ChangedText, 3);
                DynamicGrid.Children.Add(ChangedText);
                RowValue++;
            }
            return RowValue;
        }
    }
}
