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
    /// Логика взаимодействия для OtryadAdd.xaml
    /// </summary>
    public partial class OtryadAdd : Page
    {
        private DataGrid DataGrid;
        private Grid Grid;
        private Frame Frame;
        private Dictionary<int, string> VozhatiyCB;
        private Dictionary<int, string> SmenaCB;

        public OtryadAdd(DataGrid datagrid, Grid grid, Frame frame)
        {
            InitializeComponent();
            DataGrid = datagrid;
            Grid = grid;
            Frame = frame;
            VozhatiyCB = Repository.VozhatiyCB();
            SmenaCB = Repository.SmenaCB();
            tb2.ItemsSource = VozhatiyCB.Values;
            tb3.ItemsSource = SmenaCB.Values;
            Confirm.Content = "Добавить";
        }

        private int check = 0;
        private string editcode;

        public OtryadAdd(DataGrid datagrid, Grid grid, Frame frame, int c)
        {
            InitializeComponent();
            check = c;
            DataGrid = datagrid;
            Grid = grid;
            Frame = frame;
            VozhatiyCB = Repository.VozhatiyCB();
            SmenaCB = Repository.SmenaCB();
            tb2.ItemsSource = VozhatiyCB.Values;
            tb3.ItemsSource = SmenaCB.Values;
            Confirm.Content = "Изменить";
            DataRowView rw = DataGrid.SelectedItems[0] as DataRowView;
            editcode = rw[0].ToString();
            tb1.Text = rw[1].ToString();
            for (int i = 0; i < VozhatiyCB.Count; i++)
            {
                if (VozhatiyCB.ElementAt(i).Value.Contains(rw[2].ToString()))
                {
                    tb2.SelectedIndex = i;
                }
            }
            for (int i = 0; i < SmenaCB.Count; i++)
            {
                if (SmenaCB.ElementAt(i).Value.Contains(rw[3].ToString().Substring(0, 10)))
                {
                    tb3.SelectedIndex = i;
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
            if (tb2.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите вожатого!");
                tb2.Focus();
                return;
            }
            if (tb3.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите смену!");
                tb3.Focus();
                return;
            }
            int code1 = 0;
            int code2 = 0;
            foreach (var k in VozhatiyCB)
            {
                if (k.Value == tb2.Text)
                {
                    code1 = k.Key;
                }
            }
            foreach (var k in SmenaCB)
            {
                if (k.Value == tb3.Text)
                {
                    code2 = k.Key;
                }
            }
            if(check == 0)
            {
                Repository.AddOtryad(tb1.Text, code1.ToString(), code2.ToString());
            }
            else
            {
                Repository.EditOtryad(tb1.Text, code1.ToString(), code2.ToString(), editcode);
            }
            DataGrid.ItemsSource = Repository.LoadOtryad().DefaultView;
            DataGrid.Columns[0].Visibility = Visibility.Collapsed;
            DataGrid.Columns[2].Header = "Фамилия вожатого";
            DataGrid.Columns[3].Header = "Дата начала смены";
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
