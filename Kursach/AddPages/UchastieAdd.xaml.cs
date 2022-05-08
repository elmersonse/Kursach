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
    /// Логика взаимодействия для UchastieAdd.xaml
    /// </summary>
    public partial class UchastieAdd : Page
    {
        private DataGrid DataGrid;
        private Grid Grid;
        private Frame Frame;
        private Dictionary<int, string> MeropriyatieCB;
        private Dictionary<int, string> OtryadCB;

        public UchastieAdd(DataGrid datagrid, Grid grid, Frame frame)
        {
            InitializeComponent();
            DataGrid = datagrid;
            Grid = grid;
            Frame = frame;
            MeropriyatieCB = Repository.MeropriyatieCB();
            OtryadCB = Repository.OtryadCB();
            tb1.ItemsSource = MeropriyatieCB.Values;
            tb2.ItemsSource = OtryadCB.Values;
            Confirm.Content = "Добавить";
        }

        private int check = 0;
        private string editcode;

        public UchastieAdd(DataGrid datagrid, Grid grid, Frame frame, int c)
        {
            InitializeComponent();
            check = c;
            DataGrid = datagrid;
            Grid = grid;
            Frame = frame;
            MeropriyatieCB = Repository.MeropriyatieCB();
            OtryadCB = Repository.OtryadCB();
            tb1.ItemsSource = MeropriyatieCB.Values;
            tb2.ItemsSource = OtryadCB.Values;
            Confirm.Content = "Изменить";
            DataRowView rw = DataGrid.SelectedItems[0] as DataRowView;
            editcode = rw[0].ToString();
            tb3.Text = rw[3].ToString();
            for (int i = 0; i < OtryadCB.Count; i++)
            {
                if (OtryadCB.ElementAt(i).Value.Contains(rw[2].ToString()))
                {
                    tb2.SelectedIndex = i;
                }
            }
            for (int i = 0; i < MeropriyatieCB.Count; i++)
            {
                if (MeropriyatieCB.ElementAt(i).Value.Contains(rw[1].ToString()))
                {
                    tb1.SelectedIndex = i;
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
            if(tb1.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите мероприятие!");
                tb1.Focus();
                return;
            }
            if(tb2.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите отряд!");
                tb2.Focus();
                return;
            }
            if(tb3.Text == "")
            {
                MessageBox.Show("Выберите дату проведения!");
                tb3.Focus();
                return;
            }
            int code1 = 0, code2 = 0;
            foreach(var k in MeropriyatieCB)
            {
                if(k.Value == tb1.Text)
                {
                    code1 = k.Key;
                }
            }
            foreach(var k in OtryadCB)
            {
                if(k.Value == tb2.Text)
                {
                    code2 = k.Key;
                }
            }
            if(check == 0)
            {
                Repository.AddUchastie(code1.ToString(), code2.ToString(), tb3.Text);
            }
            else
            {
                Repository.EditUchastie(code1.ToString(), code2.ToString(), tb3.Text, editcode);
            }
            DataGrid.ItemsSource = Repository.LoadUchastie().DefaultView;
            DataGrid.Columns[0].Visibility = Visibility.Collapsed;
            DataGrid.Columns[3].Header = "Дата проведения";
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
