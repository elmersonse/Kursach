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
    /// Логика взаимодействия для ZapisAdd.xaml
    /// </summary>
    public partial class ZapisAdd : Page
    {
        private DataGrid DataGrid;
        private Grid Grid;
        private Frame Frame;
        private Dictionary<int, string> RebenokCB;
        private Dictionary<int, string> KruzhokCB;

        public ZapisAdd(DataGrid datagrid, Grid grid, Frame frame)
        {
            InitializeComponent();
            DataGrid = datagrid;
            Grid = grid;
            Frame = frame;
            RebenokCB = Repository.RebenokCB();
            KruzhokCB = Repository.KruzhokCB();
            tb1.ItemsSource = RebenokCB.Values;
            tb2.ItemsSource = KruzhokCB.Values;
            Confirm.Content = "Добавить";
        }

        private int check = 0;
        private string editcode;

        public ZapisAdd(DataGrid datagrid, Grid grid, Frame frame, int c)
        {
            InitializeComponent();
            check = c;
            DataGrid = datagrid;
            Grid = grid;
            Frame = frame;
            RebenokCB = Repository.RebenokCB();
            KruzhokCB = Repository.KruzhokCB();
            tb1.ItemsSource = RebenokCB.Values;
            tb2.ItemsSource = KruzhokCB.Values;
            Confirm.Content = "Изменить";
            DataRowView rw = DataGrid.SelectedItems[0] as DataRowView;
            editcode = rw[0].ToString();
            for (int i = 0; i < RebenokCB.Count; i++)
            {
                if (RebenokCB.ElementAt(i).Value.Contains($"{rw[2]} {rw[3]}") && RebenokCB.ElementAt(i).Value.Contains(Repository.RebenokSmena(int.Parse(rw[1].ToString()))))
                {
                    tb1.SelectedIndex = i;
                }
            }
            for (int i = 0; i < KruzhokCB.Count; i++)
            {
                if (KruzhokCB.ElementAt(i).Value.Contains(rw[4].ToString()))
                {
                    tb2.SelectedIndex = i;
                }
            }
            tb3.Text = rw[5].ToString();
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
            if (tb1.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите ребёнка!");
                tb1.Focus();
                return;
            }
            if (tb2.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите кружок!");
                tb2.Focus();
                return;
            }
            if (tb3.Text == "")
            {
                MessageBox.Show("Выберите дату записи!");
                tb3.Focus();
                return;
            }
            int code1 = 0, code2 = 0;
            foreach (var k in RebenokCB)
            {
                if (k.Value == tb1.Text)
                {
                    code1 = k.Key;
                }
            }
            foreach (var k in KruzhokCB)
            {
                if (k.Value == tb2.Text)
                {
                    code2 = k.Key;
                }
            }
            if(check == 0)
            {
                Repository.AddZapis(code1.ToString(), code2.ToString(), tb3.Text);
            }
            else if(check == 1)
            {
                Repository.EditZapis(code1.ToString(), code2.ToString(), tb3.Text, editcode);
            }
            DataGrid.ItemsSource = Repository.LoadZapis().DefaultView;
            DataGrid.Columns[0].Visibility = Visibility.Collapsed;
            DataGrid.Columns[1].Visibility = Visibility.Collapsed;
            DataGrid.Columns[5].Header = "Дата записи";
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
