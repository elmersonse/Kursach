using System;
using System.Collections.Generic;
using System.Data;
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

namespace Kursach.AddPages
{
    /// <summary>
    /// Логика взаимодействия для KruzhokAdd.xaml
    /// </summary>
    public partial class KruzhokAdd : Page
    {
        private DataGrid DataGrid;
        private Grid Grid;
        private Frame Frame;
        private Dictionary<int, string> KomnataCB;

        public KruzhokAdd(DataGrid datagrid, Grid grid, Frame frame)
        {
            InitializeComponent();
            DataGrid = datagrid;
            Grid = grid;
            Frame = frame;
            KomnataCB = Repository.KomnataCB();
            tb2.ItemsSource = KomnataCB.Values;
            Confirm.Content = "Добавить";
        }

        private int check = 0;
        private string editcode;

        public KruzhokAdd(DataGrid datagrid, Grid grid, Frame frame, int c)
        {
            InitializeComponent();
            check = c;
            DataGrid = datagrid;
            Grid = grid;
            Frame = frame;
            KomnataCB = Repository.KomnataCB();
            tb2.ItemsSource = KomnataCB.Values;
            Confirm.Content = "Изменить";
            DataRowView rw = DataGrid.SelectedItems[0] as DataRowView;
            editcode = rw[0].ToString();
            tb1.Text = rw[1].ToString();
            for (int i = 0; i < KomnataCB.Count; i++)
            {
                if (KomnataCB.ElementAt(i).Value.Contains(rw[2].ToString()))
                {
                    tb2.SelectedIndex = i;
                }
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            DataGrid.Visibility = Visibility.Visible;
            Grid.Visibility = Visibility.Visible;
            Frame.Visibility = Visibility.Hidden;
            Frame.Source = null;
        }

        private void Confirm_Click(object sender, RoutedEventArgs e)
        {
            if(tb2.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите комнату!");
                tb2.Focus();
                return;
            }
            int code = 0;
            foreach(var k in KomnataCB)
            {
                if(k.Value == tb2.Text)
                {
                    code = k.Key;
                }
            }
            if(check == 0)
            {
                Repository.AddKruzhok(tb1.Text, code.ToString());
            }
            else
            {
                Repository.EditKruzhok(tb1.Text, code.ToString(), editcode);
            }
            DataGrid.ItemsSource = Repository.LoadKruzhok().DefaultView;
            DataGrid.Columns[0].Visibility = Visibility.Collapsed;
            DataGrid.Columns[1].Header = "Название";
            DataGrid.Columns[2].Header = "Номер комнаты";
            DataGrid.Visibility = Visibility.Visible;
            Grid.Visibility = Visibility.Visible;
            Frame.Visibility = Visibility.Hidden;
            Frame.Source = null;
        }

        private void CheckLetter(object sender, TextCompositionEventArgs e)
        {
            Util.CheckLetter(sender, e);
        }
    }
}
