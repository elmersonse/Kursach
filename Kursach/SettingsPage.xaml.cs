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

namespace Kursach
{
    /// <summary>
    /// Логика взаимодействия для SettingsPage.xaml
    /// </summary>
    public partial class SettingsPage : Page
    {
        public SettingsPage()
        {
            InitializeComponent();
            if(Repository.currentUser != null)
            {
                l1.Content = $"Текущий пользователь: {Repository.currentUser.Login}";
            }
            if(Repository.currentUser.Role == "Администратор")
            {
                UsersButton.Visibility = Visibility.Visible;
            }
            else
            {
                UsersButton.Visibility = Visibility.Hidden;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.bu2.Visibility = Visibility.Hidden;
            MainWindow.bu3.Visibility = Visibility.Visible;
            MainWindow.bu4.IsEnabled = false;
            Repository.currentUser = null;
            MainWindow.MainFrame.Source = new Uri("MainPage.xaml", UriKind.RelativeOrAbsolute);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow.MainFrame.Source = new Uri("UsersPage.xaml", UriKind.RelativeOrAbsolute);
        }
    }
}
