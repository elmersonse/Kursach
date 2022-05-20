﻿using System;
using System.Collections.Generic;
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

namespace Kursach.Authorization
{
    /// <summary>
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : Page
    {
        public Authorization()
        {
            InitializeComponent();
            tb1.Focus();
        }

        private void CheckLogin(object sender, TextCompositionEventArgs e)
        {
            Util.CheckLogin(sender, e);
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            if (tb1.Text == "") 
            {
                MessageBox.Show("Введите логин!");
                tb1.Focus();
                return;
            }
            if(tb2.Password == "")
            {
                MessageBox.Show("Введите пароль!");
                tb2.Focus();
                return;
            }
            Repository.LogIn(tb1.Text, tb2.Password, tb1, tb2);
        }

        private void Registration_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.MainFrame.Source = new Uri("Authorization/Registration.xaml", UriKind.RelativeOrAbsolute);
        }
    }

    
}
