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
    /// Логика взаимодействия для SmenaAdd.xaml
    /// </summary>
    public partial class SmenaAdd : Page
    {
        private DataGrid DataGrid;
        private Grid Grid;
        private Frame Frame;

        public SmenaAdd(DataGrid datagrid, Grid grid, Frame frame)
        {
            InitializeComponent();
            DataGrid = datagrid;
            Grid = grid;
            Frame = frame;
            Confirm.Content = "Добавить";
        }

        private int check = 0;
        private string editcode;

        public SmenaAdd(DataGrid datagrid, Grid grid, Frame frame, int c)
        {
            InitializeComponent();
            check = c;
            DataGrid = datagrid;
            Grid = grid;
            Frame = frame;
            Confirm.Content = "Изменить";
            DataRowView rw = DataGrid.SelectedItems[0] as DataRowView;
            editcode = rw[0].ToString();
            tb1.Text = rw[1].ToString();
            tb2.Text = rw[2].ToString();
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
            if(tb1.Text == "")
            {
                MessageBox.Show("Выберите дату начала!");
                tb1.Focus();
                return;
            }
            if(tb2.Text == "")
            {
                MessageBox.Show("Выберите дату окончания!");
                tb2.Focus();
                return;
            }
            if(check == 0)
            {
                Repository.AddSmena(tb1.Text, tb2.Text);
            }
            else
            {
                Repository.EditSmena(tb1.Text, tb2.Text, editcode);
            }
            DataGrid.ItemsSource = Repository.LoadSmena().DefaultView;
            DataGrid.Columns[0].Visibility = Visibility.Collapsed;
            DataGrid.Columns[1].Header = "Дата начала";
            DataGrid.Columns[2].Header = "Дата окончания";
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
