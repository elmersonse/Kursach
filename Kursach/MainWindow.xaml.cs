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
        public MainWindow()
        {
            InitializeComponent();
            Repository.OpenConnection();
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

        }
    }
}
