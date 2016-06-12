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
            // Create the Grid
            Grid DynamicGrid = new Grid();           
            DynamicGrid.Width = 400;
            DynamicGrid.HorizontalAlignment = HorizontalAlignment.Center;
            DynamicGrid.VerticalAlignment = VerticalAlignment.Center;
            DynamicGrid.ShowGridLines = true;
            DynamicGrid.Background = new SolidColorBrush(Colors.LightGoldenrodYellow);

            // Create Columns
            ColumnDefinition gridCol1 = new ColumnDefinition();
            ColumnDefinition gridCol2 = new ColumnDefinition();
            ColumnDefinition gridCol3 = new ColumnDefinition();
            ColumnDefinition gridCol4 = new ColumnDefinition();
            DynamicGrid.ColumnDefinitions.Add(gridCol1);
            DynamicGrid.ColumnDefinitions.Add(gridCol2);
            DynamicGrid.ColumnDefinitions.Add(gridCol3);
            DynamicGrid.ColumnDefinitions.Add(gridCol4);  
         
            //create first row
            RowDefinition gridRow1 = new RowDefinition();
            gridRow1.Height = new GridLength(30);           
            DynamicGrid.RowDefinitions.Add(gridRow1);
         

            // Add first column header
            TextBlock txtBlock1 = GetColumnHeader("Name", 10);
            Grid.SetRow(txtBlock1, 0);
            Grid.SetColumn(txtBlock1, 0);

            // Add second column header
            TextBlock txtBlock2 = GetColumnHeader("Extension", 10);
            Grid.SetRow(txtBlock2, 0);
            Grid.SetColumn(txtBlock2, 1);

            // Add third column header
            TextBlock txtBlock3 = GetColumnHeader("Size", 10);
            Grid.SetRow(txtBlock3, 0);
            Grid.SetColumn(txtBlock3, 2);

            // Add fourth column header
            TextBlock txtBlock4 = GetColumnHeader("Last Changed", 10);
            Grid.SetRow(txtBlock4, 0);
            Grid.SetColumn(txtBlock4, 3);

            //// Add column headers to the Grid
            DynamicGrid.Children.Add(txtBlock1);
            DynamicGrid.Children.Add(txtBlock2);
            DynamicGrid.Children.Add(txtBlock3);
            DynamicGrid.Children.Add(txtBlock4);

            int RowVal = 1;
            foreach (DirInfo dirinf in Occupancy.FileInf.Values)
            {
                /*RowDefinition gridRow = new RowDefinition();
                gridRow.Height = new GridLength(20);
                DynamicGrid.RowDefinitions.Add(gridRow);*/
               RowVal = GetColumnText(dirinf, RowVal, DynamicGrid);
                
            }

            MainPanel.Children.Add(DynamicGrid);
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
                Grid.SetRow(NameText, RowValue);
                Grid.SetColumn(NameText, 0);
                DynamicGrid.Children.Add(NameText);
                TextBlock ExtText = new TextBlock();
                ExtText.Text = FilContent._extension;
                ExtText.FontSize = 10;
                Grid.SetRow(ExtText, RowValue);
                Grid.SetColumn(ExtText, 1);
                DynamicGrid.Children.Add(ExtText);
                TextBlock SizeText = new TextBlock();
                SizeText.Text = FilContent._size;
                SizeText.FontSize = 10;
                Grid.SetRow(SizeText, RowValue);
                Grid.SetColumn(SizeText, 2);
                DynamicGrid.Children.Add(SizeText);
                TextBlock ChangedText = new TextBlock();
                ChangedText.Text = FilContent._lastchanged;
                ChangedText.FontSize = 10;
                Grid.SetRow(ChangedText, RowValue);
                Grid.SetColumn(ChangedText, 3);
                DynamicGrid.Children.Add(ChangedText);
                RowValue++;
            }
            return RowValue;
        }
    }
}
