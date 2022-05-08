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
    /// Логика взаимодействия для RebenokAdd.xaml
    /// </summary>
    public partial class RebenokAdd : Page
    {
        private DataGrid DataGrid;
        private Grid Grid;
        private Frame Frame;
        private Dictionary<int, string> KomnataCB;
        private Dictionary<int, string> OtryadCB;

        public RebenokAdd(DataGrid datagrid, Grid grid, Frame frame)
        {
            InitializeComponent();
            DataGrid = datagrid;
            Grid = grid;
            Frame = frame;
            KomnataCB = Repository.KomnataCB();
            OtryadCB = Repository.OtryadCB();
            tb6.ItemsSource = OtryadCB.Values;
            tb7.ItemsSource = KomnataCB.Values;
            Confirm.Content = "Добавить";
        }

        private int check = 0;
        private string editcode;

        public RebenokAdd(DataGrid datagrid, Grid grid, Frame frame, int c)
        {
            InitializeComponent();
            check = c;
            DataGrid = datagrid;
            Grid = grid;
            Frame = frame;
            KomnataCB = Repository.KomnataCB();
            OtryadCB = Repository.OtryadCB();
            tb6.ItemsSource = OtryadCB.Values;
            tb7.ItemsSource = KomnataCB.Values;
            Confirm.Content = "Изменить";
            DataRowView rw = DataGrid.SelectedItems[0] as DataRowView;
            editcode = rw[0].ToString();
            tb1.Text = rw[1].ToString();
            tb2.Text = rw[2].ToString();
            tb3.Text = rw[3].ToString();
            tb4.Text = rw[4].ToString();
            tb5.Text = rw[5].ToString();
            for (int i = 0; i < OtryadCB.Count; i++)
            {
                if (OtryadCB.ElementAt(i).Value.Contains(rw[6].ToString()))
                {
                    tb6.SelectedIndex = i;
                }
            }
            for (int i = 0; i < KomnataCB.Count; i++)
            {
                if (KomnataCB.ElementAt(i).Value.Contains(rw[7].ToString()))
                {
                    tb7.SelectedIndex = i;
                }
            }

            tb6.Text = rw[6].ToString();
            tb7.Text = rw[7].ToString();
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
            if(tb6.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите отряд!");
                tb6.Focus();
                return;
            }
            if(tb7.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите комнату!");
                tb7.Focus();
                return;
            }
            if(tb5.Text == "")
            {
                MessageBox.Show("Выберите дату рождения!");
                tb5.Focus();
                return;
            }
            int code1 = 0;
            int code2 = 0;
            foreach(var k in OtryadCB)
            {
                if(tb6.Text == k.Value)
                {
                    code1 = k.Key;
                }
            }
            foreach(var k in KomnataCB)
            {
                if(tb7.Text == k.Value)
                {
                    code2 = k.Key;
                }
            }
            if(check == 0)
            {
                Repository.AddRebenok(tb1.Text, tb2.Text, tb3.Text, tb4.Text, tb5.Text, code1.ToString(), code2.ToString());
            }
            else
            {
                Repository.EditRebenok(tb1.Text, tb2.Text, tb3.Text, tb4.Text, tb5.Text, code1.ToString(), code2.ToString(), editcode);
            }
            DataGrid.ItemsSource = Repository.LoadRebenok().DefaultView;
            DataGrid.Columns[0].Visibility = Visibility.Collapsed;
            DataGrid.Columns[5].Header = "Дата рождения";
            DataGrid.Columns[6].Header = "Название отряда";
            DataGrid.Columns[7].Header = "Номер комнаты";
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
