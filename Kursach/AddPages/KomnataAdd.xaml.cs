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
    /// Логика взаимодействия для KomnataAdd.xaml
    /// </summary>
    public partial class KomnataAdd : Page
    {
        private DataGrid DataGrid;
        private Grid Grid;
        private Frame Frame;
        private Dictionary<int, string> KorpusCB;

        public KomnataAdd(DataGrid datagrid, Grid grid, Frame frame)
        {
            InitializeComponent();
            DataGrid = datagrid;
            Grid = grid;
            Frame = frame;
            KorpusCB = Repository.KorpusCB();
            tb2.ItemsSource = KorpusCB.Values;
            Confirm.Content = "Добавить";
        }

        private int check = 0;
        private string editcode;

        public KomnataAdd(DataGrid datagrid, Grid grid, Frame frame, int c)
        {
            InitializeComponent();
            check = c;
            DataGrid = datagrid;
            Grid = grid;
            Frame = frame;
            KorpusCB = Repository.KorpusCB();
            tb2.ItemsSource = KorpusCB.Values;
            Confirm.Content = "Изменить";
            DataRowView rw = DataGrid.SelectedItems[0] as DataRowView;
            editcode = rw[0].ToString();
            tb1.Text = rw[1].ToString();
            for(int i = 0; i < KorpusCB.Count; i++)
            {
                if(KorpusCB.ElementAt(i).Value.Contains($"№{rw[2]} ")) {
                    tb2.SelectedIndex = i;
                }
            }
            tb3.Text = rw[3].ToString();
            tb4.Text = rw[4].ToString();
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
                MessageBox.Show("Выберите корпус!");
                tb2.Focus();
                return;
            }
            int code = 0;
            foreach(var k in KorpusCB)
            {
                if(k.Value == tb2.Text)
                {
                    code = k.Key;
                }
            }
            if(check == 0) 
            { 
                Repository.AddKomnata(tb1.Text, code.ToString(), tb3.Text, tb4.Text);
            }
            else if(check == 1)
            {
                Repository.EditKomnata(tb1.Text, code.ToString(), tb3.Text, tb4.Text, editcode);
            }
            DataGrid.ItemsSource = Repository.LoadKomnata().DefaultView;
            DataGrid.Columns[0].Visibility = Visibility.Collapsed;
            DataGrid.Columns[1].Header = "Номер комнаты";
            DataGrid.Columns[2].Header = "Номер корпуса";
            DataGrid.Columns[3].Header = "Тип комнаты";
            DataGrid.Columns[4].Header = "Количество мест";
            DataGrid.Visibility = Visibility.Visible;
            Grid.Visibility = Visibility.Visible;
            Frame.Visibility = Visibility.Hidden;
            Frame.Source = null;
        }

        private void CheckLetter(object sender, TextCompositionEventArgs e)
        {
            Util.CheckLetter(sender, e);
        }

        private void CheckNumber(object sender, TextCompositionEventArgs e)
        {
            Util.CheckNumber(sender, e);
        }
    }
}
