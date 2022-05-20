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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static Frame MainFrame;
        public static Button bu2;
        public static Button bu3;
        public static Button bu4;

        public MainWindow()
        {
            InitializeComponent();
            Repository.OpenConnection();
            MainFrame = BottomFrame;
            bu2 = b2;
            bu3 = b3;
            bu4 = b1;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            BottomFrame.Source = new Uri("MainPage.xaml", UriKind.RelativeOrAbsolute);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            BottomFrame.Source = new Uri("TableViewPage.xaml", UriKind.RelativeOrAbsolute);
        }

        private void b3_Click(object sender, RoutedEventArgs e)
        {
            BottomFrame.Source = new Uri("Authorization/Authorization.xaml", UriKind.RelativeOrAbsolute);

        }

        private void b1_Click(object sender, RoutedEventArgs e)
        {
            BottomFrame.Source = new Uri("ReportsPage.xaml", UriKind.RelativeOrAbsolute);
        }

        private void b2_Click(object sender, RoutedEventArgs e)
        {
            BottomFrame.Source = new Uri("SettingsPage.xaml", UriKind.RelativeOrAbsolute);
        }
    }
}
