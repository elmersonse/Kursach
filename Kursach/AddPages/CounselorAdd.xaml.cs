﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
    /// Логика взаимодействия для CounselorAdd.xaml
    /// </summary>
    public partial class CounselorAdd : Page
    {
        private DataGrid DataGrid;
        private Grid Grid;
        private Frame Frame;

        public CounselorAdd(DataGrid datagrid, Grid grid, Frame frame)
        {
            InitializeComponent();
            DataGrid = datagrid;
            Grid = grid;
            Frame = frame;
            Confirm.Content = "Добавить";
        }

        private int check = 0;
        private string editcode;

        public CounselorAdd(DataGrid datagrid, Grid grid, Frame frame, int c)
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
            tb3.Text = rw[3].ToString();
            tb4.Text = rw[4].ToString();
            tb5.Text = rw[5].ToString();
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
            if(tb4.Text.Length == 0)
            {
                MessageBox.Show("Введите дату рождения!");
                tb4.Focus();
                return;
            }
            string temp;
            if(!tb5.IsMaskCompleted)
            {
                temp = "";
            }
            else
            {
                temp = tb5.Text;
            }
            if(check == 0)
            {
                Repository.AddVojatiy(tb1.Text, tb2.Text, tb3.Text, tb4.Text, temp);
            }
            else if(check == 1)
            {
                Repository.EditVojatiy(tb1.Text, tb2.Text, tb3.Text, tb4.Text, temp, editcode);
            }
            
            DataGrid.ItemsSource = Repository.LoadVojatiy().DefaultView;
            DataGrid.Columns[0].Visibility = Visibility.Collapsed;
            DataGrid.Columns[4].Header = "Дата рождения";
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
