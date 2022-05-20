using System;
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
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Page
    {
        public Registration()
        {
            InitializeComponent();
            tb1.Focus();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        private void Confirm_Click(object sender, RoutedEventArgs e)
        {
            if (tb1.Text == "")
            {
                MessageBox.Show("Введите логин!");
                tb1.Focus();
                return;
            }
            if (tb2.Password == "")
            {
                MessageBox.Show("Введите пароль!");
                tb2.Focus();
                return;
            }
            if (tb3.Password == "")
            {
                MessageBox.Show("Введите пароль повторно!");
                tb3.Focus();
                return;
            }
            if(tb2.Password != tb3.Password)
            {
                MessageBox.Show("Пароли не совпадают!");
                tb2.Focus();
                return;
            }
            if (Repository.AddUser(tb1.Text, tb2.Password, tb1, tb2, tb3))
            {
                Repository.LogIn(tb1.Text, tb2.Password, tb1, tb2);
            }
        }
    }
}
